using System.Text;
using System.Globalization;
using System.Xml.Linq;
using CsvHelper;
using USPS;

namespace USPSAddressStandardization;

class Program
{
	public static async Task Main()
	{
        if(UspsUserId.TryGetValue(out string userId) == false)
        {
			//userId = UspsUserId.SetUserId();
        }
        var uspsApi = new UspsApi();
	    List<AddressResponse> NotFound = new();
	    List<AddressResponse> CorrectionNeeded = new();

        StringBuilder csvText = new StringBuilder("ID,Street,Apartment,City,State,Zip,Errors\n");

        using var streamReader = new StreamReader(@"C:\Users\y.steinmetz\OneDrive - Human Care Services\data validation\All+Addresses.csv");
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        var records = csvReader.GetRecords<Record>();

        foreach (var item in records)
        {
            var addressRequest = new AddressValidateRequest();
            addressRequest.UserId = userId;
            addressRequest.Revision = "1";
            addressRequest.Address.Id = item.Id;
            addressRequest.Address.StreetAddress = item.Street;
            addressRequest.Address.Apt = GetRidOfHash(item.Apartment);
            addressRequest.Address.City = item.City;
            addressRequest.Address.State = item.State;
            addressRequest.Address.Zip5 = item.Zip;
            addressRequest.Address.Zip4 = "";

            try
			{
                Console.WriteLine($"proccesing address {item.Street}, {item.City} {item.State}, {item.Zip}");
                var response = await uspsApi.GetAddressInfo(addressRequest);
                
                if(response.Address.StreetAddress == null)
                {
                    response.Address.Error = "address not found";
                    NotFound.Add(response);
                }
                else if (response.Address.Error != "")
                {
                    CorrectionNeeded.Add(response);
                }
                csvText.AppendLine($"{item.Id},{item.Street},{item.Apartment},{item.City},{item.State},{item.Zip},\"{response.Address.Error}\"");
            }
            catch (Exception ex)
            {

            }
        }
        string filePath = @"C:\Users\y.steinmetz\OneDrive - Human Care Services\data validation\Updated Addresses Test.csv";

        await File.WriteAllTextAsync(filePath, csvText.ToString());

        
        Console.WriteLine($"{records.Count()} addresses were scanned");
        Console.WriteLine($"{NotFound.Count} addresses was not found");
        Console.WriteLine($"{CorrectionNeeded.Count} addresses needs correction");

    }
	
	private static string GetRidOfHash(string apartment)
    {
		if (apartment.StartsWith('#'))
        {
			return "Apt " + apartment[1..];
        }
		else return apartment;
    }

}

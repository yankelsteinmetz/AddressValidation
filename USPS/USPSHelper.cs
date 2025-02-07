using System.Text;

namespace USPS;

public static class USPSHelper
{
    //public static async IAsyncEnumerable<AddressResponse> ValidateAddress(List<Record> records, string userId, UspsApi uspsApi)
    //{
    //    AddressResponse response = new();
    //    foreach (var item in records)
    //    {
    //        var addressRequest = new AddressValidateRequest();
    //        addressRequest.UserId = userId;
    //        addressRequest.Revision = "1";
    //        addressRequest.Address.Id = item.Id;
    //        addressRequest.Address.StreetAddress = item.Street;
    //        addressRequest.Address.Apt = GetRidOfHash(item.Apartment);
    //        addressRequest.Address.City = item.City;
    //        addressRequest.Address.State = item.State;
    //        addressRequest.Address.Zip5 = item.Zip;
    //        addressRequest.Address.Zip4 = "";

    //        try
    //        {
    //            response = await uspsApi.GetAddressInfo(addressRequest);

    //            if (response.Address.StreetAddress == null)
    //            {
    //                response.Address.Error = "address not found";
    //            }
    //        }
    //        catch
    //        {
    //            throw;
    //        }
    //        yield return response;
    //    }
    //}
    public static async Task<Record> ValidateAddress(Record record, string userId, UspsApi uspsApi)
    {
        var addressRequest = new AddressValidateRequest();
        addressRequest.UserId = userId;
        addressRequest.Revision = "1";
        addressRequest.Address.Id = record.Id;
        addressRequest.Address.StreetAddress = GetRidOfHash(record.Street);
        addressRequest.Address.Apt = GetRidOfHash(record.Apartment);
        addressRequest.Address.City = record.City;
        addressRequest.Address.State = record.State;
        addressRequest.Address.Zip5 = record.Zip;
        addressRequest.Address.Zip4 = "";

        try
        {
            var response = await uspsApi.GetAddressInfo(addressRequest);

            if (response.Address.StreetAddress == null)
            {
                response.Address.Error = "address not found";
            }

            record.Id = response.Address.Id;
            record.Street = response.Address.StreetAddress;
            record.Apartment = response.Address.Apt;
            record.City = response.Address.City;
            record.State = response.Address.State;
            record.Zip = $"{response.Address.Zip5} - {response.Address.Zip4}";
            record.Error = response.Address.Error;

            return record;
        }
        catch
        {
            throw;
        }
    }
    private static string GetRidOfHash(string address)
    {
        return address.Replace("#", "APT ");
    }
    public static string ToCSV(this IEnumerable<Record> records)
    {
        var csvText = new StringBuilder("ID,Street,Apt,City,State,Zip,Error\n");
        foreach (var response in records)
        {
            csvText.AppendLine($"{response.Id},{response.Street},{response.Apartment},{response.City},{response.State},{response.Zip},\"{response.Error}\"");
        }
        return csvText.ToString();
    }
}

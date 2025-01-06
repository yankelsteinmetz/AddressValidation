using System.Xml.Serialization;

namespace USPS;  
public class UspsApi
{
    private readonly HttpClient httpClient;
    private readonly XmlSerializer deserializer;
    private readonly XmlSerializer serializer;
    public UspsApi()
    {
        httpClient = new HttpClient();
        deserializer = new(typeof(AddressResponse));
        serializer = new(typeof(AddressValidateRequest));
    }
    public async Task<AddressResponse> GetAddressInfo(AddressValidateRequest request)
    {
        try
        {
            //convert the request model to XMl text.
            using StringWriter stringWriter = new();
            serializer.Serialize(stringWriter, request);
            string xmlRequest = stringWriter.ToString();

            //call the api
            var url = "http://production.shippingapis.com/ShippingAPI.dll?API=Verify&XML=" + xmlRequest;
            var response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            string responseXml = await response.Content.ReadAsStringAsync();

            //convert the Xml response to addressResponse model.
            using StringReader stringReader = new(responseXml);
            var addressResponse = (AddressResponse)deserializer.Deserialize(stringReader)!;
            return addressResponse;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}

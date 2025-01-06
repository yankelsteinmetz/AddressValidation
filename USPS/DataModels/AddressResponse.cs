using System.Xml.Serialization;

namespace USPS;

[XmlRoot("AddressValidateResponse")]
public class AddressResponse
{
    [XmlElement("Address")]
    public Address Address { get; set; }
}

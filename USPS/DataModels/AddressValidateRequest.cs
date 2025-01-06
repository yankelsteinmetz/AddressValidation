using System.Xml.Serialization;

namespace USPS;

[XmlRoot("AddressValidateRequest")]
public class AddressValidateRequest
{
    [XmlAttribute("USERID")]
    public string UserId { get; set;}
    [XmlElement("Revision")]
    public string Revision { get; set; }

    [XmlElement("Address")]
    public Address Address { get; set; } =new();
}
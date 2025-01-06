using System.Xml.Serialization;

namespace USPS;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class Address
{
    [XmlAttribute("ID")]
    public string Id { get; set; }
    [XmlElement("Address1")]
    public string Apt { get; set; }
    [XmlElement("Address2")]
    public string StreetAddress { get; set; }
    [XmlElement("City")]
    public string City { get; set; }
    [XmlElement("CityAbbreviation")]
    public string CityAbbreviation { get; set; }
    [XmlElement("State")]
    public string State { get; set; }
    [XmlElement("Zip5")]
    public string Zip5 { get; set; }
    [XmlElement("Zip4")]
    public string Zip4 { get; set; }
    [XmlElement("ReturnText")]
    public string Error { get; set; }
}

using CsvHelper.Configuration.Attributes;

namespace USPS;

public class Record
{
	[Name("ID")]
	public string Id { get; set; }

	[Name("Street")]
	public string Street { get; set; }

	[Name("Apartment")]
	public string Apartment { get; set; }

	[Name("City")]
	public string City { get; set; }

	[Name("State")]
	public string State { get; set; }

	[Name("Zip")]
	public string Zip { get; set; }
	[Ignore]
	public string Error { get; set; }
}

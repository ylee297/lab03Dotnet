
using System.ComponentModel.DataAnnotations;

public class City {
    public int CityId { get; set; }
    public string CityName { get; set; }
    public int Population { get; set; }
    //?? nullable enable??
    #nullable enable  
    public string? ProvinceCode { get; set; }
}

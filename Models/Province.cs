using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Province {
    public string ProvinceCode { get; set; }
    public string ProvinceName { get; set; }
    public List<City> Cities{ get; set; }
}

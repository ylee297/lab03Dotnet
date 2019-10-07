using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public static class SeedData {
    // this is an extension method to the ModelBuilder class
    public static void Seed(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<City>().HasData(
            GetCities()
        );
        modelBuilder.Entity<Province>().HasData(
            GetProvinces()
        );
    }
    public static List<City> GetCities() {
        List<City> cities = new List<City>() {
            new City() {    // 1
                CityId=1,
                CityName= "Vancouver",
                Population= 3000000,
            },
            new City() {    // 2
                CityId=2,
                CityName= "Burnaby",
                Population= 4000000,
            },
            new City() {    // 3
                CityId=3,
                CityName= "Chicago",
                Population= 5000000,
            },
            new City() {    // 4
                CityId=4,
                CityName= "Anaheim",
                Population= 3323232,
            },
            new City() {    // 5
                CityId=5,
                CityName= "Toronto",
                Population= 3004000,
            },
            new City() {    // 6
                CityId=6,
                CityName= "Calgary",
                Population= 9090999,
            },
            new City() {    // 7
                CityId=7,
                CityName= "Edmonton",
                Population= 10109922,
            },
            new City() {    // 8
                CityId=8,
                CityName= "San Jose",
                Population= 786600120,
            }
        };

        return cities;
    }

    public static List<Province> GetProvinces() {
        List<Province> provinces = new List<Province>() {
            new Province {
                ProvinceCode = "BC",
                ProvinceName = "British Columbia",
            },
            new Province {
                ProvinceCode = "AB",
                ProvinceName = "Alberta",
            },
            new Province {
                ProvinceCode = "ON",
                ProvinceName = "Ontario",
            }
        };

        return provinces;
    }
}

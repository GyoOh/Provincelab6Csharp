using System;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using provinceCity.Models;

    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                GetProvinces()
                );
            modelBuilder.Entity<City>().HasData(
               GetCities()
               );
        }

        public static List<Province> GetProvinces()
        {
            List<Province> Provinces = new List<Province>() {
            new Province() {
                ProvinceCode="BC",
                ProvinceName="BritishColumbia",
            },
             new Province() {
                ProvinceCode="ON",
                ProvinceName="Ontario",
            },
             new Province() {
                ProvinceCode="MB",
                ProvinceName="Manitoba",
            }
        };
            return Provinces;
        }

        public static List<City> GetCities()
        {
            List<City> Cities = new List<City>() {
            new City {
                CityId = 1,
                CityName = "Vancouver",
                ProvinceCode = "BC",
                Population = 660000
            },
            new City {
                CityId = 2,
                CityName = "Surrey",
                ProvinceCode = "BC",
                Population = 570000
            },
             new City {
                CityId = 3,
                CityName = "Langley",
                ProvinceCode = "BC",
                Population = 200000
            },
            new City {
                CityId = 4,
                CityName = "Toronto",
                ProvinceCode = "ON",
                Population = 4000000
            },
            new City {
                CityId = 5,
                CityName = "Ottawa",
                ProvinceCode = "ON",
                Population = 880000
            },
            new City {
                CityId = 6,
                CityName = "Hamilton",
                ProvinceCode = "ON",
                Population = 550000
            },
            new City {
                CityId = 7,
                CityName = "Winnipeg",
                ProvinceCode = "MB",
                Population = 750000
            },
            new City {
                CityId = 8,
                CityName = "Morden",
                ProvinceCode = "MB",
                Population = 6600
            },
            new City {
                CityId = 9,
                CityName = "Brandon",
                ProvinceCode = "MB",
                Population = 10000
            },
        };

            return Cities;
        }
    }


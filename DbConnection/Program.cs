using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DbConnection
{
    internal class Program
    {
        private static IConfiguration _iconfiguration;

        private static void Main(string[] args)
        {
            GetAppSettingsFile();
            PrintCountries();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            _iconfiguration = builder.Build();
        }

        private static void PrintCountries()
        {
            var countryDAL = new CountryDAL.CountryDAL(_iconfiguration);
            var listCountryModel = countryDAL.GetList();
            listCountryModel.ForEach(item => { Console.WriteLine(item.Country); });
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
    }
}
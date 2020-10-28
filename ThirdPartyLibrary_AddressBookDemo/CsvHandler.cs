namespace ThirdPartyLibrary_AddressBookDemo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using CsvHelper;

    public class CsvHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\sajju2002\source\repos\ThirdPartyLibrary_AddressBookDemo\ThirdPartyLibrary_AddressBookDemo\Utility\Address.csv";
            string exportFilePath = @"C:\Users\sajju2002\source\repos\ThirdPartyLibrary_AddressBookDemo\ThirdPartyLibrary_AddressBookDemo\Utility\exports.csv";

            // Reading from Csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data reading done successfully from Address.csv file.");
                foreach (AddressData addressData in records)
                {
                    Console.Write(addressData.FirstName);
                    Console.Write("\t\t" + addressData.LastName);
                    Console.Write("\t\t" + addressData.Address);
                    Console.Write("\t\t" + addressData.City);
                    Console.Write("\t\t" + addressData.State);
                    Console.Write("\t\t" + addressData.Zipcode);
                    Console.Write("\n");
                }

                // Writing to csv file
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}

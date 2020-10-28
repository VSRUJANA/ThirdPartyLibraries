namespace ThirdPartyLibrary_AddressBookDemo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using CsvHelper;
    using Newtonsoft.Json;
    using JsonSerializer = Newtonsoft.Json.JsonSerializer;

    public class JSONCsvManipulation
    {
        // Read From CSV File and Write to JSON File
        public static void ImplementCsvToJson()
        {
            string importFilePath = @"C:\Users\sajju2002\source\repos\ThirdPartyLibrary_AddressBookDemo\ThirdPartyLibrary_AddressBookDemo\Utility\Address.csv";
            string exportFilePath = @"C:\Users\sajju2002\source\repos\ThirdPartyLibrary_AddressBookDemo\ThirdPartyLibrary_AddressBookDemo\Utility\AddressDetails.json";
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

                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, records);
                }
            }
        }

        // Read From JSON File and Write to CSV File
        public static void ImplementJsonToCsv()
        {
            string importFilePath = @"C:\Users\sajju2002\source\repos\ThirdPartyLibrary_AddressBookDemo\ThirdPartyLibrary_AddressBookDemo\Utility\AddressDetails.json";
            string exportFilePath = @"C:\Users\sajju2002\source\repos\ThirdPartyLibrary_AddressBookDemo\ThirdPartyLibrary_AddressBookDemo\Utility\Address2.csv";
            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));
            Console.WriteLine("Reading from Json file and write to csv file");
            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(addressData);
            }
        }
    }
}

namespace ThirdPartyLibrary_AddressBookDemo
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            CsvHandler.ImplementCSVDataHandling();
            JSONCsvManipulation.ImplementCsvToJson();
            JSONCsvManipulation.ImplementJsonToCsv();
        }
    }
}

using AssetTracking.Models;

namespace AssetTracking
{
    // The main program class for the Asset Tracking application
    internal class Program
    {
        // The main entry point of the application
        private static void Main(string[] args)
        {
            // Create a list to hold the assets
            List<Asset> assets = new List<Asset>();
            assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2024, 03, 15), 1200m, 1300m, "USA", "Laptop"));
            assets.Add(new Computer("Lenovo", "ThinkPad", new DateTime(2023, 10, 01), 1500m, 1600m, "Sweden", "Laptop"));
            assets.Add(new Computer("Asus", "ZenBook", new DateTime(2023, 10, 01), 1500m, 1600m, "Turkey", "Laptop"));
            assets.Add(new MobilePhone("Apple", "iPhone 13", new DateTime(2025, 01, 10), 999m, 1050m, "Sweden"));
            assets.Add(new MobilePhone("Samsung", "Galaxy S21", new DateTime(2024, 12, 05), 899m, 950m, "Turkey"));
            assets.Add(new MobilePhone("Nokia", "C32", new DateTime(2024, 12, 05), 899m, 950m, "USA"));

            // Set the width of the table to 96 characters
            const int tableWidth = 96;
            // Print a header for the list of assets
            // Calculate the number of equals signs needed on each side of the header to center it
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('=', (tableWidth - "LIST OF ASSETS".Length) / 2) + "LIST OF ASSETS" + new string('=', (tableWidth - "LIST OF ASSETS".Length) / 2));
            Console.ResetColor();
            // Define a format string for the table rows, specifying the alignment and width of each column
            const string rowFormat = "{0,-12} {1,-14} {2,-14} {3,12} {4,14} {5,-12} {6,-12}";
            // Print a separator line of dashes to visually separate the header from the asset details
            Console.WriteLine(new string('-', tableWidth));
            // Print a header row with Brand, Model, Purchase Date, Price (USD), Price (Local), Office, and Asset Type using string formatting to align the columns
            Console.WriteLine(rowFormat, "Brand", "Model", "Purchase Date", "Price (USD)", "Price (Local)", "Office", "Asset Type");
            Console.WriteLine(new string('-', tableWidth));

            // Display the details of each asset in the list
            foreach (var asset in assets)
            {
                Console.WriteLine(rowFormat,
                    asset.Brand,
                    asset.Model,
                    asset.PurchaseDate.ToString("yyyy-MM-dd"),
                    asset.PriceUSD.ToString("F2"),
                    asset.PriceLocal.ToString("F2"),
                    asset.Office,
                    asset.AssetType);
            }
        }
    }
}
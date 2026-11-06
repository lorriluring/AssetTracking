using AssetTracking.Models;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace AssetTracking
{
    // The main program class for the Asset Tracking application
    internal class Program
    {
        // The main entry point of the application
        private static void Main(string[] args)
        {
            // Create a list to store assets, including computers and mobile phones with their respective properties
            List<Asset> assets = new List<Asset>();
            assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2024, 03, 15), 1200m, OfficeLocation.USA, "Laptop"));
            assets.Add(new Computer("Lenovo", "ThinkPad", new DateTime(2023, 10, 01), 1500m, OfficeLocation.Sweden, "Laptop"));
            assets.Add(new Computer("Asus", "ZenBook", new DateTime(2023, 10, 01), 1500m, OfficeLocation.Turkey, "Laptop"));
            assets.Add(new MobilePhone("Apple", "iPhone 13", new DateTime(2025, 01, 10), 999m, OfficeLocation.Sweden));
            assets.Add(new MobilePhone("Samsung", "Galaxy S21", new DateTime(2024, 12, 05), 899m, OfficeLocation.Turkey));
            assets.Add(new MobilePhone("Nokia", "C32", new DateTime(2024, 12, 05), 899m, OfficeLocation.USA));

            // Sort the assets first by Office, then by PurchaseDate, then by Brand, and lastly by Model. Chaining with  ThenBy for PurchaseDate.
            var sortedAssets = assets.OrderBy(a => a.Office.ToString()).ThenBy(a => a.PurchaseDate).ThenBy(a => a.Brand).ThenBy(a => a.Model).ToList();
            // Set the width of the table to 105 characters
            const int tableWidth = 105;

            // Calculate the number of equals signs needed on each side of the header to center it
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            // Define a title for the list of assets
            const string title = "LIST OF ASSETS";
            // Print the title centered within a line of equals signs, with the total width of the line being equal to tableWidth
            Console.WriteLine(title.PadLeft((tableWidth + title.Length) / 2, '=').PadRight(tableWidth, '='));
            Console.ResetColor();
            // Define a format string for the table rows, specifying the alignment and width of each column
            const string rowFormat = "{0,-12} {1,-12} {2,-14} {3,14} {4,12} {5,-14} {6,-12} {7,-8}";
            // Print a separator line of dashes to visually separate the header from the asset details
            Console.WriteLine(new string('-', tableWidth));
            // Print a header row with Office, Brand, Model, Purchase Date, Price (USD), Price (Local), Asset Type, and Status using string formatting to align the columns
            Console.WriteLine(rowFormat, "Office", "Brand", "Model", "Purchase Date", "Price (USD)", "Price (Local)", "Asset Type", "Status");
            Console.WriteLine(new string('-', tableWidth));

            // Display the details of each asset in the list
            foreach (var asset in sortedAssets)
            {
                // Get the status of the asset using the GetStatus method
                string status = asset.GetStatus();
                if (status == "RED")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                // Set the console text color to yellow if the asset status is "YELLOW"
                else if (status == "YELLOW")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                // Print the details of the asset in a formatted row, including Brand, Model, Purchase Date, Price (USD), Price (Local), Office, Asset Type, and Status
                Console.WriteLine(rowFormat,
                    asset.Office,
                    asset.Brand,
                    asset.Model,
                    asset.PurchaseDate.ToString("yyyy-MM-dd"),
                    asset.PriceUSD.ToString("F2", CultureInfo.InvariantCulture),
                    asset.PriceLocal.ToString("F2", CultureInfo.InvariantCulture) + " " + asset.CurrencyCode,
                    asset.AssetType,
                    status);
                Console.ResetColor();
            }
        }
    }
}
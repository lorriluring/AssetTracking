using AssetTracking.Models;
using System.Globalization;
using AssetTracking.Services;

namespace AssetTracking
{
    // The main program class for the Asset Tracking application
    internal class Program
    {
        // Set the width of the table
        private const int tableWidth = 119;

        // Define a title for the list of assets
        private const string title = "LIST OF ASSETS";

        // Define a format string for the table rows, specifying the alignment and width of each column
        private const string rowFormat = "{0,-4} {1,-12} {2,-12} {3,-14} {4,14} {5,12} {6,-14} {7,-12} {8,-8} {9,-8}";

        // Color used for the header of the table to distinguish it from the asset rows
        private static readonly ConsoleColor headerColor = ConsoleColor.DarkYellow;

        // The main entry point of the application
        private static void Main(string[] args)
        {
            // Create the service, which owns the data
            AssetService service = new AssetService();

            // Controls the menu loop, false ends the program
            bool running = true;
            // Main menu loop that continues until the user chooses to exit
            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(new string('=', 50));
                Console.WriteLine("ASSET TRACKING SYSTEM");
                Console.WriteLine(new string('=', 50));
                Console.ResetColor();
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("2. View Assets");
                Console.WriteLine("3. Sort Assets");
                Console.WriteLine("4. Search Assets");
                Console.WriteLine("5. Remove Asset");
                Console.WriteLine("6. Exit");
                Console.Write("Select option: ");
                string? choice = Console.ReadLine();

                // Handle the user's menu choice using a switch statement
                switch (choice)
                {
                    case "1":
                        AddAsset(service);
                        break;

                    case "2":
                        PrintAssets(service.GetAssetsSortedByTypeAndDate());
                        break;

                    case "3":
                        SortMenu(service);
                        break;

                    case "4":
                        SearchMenu(service);
                        break;

                    case "5":
                        RemoveMenu(service);
                        break;

                    case "6":
                        running = false;
                        break;
                    // Handle invalid menu choices by displaying an error message
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();
                        break;
                }
                // Prompt the user to press any key to continue if the program is still running
                if (running)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }

        // Prints the list of assets in a formatted table
        private static void PrintAssets(List<Asset> assets)
        {
            Console.ForegroundColor = headerColor;
            Console.WriteLine(title.PadLeft((tableWidth + title.Length) / 2, '=').PadRight(tableWidth, '='));
            Console.ResetColor();

            // Print a separator line of dashes to visually separate the header from the asset details
            Console.WriteLine(new string('-', tableWidth));
            // Print a header row with Office, Brand, Model, Purchase Date, Price (USD), Price (Local), Asset Type, and Status using string formatting to align the columns
            Console.WriteLine(rowFormat, "Id", "Office", "Brand", "Model", "Purchase Date", "Price (USD)", "Price (Local)", "Asset Type", "Status", "Age");
            Console.WriteLine(new string('-', tableWidth));

            // Display the details of each asset in the list
            foreach (var asset in assets)
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

                // Print the details of the asset in a formatted row, including Brand, Model, Purchase Date, Price (USD), Price (Local), Office, Asset Type, Status and Id.
                Console.WriteLine(rowFormat,
                    asset.Id,
                    asset.Office,
                    asset.Brand,
                    asset.Model,
                    asset.PurchaseDate.ToString("yyyy-MM-dd"),
                    asset.PriceUSD.ToString("F2", CultureInfo.InvariantCulture),
                    asset.PriceLocal.ToString("F2", CultureInfo.InvariantCulture) + " " + asset.CurrencyCode,
                    asset.AssetType,
                    status,
                    asset.GetAgeText());
                Console.ResetColor();
            }
        }

        // Reads a date from the console input, prompting the user until a valid date is entered
        private static DateTime ReadDate(string prompt)
        {
            // Continuously prompt the user for a date until a valid date is entered
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime date))
                {
                    return date;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                    Console.ResetColor();
                }
            }
        }

        // Reads a decimal value from the console input, prompting the user until a valid decimal is entered
        private static decimal ReadDecimal(string prompt)
        {
            // Continuously prompt the user for a decimal value until a valid value is entered
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value))
                {
                    return value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid format. Please use numbers such as 1234.56");
                    Console.ResetColor();
                }
            }
        }

        // Adds a new asset to the service by prompting the user for asset details
        private static void AddAsset(AssetService service)
        {
            Console.WriteLine("Select asset type:");
            Console.WriteLine("1. Laptop");
            Console.WriteLine("2. Desktop");
            Console.WriteLine("3. Phone");
            Console.WriteLine("4. Tablet");
            // Prompt the user to select an asset type and read the input
            Console.Write("Select type: ");
            string? typeChoice = Console.ReadLine();
            // Prompt the user for the brand
            Console.Write("Brand: ");
            string? brand = Console.ReadLine() ?? "";
            // Prompt the user for the model
            Console.Write("Model: ");
            string? model = Console.ReadLine() ?? "";
            // Prompt the user for the purchase date and read it using the ReadDate method
            DateTime purchaseDate = ReadDate("Purchase Date (yyyy-MM-dd): ");
            decimal priceUSD = ReadDecimal("Price (USD): ");
            // Prompt the user to select an office and read the input
            Console.WriteLine("Select office:");
            Console.WriteLine("1. Sweden");
            Console.WriteLine("2. USA");
            Console.WriteLine("3. Turkey");
            Console.Write("Choice: ");
            string? officeChoice = Console.ReadLine();
            // Declare OfficeLocation office. Set it with a switch expression on officeChoice. _ gives OfficeLocation.Sweden as a default.
            OfficeLocation office = officeChoice switch
            {
                "1" => OfficeLocation.Sweden,
                "2" => OfficeLocation.USA,
                "3" => OfficeLocation.Turkey,
                _ => OfficeLocation.Sweden
            };
            // Pick the asset class from the typeChoice, null for an invalid type.
            Asset? asset = typeChoice
                // Use a switch expression to create the appropriate asset based on the user's type choice
                switch
            {
                "1" => new Computer(brand, model, purchaseDate, priceUSD, office, "Laptop"),

                "2" => new Computer(brand, model, purchaseDate, priceUSD, office, "Desktop"),

                "3" => new MobilePhone(brand, model, purchaseDate, priceUSD, office),

                "4" => new Tablet(brand, model, purchaseDate, priceUSD, office),

                _ => null
            };
            // If the asset is not null, add it to the service and print "Asset added!", otherwise print "Invalid type, asset not added"
            if (asset != null)
            {
                service.AddAsset(asset);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Added {asset.GetDescription()}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid type, asset not added");
                Console.ResetColor();
            }
        }

        // Displays a menu for sorting assets and handles the user's choice
        private static void SortMenu(AssetService service)
        {
            Console.WriteLine("1. Type then Purchase Date");
            Console.WriteLine("2. Office then Purchase Date");
            Console.Write("Select sorting: ");
            string? sortChoice = Console.ReadLine();
            if (sortChoice == "1")
            {
                PrintAssets(service.GetAssetsSortedByTypeAndDate());
            }
            else if (sortChoice == "2")
            {
                PrintAssets(service.GetAssetsSortedByOfficeAndDate());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option.");
                Console.ResetColor();
            }
        }

        // Displays a menu for searching assets and handles the user's search query

        private static void SearchMenu(AssetService service)
        {
            Console.Write("Enter search query (brand or model): ");
            string text = Console.ReadLine() ?? "";
            List<Asset> results = service.Search(text);
            if (results.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No assets found.");
                Console.ResetColor();
            }
            else
            {
                PrintAssets(results);
            }
        }

        // Displays a menu for removing an asset and handles the user's choice
        private static void RemoveMenu(AssetService service)
        {
            PrintAssets(service.GetAll());
            Console.Write("ID to remove: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                if (service.RemoveAsset(id))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Asset with ID {id} removed.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"No asset found with ID {id}.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID.");
                Console.ResetColor();
            }
        }
    }
}
using System;

namespace AssetTracking.Models
{
    public class Asset
    {
        // Define a constant for the lifespan of an asset in years
        private const int LifespanYears = 3;

        // Define constants for the number of months to determine the status of an asset
        private const int RedMonths = 3;

        // Same as RedMonths, but for yellow status
        private const int YellowMonths = 6;

        // Initializes a new instance of the Asset class with the specified properties
        public Asset(string brand, string model, DateTime purchaseDate, decimal priceUSD, decimal priceLocal, string office, string assetType)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
            PriceLocal = priceLocal;
            Office = office;
            AssetType = assetType;
        }

        // Determines the status of the asset based on its purchase date and lifespan
        public string GetStatus()
        {
            // Calculate the end of life date by adding the lifespan to the purchase date
            DateTime endOfLife = PurchaseDate.AddYears(LifespanYears);
            // Get today's date for comparison
            DateTime today = DateTime.Today;
            // Check if the asset is past its end of life date returning "RED" if it is less than or equal to RedMonths from today
            if (endOfLife <= today.AddMonths(RedMonths))
            {
                return "RED";
            }
            // Check if the asset is within YellowMonths of its end of life date returning "YELLOW" if it is
            if (endOfLife <= today.AddMonths(YellowMonths))
            {
                return "YELLOW";
            }
            // Check if the asset is still within YellowMonths of its end of life date returning nothing if it is not
            return string.Empty;
        }

        // Gets or sets the brand of the asset
        public string Brand { get; set; }

        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal PriceLocal { get; set; }
        public string Office { get; set; }
        public string AssetType { get; set; }
    }
}
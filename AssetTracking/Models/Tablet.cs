using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.Models
{
    // Represents a tablet asset
    internal class Tablet : Asset
    {
        // Initializes a new instance of the Tablet class with the specified properties
        public Tablet(string brand, string model, DateTime purchaseDate, decimal priceUSD, OfficeLocation office)
            : base(brand, model, purchaseDate, priceUSD, office, "Tablet")
        {
        }

        // Overrides the GetDescription method to provide a description of the tablet asset
        public override string GetDescription()
        {
            return $"{Brand} {Model}, Tablet";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.Models
{
    // Represents a computer asset
    internal class Computer : Asset
    {
        // Initializes a new instance of the Computer class with the specified properties
        public Computer(string brand, string model, DateTime purchaseDate, decimal priceUSD, OfficeLocation office, string assetType)
            : base(brand, model, purchaseDate, priceUSD, office, assetType)
        {
        }

        // Overrides the GetDescription method to provide a description of the computer asset
        public override string GetDescription()
        {
            return $"{Brand} {Model}, {AssetType}";
        }
    }
}
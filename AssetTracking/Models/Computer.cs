using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.Models
{
    // Represents a computer asset
    internal class Computer : Asset
    {
        // Initializes a new instance of the Computer class with the specified properties
        public Computer(string brand, string model, DateTime purchaseDate, decimal priceUSD, decimal priceLocal, string office, string assetType)
            : base(brand, model, purchaseDate, priceUSD, priceLocal, office, assetType)
        {
        }
    }
}
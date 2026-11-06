using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.Models
{
    // Represents a mobile phone asset
    internal class MobilePhone : Asset
    {
        // Initializes a new instance of the MobilePhone class with the specified properties
        public MobilePhone(string brand, string model, DateTime purchaseDate, decimal priceUSD, decimal priceLocal, string office)
            : base(brand, model, purchaseDate, priceUSD, priceLocal, office, "Phone")
        {
        }
    }
}
using System;
using System.Collections.Generic;
using AssetTracking.Services;

namespace AssetTracking.Models
{
    public abstract class Asset
    {
        // Define a constant for the lifespan of an asset in years
        private const int LifespanYears = 3;

        // Define constants for the number of months to determine the status of an asset
        private const int RedMonths = 3;

        // Same as RedMonths, but for yellow status
        private const int YellowMonths = 6;

        // Initializes a new instance of the Asset class with the specified properties
        public Asset(string brand, string model, DateTime purchaseDate, decimal priceUSD, OfficeLocation office, string assetType)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
            Office = office;
            AssetType = assetType;
            Id = nextId++;
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

        // A static field to keep track of the next unique ID for assets
        private static int nextId = 1;

        // A read-only property that gets the unique ID of the asset
        public int Id { get; }

        // An abstract method that must be implemented by derived classes to provide a description of the asset
        public abstract string GetDescription();

        // Gets or sets the brand of the asset
        public string Brand { get; set; }

        // Gets or sets the model of the asset
        public string Model { get; set; }

        // Gets or sets the purchase date of the asset
        public DateTime PurchaseDate { get; set; }

        // Gets or sets the price of the asset in USD
        public decimal PriceUSD { get; set; }

        // A read-only property that converts the price from USD to the local currency based on the office location using the CurrencyService
        public decimal PriceLocal => CurrencyService.ConvertFromUSD(PriceUSD, Office);

        // A read-only property that retrieves the currency code for the office location using the CurrencyService
        public string CurrencyCode => CurrencyService.GetCurrencyCode(Office);

        // Gets or sets the office location of the asset
        public OfficeLocation Office { get; set; }

        // Gets or sets the type of the asset (e.g., Laptop, Phone)
        public string AssetType { get; set; }

        // Calculates the age of the asset in months based on the purchase date and today's date
        public int GetAgeInMonths()
        {
            DateTime today = DateTime.Today;
            int ageInMonths = (today.Year - PurchaseDate.Year) * 12 + today.Month - PurchaseDate.Month;
            if (today.Day < PurchaseDate.Day)
            {
                ageInMonths--;
            }
            return ageInMonths;
        }

        // Divide GetAgeInMonths() by 12 to get the years. Use the % operator to get the remaining months. Display in table as "X years Y months".
        public string GetAgeText()
        {
            int ageInMonths = GetAgeInMonths();
            int years = ageInMonths / 12;
            int months = ageInMonths % 12;
            return $"{years}y {months}m";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AssetTracking.Models;

namespace AssetTracking.Services
{
    public static class CurrencyService
    {
        // Method that takes an OfficeLocation and returns a string representing the currency code for that location
        public static string GetCurrencyCode(OfficeLocation location)
        {
            // A switch expression with three different cases for the OfficeLocation enum
            switch (location)
            {
                case OfficeLocation.Sweden:
                    return "SEK";

                case OfficeLocation.USA:
                    return "USD";

                case OfficeLocation.Turkey:
                    return "TRY";

                // Default case to handle unexpected OfficeLocation values
                default:
                    throw new ArgumentOutOfRangeException(nameof(location), location, null);
            }
        }

        // Method that takes an amount in USD and an OfficeLocation, and returns the equivalent amount in the local currency
        public static decimal ConvertFromUSD(decimal amount, OfficeLocation location)
        {
            switch (location)
            {
                // Hardcoded conversion rates for each office location as of the sixth of November 2026.
                case OfficeLocation.Sweden:
                    // Conversion rate from USD to SEK
                    return amount * 9.88m;
                // No conversion needed for USD, so return the original amount
                case OfficeLocation.USA:
                    return amount;
                // Conversion rate from USD to TRY
                case OfficeLocation.Turkey:
                    return amount * 50.15m;

                // Default case to handle unexpected OfficeLocation values
                default:
                    throw new ArgumentOutOfRangeException(nameof(location), location, null);
            }
        }
    }
}
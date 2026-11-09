using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using AssetTracking.Models;
using System.Linq;

namespace AssetTracking.Services
{
    // Represents a service for managing assets
    public class AssetService
    {
        // A private list to store the assets managed by the service
        private readonly List<Asset> assets = new List<Asset>();

        // Initializes a new instance of the AssetService class and seeds it with initial assets
        public AssetService()
        {
            // Seed the service with initial assets
            Seed();
        }

        // Fills the list with 6 sample assets
        private void Seed()
        {
            assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2024, 03, 15), 1200m, OfficeLocation.USA, "Laptop"));

            assets.Add(new Computer("Lenovo", "ThinkPad", new DateTime(2023, 10, 01), 1500m, OfficeLocation.Sweden, "Laptop"));

            assets.Add(new Computer("Asus", "ZenBook", new DateTime(2023, 10, 01), 1500m, OfficeLocation.Turkey, "Laptop"));

            assets.Add(new MobilePhone("Apple", "iPhone 13", new DateTime(2025, 01, 10), 999m, OfficeLocation.Sweden));

            assets.Add(new MobilePhone("Samsung", "Galaxy S21", new DateTime(2024, 12, 05), 899m, OfficeLocation.Turkey));

            assets.Add(new MobilePhone("Nokia", "C32", new DateTime(2024, 12, 05), 899m, OfficeLocation.USA));
        }

        // Adds a new asset to the service's list of assets
        public void AddAsset(Asset asset)
        {
            assets.Add(asset);
        }

        // Removes an asset from the service's list of assets by its ID. Returns true if the asset was found and removed, false otherwise.
        public bool RemoveAsset(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);
            if (asset == null)
            {
                return false;
            }
            assets.Remove(asset);
            return true;
        }

        // Gets a list of all assets managed by the service
        public List<Asset> GetAll()
        {
            return new List<Asset>(assets);
        }

        // Searches for assets by brand or model, returning a list of matching assets
        public List<Asset> Search(string query)
        {
            return assets.Where(a => a.Brand.Contains(query, StringComparison.OrdinalIgnoreCase) || a.Model.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Returns the assets sorted by type then purchase date
        public List<Asset> GetAssetsSortedByTypeAndDate()
        {
            return assets.OrderBy(a => a.AssetType).ThenBy(a => a.PurchaseDate).ThenBy(a => a.Brand).ThenBy(a => a.Model).ToList();
        }

        // Returns the assets sorted by office then purchase date
        public List<Asset> GetAssetsSortedByOfficeAndDate()
        {
            return assets.OrderBy(a => a.Office.ToString()).ThenBy(a => a.PurchaseDate).ThenBy(a => a.Brand).ThenBy(a => a.Model).ToList();
        }
    }
}
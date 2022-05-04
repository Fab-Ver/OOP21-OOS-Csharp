using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RacheleMargutti.Shop
{
    class ShopModel : IShopModel
    {
        private readonly Statistics _statistics;
        private readonly MysteryBox _mysteryBox;
        private ShopItem _selectedSkin;
        private const string FILE_NAME = "OOS_shopItems.txt";
        private const string SELECTED_SKIN_FILE_NAME = "OOS_selectedSkin.txt";

        public ShopModel(Statistics stats)
        {
            _statistics = stats;
            _mysteryBox = new MysteryBox();
            Items = Skins.Values.Select(s => new ShopItem(s.SkinName, s.Price)).ToList();
            ReadPurchasedItems();
            try
            {
                _selectedSkin = ReadSelectedSkin();
            }
            catch
            {
                _selectedSkin = FindShopItemFromString("Player.png");
            }
            PurchasedItems.Add(FindShopItemFromString("Player.png"));
        }

        public int TotalCoins { get; }

        public List<ShopItem> Items { get; }

        public List<ShopItem> PurchasedItems { get; private set; } = new List<ShopItem>();

        public bool CheckMystery(MysteryBox box, int coins) => box.Price <= coins;

        public bool CheckPayment(ShopItem selectedItem, int coins) => 
            !PurchasedItems.Contains(selectedItem) && selectedItem.Price <= coins;

        public string MysteryBoxPayment()
        {
            if (CheckMystery(_mysteryBox, _statistics.TotalCoins))
            {
                PurchaseBox(_mysteryBox);
                return _mysteryBox.CreatePrize(_statistics);
            }
            return "";
        }

        public void SaveShopItem()
        {
            string content = string.Join('\n', Items.Select(item => PurchasedItems.Contains(item) ? "1" : "0"));
            try
            {
                File.WriteAllText(FilePathInUserDirectory(FILE_NAME), content);
            }
            catch
            {
                Console.WriteLine("Error in SaveShopItem");
            }
        }

        public void ShopItemPayment(ShopItem selectedItem)
        {
            if (CheckPayment(selectedItem, _statistics.TotalCoins))
            {
                PurchaseSkin(selectedItem);
            }
        }

        public void WriteSkinsOnFile()
        {
            try
            {
                File.WriteAllText(FilePathInUserDirectory(SELECTED_SKIN_FILE_NAME), _selectedSkin.Name);
            }
            catch
            {
                Console.WriteLine("Error in WriteSkinOnFile");
            }
            
        }

        public bool IsSelected(string name)
        {
            return _selectedSkin.Name == name;
        }

        public void SelectSkin(string name)
        {
            _selectedSkin = FindShopItemFromString(name);
        }

        /// <summary>
        /// Reads the purchased items from file. 
        /// </summary>
        private void ReadPurchasedItems()
        {
            try
            {
                var purchased = File.ReadAllText(FilePathInUserDirectory(FILE_NAME)).Split('\n');
                PurchasedItems = purchased.Zip(Items).Where(t => t.First == "1").Select(t => t.Second).ToList();
            }
            catch
            {
                PurchasedItems = new List<ShopItem>();
            }
        }

        /// <summary>
        /// Finds the selected ShopItem from its name. 
        /// </summary>
        /// <param name="name">the name of the ShopItem</param>
        /// <returns>the ShopItem</returns>
        private ShopItem FindShopItemFromString(string name)
        {
            return Items.First(item => item.Name == name);
        }

        /// <summary>
        /// Purchases the selected skin updating the player's total coins. 
        /// </summary>
        /// <param name="selectedItem">The selected item</param>
        private void PurchaseSkin(ShopItem selectedItem)
        {
            selectedItem.Purchase();
            _statistics.TotalCoins -= selectedItem.Price;
            PurchasedItems.Add(selectedItem);
        }

        /// <summary>
        /// Purchases the MysteryBox updating the player's total coins.
        /// </summary>
        /// <param name="box">the MysteryBox</param>
        private void PurchaseBox(MysteryBox box)
        {
            if (CheckMystery(box, _statistics.TotalCoins))
            {
                _statistics.TotalCoins -= box.Price;
            }
        }

        /// <summary>
        /// Reads from file which is the selected skin. 
        /// </summary>
        /// <returns>the selected skins</returns>
        private ShopItem ReadSelectedSkin()
        {
            string stringName;
            try
            {
                stringName = File.ReadAllText(FilePathInUserDirectory(SELECTED_SKIN_FILE_NAME));
            } 
            catch
            {
                stringName = "Player.png";
            }
            return FindShopItemFromString(stringName);
        }

        /// <summary>
        /// Creates the complete file path.
        /// </summary>
        /// <param name="name">The file name</param>
        /// <returns>The complete File path</returns>
        private string FilePathInUserDirectory(string name)
        {
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return Path.Combine(userPath, name);
        }
    }
}

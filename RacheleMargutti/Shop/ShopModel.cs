using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RacheleMargutti.Shop
{
    class ShopModel : IShopModel
    {
        private readonly Statistics _statistics;
        private readonly MysteryBox _mysteryBox;
        private ShopItem _selectedSkin;
        private const string FILE_NAME = "OOS_shopItems.txt";

        public ShopModel(Statistics stats)
        {
            _statistics = stats;
            _mysteryBox = new MysteryBox();
            Items = Skins.Values.Select(s => new ShopItem(s.SkinName, s.Price)).ToList();
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
            
        }

        public bool IsSelected(string name)
        {
            return _selectedSkin.Name.Equals(name);
        }

        public void SelectSkin(string name)
        {
            _selectedSkin = FindShopItemFromString(name);
        }

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

        private ShopItem FindShopItemFromString(string name)
        {
            return Items.First(item => item.Name == name);
        }

        private void PurchaseSkin(ShopItem selectedItem)
        {
            selectedItem.Purchase();
            _statistics.TotalCoins -= selectedItem.Price;
            PurchasedItems.Add(selectedItem);
            //TRY CATCH
        }

        private void PurchaseBox(MysteryBox box)
        {
            if (CheckMystery(box, _statistics.TotalCoins))
            {
                _statistics.TotalCoins -= box.Price;
                //TRY CATCH
            }
        }

        private string FilePathInUserDirectory(string name)
        {
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return Path.Combine(userPath, name);
        }
    }
}

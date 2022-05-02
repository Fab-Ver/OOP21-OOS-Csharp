using System;
using System.Collections.Generic;
using System.Text;

namespace RacheleMargutti.Shop
{
    interface IShopModel
    {
        void ShopItemPayment(ShopItem selectedItem);

        string MysteryBoxPayment();

        int TotalCoins { get; }

        List<ShopItem> Items { get; }

        List<ShopItem> PurchasedItems { get; }

        void SaveShopItem();

        bool CheckMystery(MysteryBox box, int coins);

        bool CheckPayment(ShopItem selectedItem, int coins);

        void WriteSkinsOnFile();

        bool IsSelected(string name);

        void SelectSkin(string name);
    }
}

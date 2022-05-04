using System;
using System.Collections.Generic;
using System.Text;

namespace RacheleMargutti.Shop
{
    /// <summary>
    /// Interface that describes how the Shop works.
    /// </summary>
    interface IShopModel
    {
        /// <summary>
        /// If the player has enough money, update the player properties.
        /// </summary>
        /// <param name="selectedItem">The item chosen by the player</param>
        void ShopItemPayment(ShopItem selectedItem);

        /// <summary>
        /// If the player has enough money. 
        /// </summary>
        /// <returns>the result string</returns>
        string MysteryBoxPayment();

        /// <summary>
        /// The total amount of coins from statistics.
        /// </summary>
        int TotalCoins { get; }

        /// <summary>
        /// All of the items in the shop
        /// </summary>
        List<ShopItem> Items { get; }

        /// <summary>
        /// All of the purchased items.
        /// </summary>
        List<ShopItem> PurchasedItems { get; }

        /// <summary>
        /// Saves the Shop Items on file.
        /// </summary>
        void SaveShopItem();

        /// <summary>
        /// Checks if the player can buy a MysteryBox. 
        /// </summary>
        /// <param name="box">the MysteryBox</param>
        /// <param name="coins">the total coins of the player</param>
        /// <returns>if the MysteryBox can be bought or not</returns>
        bool CheckMystery(MysteryBox box, int coins);

        /// <summary>
        /// Checks if the player can buy a ShopItem. 
        /// </summary>
        /// <param name="selectedItem">the item selected by the player</param>
        /// <param name="coins">the total coins of the player</param>
        /// <returns>if the ShopItem can be bought or not</returns>
        bool CheckPayment(ShopItem selectedItem, int coins);

        /// <summary>
        /// Writes the skin's name on file. 
        /// </summary>
        void WriteSkinsOnFile();

        /// <summary>
        /// Checks if the current item is selected for the next game.
        /// </summary>
        /// <param name="name">the name of the selected item by the player</param>
        /// <returns>if the selected item is selected or not</returns>
        bool IsSelected(string name);

        /// <summary>
        /// Sets the selected item for the next game. 
        /// </summary>
        /// <param name="name">the name of the selected item by the player</param>
        void SelectSkin(string name);
    }
}

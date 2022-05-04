namespace RacheleMargutti.Shop
{
    /// <summary>
    /// Interface that describes a ShopItem sold in the shop.
    /// </summary>
    interface IShopItem
    {
        /// <summary>
        /// Returns if the item is purchased.
        /// </summary>
        bool IsPurchased { get; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The price of the item.
        /// </summary>
        int Price { get; }

        /// <summary>
        /// Allows to buy the item.
        /// </summary>
        void Purchase();
    }
}

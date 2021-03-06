namespace RacheleMargutti.Shop
{
    /// <summary>
    /// The class identifying the ShopItem sold in the shop.
    /// </summary>
    class ShopItem : IShopItem
    {
        public ShopItem(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public int Price { get; }

        public void Purchase() => IsPurchased = true;

        public bool IsPurchased { get; private set; } = false;
    }
}

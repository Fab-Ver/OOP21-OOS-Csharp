namespace RacheleMargutti.Shop
{
    interface IShopItem
    {
        bool IsPurchased { get; }
        string Name { get; }
        int Price { get; }

        void Purchase();
    }
}

namespace RacheleMargutti.Shop
{
    interface IMysteryBox
    {
        int Price { get; }

        string CreatePrize(Statistics stats);
    }
}

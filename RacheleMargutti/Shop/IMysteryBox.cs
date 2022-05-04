namespace RacheleMargutti.Shop
{
    /// <summary>
    /// Interface that describes the MysteryBox sold in the shop.
    /// </summary>
    interface IMysteryBox
    {
        /// <summary>
        /// The price of the box.
        /// </summary>
        int Price { get; }

        /// <summary>
        /// Create the prize of the mystery box, choosing between four different options.
        /// </summary>
        /// <param name="stats">the game statistics</param>
        /// <returns>the string with the prize message</returns>
        string CreatePrize(Statistics stats);
    }
}

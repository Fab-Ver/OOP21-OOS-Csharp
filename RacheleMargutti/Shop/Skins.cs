using System;
using System.Collections.Generic;
using System.Text;

namespace RacheleMargutti.Shop
{
    /// <summary>
    /// Class identifying the playable characters.
    /// </summary>
    class Skins
    {
        /// <summary>
        /// Default player's skin. 
        /// </summary>
        public static readonly Skins PLAYER = new Skins("Player.png", 0);

        /// <summary>
        ///  Programmer skin and its price.
        /// </summary>
        public static readonly Skins PROGRAMMER = new Skins("Programmer.png", 1000);

        /// <summary>
        /// Dinosaur skin and its price. 
        /// </summary>
        public static readonly Skins DINOSAUR = new Skins("Dinosaur.png", 2000);

        /// <summary>
        /// The values of the skins.
        /// </summary>
        public static IEnumerable<Skins> Values { get; } = new[] { PLAYER, PROGRAMMER, DINOSAUR };

        private Skins(string skinName, int price)
        {
            SkinName = skinName;
            Price = price;
        }

        /// <summary>
        /// The name of the skin.
        /// </summary>
        public string SkinName { get; }

        /// <summary>
        /// The price of the skin.
        /// </summary>
        public int Price { get; }
 
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RacheleMargutti.Shop
{
    class Skins
    {
        public static readonly Skins PLAYER = new Skins("Player.png", 0);
        public static readonly Skins PROGRAMMER = new Skins("Programmer.png", 1000);
        public static readonly Skins DINOSAUR = new Skins("Dinosaur.png", 2000);

        public static IEnumerable<Skins> Values { get; } = new[] { PLAYER, PROGRAMMER, DINOSAUR };

        private Skins(string skinName, int price)
        {
            SkinName = skinName;
            Price = price;
        }

        public string SkinName { get; }

        public int Price { get; }
 
    }
}

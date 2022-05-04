using NUnit.Framework;
using RacheleMargutti.Shop;

namespace Rachele_Margutti
{
    public class ShopTest
    {
        private ShopModel _shop;
        private MysteryBox _box;
        private ShopItem _item;

        private const int MONEY1 = 300;
        private const int MONEY2 = 50;
        private const int PRICE = 100;
        private const string NAME = "Skin";

        [SetUp]
        public void Setup()
        {
            _shop = new ShopModel(new Statistics());
            _box = new MysteryBox();
            _item = new ShopItem(NAME, PRICE);
        }

        [Test]
        public void TestCheckMystery()
        {
            Assert.True(_shop.CheckMystery(_box, MONEY1));
            Assert.False(_shop.CheckMystery(_box, MONEY2));
        }

        [Test]
        public void TestCheckPayment()
        {
            Assert.True(_shop.CheckPayment(_item, MONEY1));
            Assert.False(_shop.CheckPayment(_item, MONEY2));
        }
    }
}
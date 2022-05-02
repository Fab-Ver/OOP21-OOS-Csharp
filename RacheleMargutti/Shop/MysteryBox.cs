using System;

namespace RacheleMargutti.Shop
{
    class MysteryBox
    {
        private static readonly Random _rand = new Random();

        private const int BOX_PRICE = 200;
        private const int PRIZES_NUM = 3;
        private const int MONEY_PRIZE1 = 300;
        private const int MONEY_PRIZE2 = 150;
        private const int NO_PRIZE = 0;

        public int Price { get; } = BOX_PRICE;

        public string CreatePrize(Statistics stats)
        {
            int random = _rand.Next(PRIZES_NUM);
            var (message, prize) = random switch
            {
                0 => ("Congratulation! You won 300 coins!", MONEY_PRIZE1),
                1 => ("You can't always be lucky, you've just paid for nothing", NO_PRIZE),
                2 => ("Yeah! You've just gained 150 coins!!!", MONEY_PRIZE2),
                _ => ("Error: selected prize does not exist", NO_PRIZE),
            };
            stats.TotalCoins += prize;
            return message;
        }

    }
}

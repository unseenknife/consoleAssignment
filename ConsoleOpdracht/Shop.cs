using System;
using System.Threading;

namespace ConsoleOpdracht
{
    internal class Shop
    {

        private double _costSmall = 50d;

        private double _costLarge = 100d;

        public double Coins { get; set; }

        public double AttackMulti { get; private set; } = 25d;

        /// <summary>
        /// Opens the shop and its purchasable options.
        /// </summary>
        public void Main()
        {
            while (true)
            {
                Console.Clear();
                Show();
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        BuyItem(1);
                        break;
                    case "2":
                        BuyItem(2);
                        break;
                    case "3":
                        Assignment.StartBunny();
                        break;
                    default:
                        Console.WriteLine("This isn't a valid option");
                        Return();
                        Console.Write("You suck at buying items!");
                        Thread.Sleep(200);
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Returning screen.
        /// </summary>
        private static void Return()
        {
            Console.Write("Returning.");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
        }

        private static readonly Random Random = new Random();

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = Random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

        /// <summary>
        /// Buy's the item.
        /// </summary>
        /// <param name="size">The size of the item</param>
        private void BuyItem(int size)
        {
            if (size == 1 && Coins >= _costSmall)
            {
                Coins = Coins - _costSmall;
                AttackMulti = AttackMulti * RandomNumberBetween(1, 1.5);
                _costSmall = _costSmall * 1.5;
            
                Console.WriteLine("Your damage has been increased to {0}", Convert.ToInt32(AttackMulti));
                Return();

                Main();
            }

            if (size == 2 && Coins >= _costLarge)
            {
                Coins = Coins - (_costLarge);
                AttackMulti = AttackMulti * RandomNumberBetween(1.25 , 2);
                _costLarge = _costLarge * 2;

                Console.WriteLine("Your damage has been increased to {0}", Convert.ToInt32(AttackMulti));
                Return();
                Main();
            }

            else
            {
                Console.WriteLine("You do not have enough BunnyBucks");
                Return();
                Main();
            }


        }

        /// <summary>
        /// Shows the shop.
        /// </summary>
        private void Show()
        {
            Console.WriteLine("_____________                                                                               BunnyBucks: {0} \n" +
                              "____________ |\n" +
                              "            ||\n" +
                              "            ||\n" +
                              "            ||               ___________________________\n" +
                              "            ||              /                           \\\n" +
                              "            ||             |      Welcome to the shop! //\n" +
                              "            ||    _____    \\  ________________________//\n" +
                              "         ___||   /     \\/_  / /\n" +
                              "        |\\__||  //\\__(\\_\\  / /\n" +
                              "        || |||  |\\ ~~ ~~| |_/\n" +
                              "________||_|||  /|_O \\O_ \\\n" +
                              " \\_\\ \\_\\||_|||  \\_  (_)  /\n" +
                              "\\_\\_\\_\\_\\_\\_||__ \\   o  / ______________________\n" +
                              "______________ __/\\  ~ /\\__ _____________\n" +
                              "_____________ /  \\ \\  / /  \\ ____________\\\n" +
                              "             /    \\/\\/\\/    \\            |__\n" +
                              "            /        .   |   \\           \\  \\\n" +
                              "           /   /|    .   |    \\         | \\__\\\n" +
                              "              / |        | \\   \\        | |  |\n", Convert.ToInt32(Coins));


            Console.Write("\n" +
                          "___________________________________________________________________________________________________________\n\n" +
                          "1. Buy small Random damage boost ({0})\n" +
                          "2. Buy large Random damage boost ({1})\n" +
                          "3. Leave shop\n" +
                          "___________________________________________________________________________________________________________\n\n", Convert.ToInt32(_costSmall), Convert.ToInt32(_costLarge));
        }


    }
}

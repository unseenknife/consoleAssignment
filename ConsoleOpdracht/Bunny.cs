using System;
using System.Threading;

namespace ConsoleOpdracht
{
    internal class Bunny
    {
        private double _percent;
        private readonly Random _rnd = new Random();
        private readonly World _world = new World();
        private readonly Shop _shop = new Shop();
        private string _name = "Bunny";

        /// <summary>
        /// Start of the Bunny class.
        /// </summary>
        public void Main()
        {
            while (true)
            {
                Show();
                var input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        Rename();
                        break;
                    case "2":
                        Attack();
                        break;
                    case "3":
                        _shop.Main();
                        break;
                    case "4":
                        Program.Main();
                        break;
                    default:
                        Console.WriteLine("This isn't a valid option");
                        Return();
                        Console.Write("You suck at destroying worlds!");
                        Thread.Sleep(200);
                        continue;
                }
                break;
            }
        }

        /// <summary>
        /// Gives a short returning screen.
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

        /// <summary>
        /// Shows the bunny and options on the screen.
        /// </summary>
        private void Show()
        {
            Console.Clear();
            Console.Write("Engaging world: {0}         status: In Progress [{1}%/100%]             eta: ..Soon             BunnyBucks: {2}\n" +
                          "                       ____\n" +
                          "                      / /  \\\\\\                   Has the great laser eyed bunny : {3}\n" +
                          "                      \\ \\   \\\\\\                      destroyed the world yet?                 HP: {4}\n" +
                          "                       \\ \\   \\\\\\                                                              ________\n" +
                          "         ______________ \\ \\   \\\\\\__                                                          /        \\\n" +
                          " ____  _/                       (O)\\                                                        /          \\\n" +
                          "/    \\/                        ( __|                                                       |            |\n" +
                          "|____/               |      ------- \\\\                                                      \\          /\n" +
                          "     |______________/_______________//                                                       \\________/"
                          , _world.WorldCount, _percent, Convert.ToInt32(_shop.Coins), _name, Convert.ToInt32(_world.CurrentHealth));

            Console.Write("\n" +
                          "___________________________________________________________________________________________________________\n\n" +
                          "1. Rename the great laser eyed bunny {0}\n" +
                          "2. Attack the world\n" +
                          "3. Shop\n" +
                          "4. Retreat!\n" +
                          "___________________________________________________________________________________________________________\n\n"
                          , _name);
        }

        /// <summary>
        /// Changes the name of the bunny.
        /// </summary>
        private void Rename()
        {
            Console.WriteLine("Change name to:");
            _name = Console.ReadLine();
            Main();
        }

        /// <summary>
        /// As bunny do damage to the world.
        /// </summary>
        private void Attack()
        {
            const string attack = "";
            var spaceCounter = 56;
            var dashCounter = 0;
            const int offset = 7;
            for (var i = 0; i <= 8; i++)
            {
                Console.Clear();
                Console.Write("Engaging world: {0}         status: In Progress [{1}%/100%]             eta: ..Soon             BunnyBucks: {2}\n" +
                              "                       ____\n" +
                              "                      / /  \\\\\\                   Has the great laser eyed bunny : {3}\n" +
                              "                      \\ \\   \\\\\\                      destroyed the world yet?                 HP: {4}\n" +
                              "                       \\ \\   \\\\\\                                                              ________\n" +
                              "         ______________ \\ \\   \\\\\\__                                                          /        \\\n" +
                              " ____  _/                       (O)\\{5}{6}/          \\\n" +
                              "/    \\/                        ( __|                                                       |            |\n" +
                              "|____/               |      ------- \\\\                                                      \\          /\n" +
                              "     |______________/_______________//                                                       \\________/"
                              , _world.WorldCount, _percent, Convert.ToInt32(_shop.Coins), _name, Convert.ToInt32(_world.CurrentHealth), attack.PadRight(dashCounter, '-'), attack.PadRight(spaceCounter, ' '));
               
                dashCounter = dashCounter + offset;
                spaceCounter = spaceCounter - offset;
                
                Thread.Sleep(250);
            }

            // Declares a random number between 0 and the value of your AttackMulti.
            var randomDamage = _rnd.Next(0, Convert.ToInt32(_shop.AttackMulti));
            _world.CurrentHealth = _world.CurrentHealth - randomDamage;

            if (_world.CurrentHealth <= 0)
            {
                _shop.Coins = _shop.Coins + _world.CoinValue;
                _world.NextWorld();
            }

            _percent = Convert.ToInt32(100 - (_world.CurrentHealth / _world.Health * 100));
            
            Console.Clear();
            Console.WriteLine("You have inflicted {0} damage", randomDamage);

            Return();

            Main();
        }
    }
}

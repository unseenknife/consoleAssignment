using System;
using System.Text.RegularExpressions;
using System.Threading;
using Console = System.Console;
using Convert = System.Convert;

namespace ConsoleOpdracht
{
    internal class Assignment
    {
        private static readonly Bunny Bunny = new Bunny();
        private string _name;
        private string _operator;
        private string _number1 = "...";
        private string _number2 = "...";
        private double _answer;

    /*
     * Bunny.Main() can not be made static,
     * that's why we made a public static void StartBunny().
     * We made it static so bunny can return to assignment.
     */
    public static void StartBunny()
        {
            Bunny.Main();
        }

        /// <summary>
        /// Start of the Assignment class.
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
                        Calculate();
                        break;
                    case "3":
                        ShowName();
                        break;
                    case "4":
                        Console.Clear();
                        // Splits an input string into an array of substrings.
                        string[] _string = Regex.Split("Are you ready captain?", string.Empty);
                        foreach (string s in _string)
                        {
                            Console.Write(s);
                            Thread.Sleep(100);
                        }
                        Console.Write("\n\n");
                        Thread.Sleep(500);
                        Console.Write("ATTACK!");
                        Thread.Sleep(500);
                        StartBunny();
                        break;
                    case "5":
                        Environment.Exit(0);
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
        /// Shows the menu screen.
        /// </summary>
        private void Show()
        {
            Console.Clear();
            Console.Write("Welcome captain! Pick an action:\n" +
                          "___________________________________________________________________________________________________________\n\n" +
                          "1. Name the captain\n" +
                          "2. Calculator\n" +
                          "3. Show captains name\n" +
                          "4. Attack worlds\n" +
                          "5. Close!\n" +
                          "___________________________________________________________________________________________________________\n\n" +
                          "");
        }

        /// <summary>
        /// Changes the name of the captain.
        /// </summary>
        private void Rename()
        {
            Console.WriteLine("Change name to:");
            _name = Console.ReadLine();
            Main();
        }

        /// <summary>
        /// A calculator to calculate.
        /// </summary>
        private void Calculate()
        {
            Console.WriteLine("Pick the operator you like to use \n"+
                              "\n" +
                              "___________________________________________________________________________________________________________\n\n" +
                              "1. +\n" +
                              "2. -\n" +
                              "3. *\n" +
                              "4. /\n" +
                              "5. Return\n" +
                              "___________________________________________________________________________________________________________\n\n" +
                              "");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _operator = "+";
                    break;
                case "2":
                    _operator = "-";
                    break;
                case "3":
                    _operator = "*";
                    break;
                case "4":
                    _operator = "/";
                    break;
                case "5":
                    Return();
                    break;
                default:
                    Console.WriteLine("This isn't a valid option");
                    Return();
                    break;
            }
            Console.Clear();
            Console.WriteLine("Pick the first number you want to use in your calculation\nCalculation: {0} {1} {2}", _number1, _operator, _number2);
            _number1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Pick the second number you want to use in your calculation\nCalculation: {0} {1} {2}", _number1, _operator, _number2);
            _number2 = Console.ReadLine();
            Console.Clear();
            if (_number1 == "")
            {
                _number1 = "1";
            }

            if (_number2 == "")
            {
                _number2 = "1";
            }

            Console.WriteLine("Calculation: {0} {1} {2}\nPress enter for your answer", _number1, _operator, _number2);
            Console.ReadLine();
            Console.Clear();
            switch (_operator)
            {
                case "+":
                    _answer = Convert.ToDouble(_number1) + Convert.ToDouble(_number2);
                    break;
                case "-":
                    _answer = Convert.ToDouble(_number1) - Convert.ToDouble(_number2);
                    break;
                case "*":
                    _answer = Convert.ToDouble(_number1) * Convert.ToDouble(_number2);
                    break;
                case "/":
                    _answer = Convert.ToDouble(_number1) / Convert.ToDouble(_number2);
                    break;
            }
            _number1 = "...";
            _number2 = "...";
            Console.WriteLine("The answer is: {0}\nPress enter to exit", _answer);
            Console.ReadLine();
            Main();
        }

        /// <summary>
        /// Show the name of the captain.
        /// </summary>
        private void ShowName()
        {
            Console.WriteLine("Hello captain, your name is {0} \n\nPress enter to return", _name);
            Console.ReadLine();
            Main();
        }
    }
}
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace IntiveDotNet
{
    public class Program
    {
        /// <summary>
        /// If value of parameter is divisible by 2 or 3 or both, method returns respectively "Fizz", "Buzz" or "FizzBuzz".
        /// </summary>
        /// <param name="value">Number to be checked.</param>
        /// <returns>Fizz or Buzz or FizzBuzz</returns>
        public static string FizzBuzz(int value)
        {
            if (value < 0 || value > 1000)
            {
                throw new ArgumentException("Bad value for argument. Type value from 0 to 1000", nameof(value));
            }

            return $"{(value % 2 == 0 ? "Fizz" : String.Empty)}{(value % 3 == 0 ? "Buzz" : String.Empty)}";
        }

        public static void Main(string[] args)
        {
            DeepDive deepDive = new DeepDive();
            DrownItDown drownItDown = new DrownItDown(deepDive);

            //Main loop
            while (true)
            {
                WriteCenteredText("Made by: Jakub Stasiak");
                Console.WriteLine();

                Console.WriteLine("1. FizzBuzz");
                Console.WriteLine("2. DeepDive");
                Console.WriteLine("3. DrownItDown");
                Console.WriteLine("4. Exit");
                Console.WriteLine();

                char input = GetInputCharacter("Type number of function you want to execute: ", new[] {'1', '2', '3', '4'});

                switch (input)
                {
                    case '1':
                        Console.Clear();

                        Console.Write("1. FizzBuzz\nType number from 0 to 1000: ");
                        string result = String.Empty;

                        try
                        {
                            result = FizzBuzz(Int32.Parse(Console.ReadLine() ?? "-1"));
                        }
                        catch (Exception exception)
                        {
                            WriteColoredText(exception.Message, ConsoleColor.Red);
                        }
                        
                        Console.WriteLine(result);
                        break;
                    case '2':
                        Console.Clear();

                        Console.Write("2. DeepDive\nType level of directory tree (max. 4): ");

                        try
                        {
                            deepDive.Create((ushort) Int16.Parse(Console.ReadLine() ?? "10000"));
                            WriteColoredText("Directories created! You can use DrownItDown now.", ConsoleColor.Green);
                        }
                        catch (Exception exception)
                        {
                            WriteColoredText(exception.Message, ConsoleColor.Red);
                        }

                        break;
                    case '3':
                        Console.Clear();

                        Console.Write("3. DrownItDown\nType level in which file should be created: ");
                        ushort level = ushort.Parse(Console.ReadLine() ?? "10000");

                        Console.Write("Type name of file: ");
                        string name = Console.ReadLine();

                        try
                        {
                            drownItDown.Drown(name, level);
                            WriteColoredText("File created!", ConsoleColor.Green);
                        }
                        catch (Exception exception)
                        {
                            WriteColoredText(exception.Message, ConsoleColor.Red);
                        }

                        break;
                    case '4':
                        Environment.Exit(0);
                        break;
                }
            }
        }

        #region Helper methods

        private static char GetInputCharacter(string message, char[] inputButtons)
        {
            Console.Write(message);
            char input = Char.MinValue;
            Console.WriteLine();

            while (true)
            {
                input = Console.ReadKey().KeyChar;
                if (inputButtons.Contains(input))
                {
                    break;
                }
                
                ClearCurrentLine();
                WriteColoredText("Wrong input, try again.", ConsoleColor.Red);
            }

            return input;
        }

        private static void ClearCurrentLine()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }

        private static void WriteCenteredText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        private static void WriteColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion
    }
}

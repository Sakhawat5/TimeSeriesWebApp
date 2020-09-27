using StatsdClient;
using System;

namespace ConsoleApp1
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            var generator = new RandomGenerator();
            var randomNumber = generator.Re(5, 100);
            Console.WriteLine($"Random number between 5 and 100 is {randomNumber}");
            var randomString = generator.RandomString(10);
            Console.WriteLine($"Random string of 10 chars is {randomString}");

            var randomPassword = generator.RandomPassword();
            Console.WriteLine($"Random string of 6 chars is {randomPassword}");
        }
    }
}

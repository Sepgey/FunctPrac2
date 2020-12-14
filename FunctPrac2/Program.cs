using System;

namespace FunctPrac2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }
        
        // Task 1
        private static void Task1()
        {
            {
                Action<int[]> addition = numerals =>
                {
                    for (var i = 0; i < numerals.Length; i++)
                    {
                        numerals[i]++;
                    }
                };
                Action<int[]> multiplication = numerals =>
                {
                    for (var i = 0; i < numerals.Length; i++)
                    {
                        numerals[i] *= 2;
                    }
                };
                Action<int[]> subtraction = numerals =>
                {
                    for (var i = 0; i < numerals.Length; i++)
                    {
                        numerals[i]--;
                    }
                };
                Action<int[]> print = numerals => Console.WriteLine(string.Join(" ", numerals));

                Func<string, Action<int[]>> selector = command =>
                {
                    switch (command)
                    {
                        case "add":
                            return addition;
                        case "multiply":
                            return multiplication;
                        case "subtract":
                            return subtraction;
                        case "print":
                            return print;
                    }

                    return _ => { };
                };

                var line = Console.ReadLine();
                var strings = line.Split(' ');
                var numbers = lineParser(strings);

                while ((line = Console.ReadLine()) != "end")
                {
                    selector(line)(numbers);
                }
            }
        }
    }
}

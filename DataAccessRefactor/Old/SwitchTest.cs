using System;

namespace ConsoleApp1.Old
{
    public static class SwitchTest
    {
        private static void MainMethod(string[] args)
        {
            //int[] s = {1, 2, 3, 4};
            //PrintType(s);

            Console.WriteLine(GetStr(null));
        }

        private static void PrintType(object a)
        {
            switch (a)
            {
                case int i:
                    Console.WriteLine("It's an int!!! Value: {i}");
                    break;
                case string s:
                    Console.WriteLine($"It's a {s.Length} - character long string! The value: {s}");
                    break;
                case int[] ar when ar.Length < 5:
                    Console.WriteLine($"It's an array of {ar.Length} elements");
                    break;
            }
        }

        private static string GetStr(int? i)
        {
            return i switch
            {
                1 => "A",
                2 => "B",
                null => "C",
                _ => "none of those"
            };
        }
    }
}
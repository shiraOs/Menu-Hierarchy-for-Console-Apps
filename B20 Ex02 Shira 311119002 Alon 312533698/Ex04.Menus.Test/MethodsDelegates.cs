using System;

namespace Ex04.Menus.Test
{
    internal class MethodsDelegates
    {
        public static void CountCapitals()
        {
            Console.WriteLine("Please enter your sentence:");
            string input = Console.ReadLine();
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    count++;
                }
            }

            Console.WriteLine("There are {0} upper case letters in your sentence.", count);
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }

        public static void ShowTime()
        {            
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        public static void ShowDate()
        {           
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }        
    }
}
using System;
using BerlinClockLib;

namespace ShowMe
{
    class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var mengelHeur = DateTime.Now.ToString("HH:mm:ss").toMengelHeur();
                Ascii(mengelHeur);
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static void Ascii(string clock)
        {

            //                  222222222                  
            //|===========================================|
            //|1111111111|2222222222|3333333333|4444444444|
            //|===========================================|
            //|1111111111|2222222222|3333333333|4444444444|
            //|===========================================|
            //|11a|a22|3a3|4a4|5a5|6aq|7aq|8aq|9aq|0aq|1aq|
            //|===========================================|
            //|1111111111|2222222222|3333333333|4444444444|
            Console.Clear();

            var lines = clock.Replace(Environment.NewLine, ":").Split(':');

            Seconds(lines[0]);
            Console.WriteLine("|===========================================|");
            Hours(lines[1]);
            Console.WriteLine("|===========================================|");
            Hours(lines[2]);
            Console.WriteLine("|===========================================|");
            Minutes(lines[3]);
            Console.WriteLine("|===========================================|");
            Hours(lines[4]);
            Console.WriteLine("|===========================================|");
        }

        private static void Hours(string quarters)
        {
            foreach (var c in quarters.ToCharArray())
            {
                Pipe();
                Writer.Write(c == 'R' ? ConsoleColor.Red : ConsoleColor.Black, "          ");
            }
            Pipe();
            Console.WriteLine();
        }

        private static void Minutes(string minutes)
        {
            foreach (var c in minutes.ToCharArray())
            {
                Pipe();
                var color = ConsoleColor.Black;
                if (c == 'R')
                    color = ConsoleColor.Red;
                if (c == 'Y')
                    color = ConsoleColor.Yellow;
                Writer.Write(color, "   ");
            }
            Pipe();
            Console.WriteLine();
        }

        private static void Seconds(string seconds)
        {
            Writer.Write(ConsoleColor.Black, "               ");
            Pipe();
            Writer.Write(seconds == "Y" ? ConsoleColor.Yellow : ConsoleColor.Black, "             ");
            Pipe();
            Writer.Write(ConsoleColor.Black, "               ");
            Console.WriteLine();
        }

        private static void Pipe()
        {
            Console.Write("|");
        }
    }

    public static class Writer
    {
        public static void Write(ConsoleColor color, string input)
        {
            var backgroundColor = Console.BackgroundColor;
            var foregroundColor = Console.ForegroundColor;
            Console.BackgroundColor = color;
            Console.ForegroundColor = color;
            Console.Write(input);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
    }
}

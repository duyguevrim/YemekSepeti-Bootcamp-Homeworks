using inheritance_example.Classes;
using System;

namespace inheritance_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Dikdortgen dikdortgen = new Dikdortgen();
            dikdortgen.width = 5;
            dikdortgen.height = 12;

            dikdortgen.Goster();
            Console.WriteLine("Dikdörtgenin alanı: " + dikdortgen.Alan());
        }
    }
}

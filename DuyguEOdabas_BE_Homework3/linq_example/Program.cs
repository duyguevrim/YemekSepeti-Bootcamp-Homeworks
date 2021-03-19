using System;
using System.Linq;

namespace linq_example
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Duygu", "Evrim", "Gonca", "Yağmur" };

            var myLinqQuery = from name in names
                              where name.Contains('i')
                              select name;

            foreach (var name in myLinqQuery)
                Console.Write(name + " ");
        }
    }
}

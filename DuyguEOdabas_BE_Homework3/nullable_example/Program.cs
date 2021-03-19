using System;

namespace nullable_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> i = null;

            if (i.HasValue)
                Console.WriteLine(i.Value);
            else
                Console.WriteLine("Null");
        }
    }
}

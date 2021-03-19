using System;

namespace delegate_exercises
{
    class Program
    {
        public delegate int SimpleDelegate(int number1, int number2);
        
        static void Main(string[] args)
        {
            SimpleDelegate multiplication_delegate = new SimpleDelegate(Multiplication);
            SimpleDelegate addition_delegate = new SimpleDelegate(Addition);
            Console.WriteLine("multiplication delegate : " + multiplication_delegate(21, 10));
            Console.WriteLine("addition delegate : " + addition_delegate(5, 27));

        }
        static int Multiplication(int a, int b)
        {
            return a * b;
        }
        static int Addition(int a, int b)
        {
            return a + b;
        }
    }
}

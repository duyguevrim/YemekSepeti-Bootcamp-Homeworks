using System;

namespace predicate_delegate_example
{
    class Program
    {
        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        static void Main(string[] args)
        {
            Predicate<string> isUpper = IsUpperCase;

            bool result = isUpper("IS UPPER CONTROL");
            Predicate<string> isUpperWithAnonymousMethod = delegate (string s) { return s.Equals(s.ToUpper()); };
            bool anonymousMehtodResult = isUpperWithAnonymousMethod("is upper control");
            Predicate<string> isUpperWithLambdaExpression = s => s.Equals(s.ToUpper());
            bool lambdaExpressionResult = isUpperWithLambdaExpression("is upper control");
            Console.WriteLine(result);
            Console.WriteLine(anonymousMehtodResult);
            Console.WriteLine(lambdaExpressionResult);
        }
    }
}

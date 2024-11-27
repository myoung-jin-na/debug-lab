// See https://aka.ms/new-console-template for more information
using System;
using MyExtension;

namespace MyExtension
{
    public static class IntegerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }
        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (int i = 1; i < exponent; i++)
            {
                result = result * myInt;
            }
            return result;
        }
    }
    public static class IntegerExtension2
    {
        // 같은 네임 스페이스에서 이름이 같으면 에러 발생
        //public static int Power(this int myInt, int exp)
        //{
        //    int result = myInt;
        //    for (int i = 1; i < exp; i++)
        //    {
        //        result = result * myInt;
        //    }
        //    return result;
        //}
        public static int pow(this int myInt, int exp)
        {
            int result = myInt;
            for (int i = 1; i < exp; i++)
            {
                result = result * myInt;
            }
            return result;
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"3^2 : {3.Square()}");
            Console.WriteLine($"3^4 : {IntegerExtension.Power(3, 4)}");
            Console.WriteLine($"3^4 : {3.Power(4)}");
            Console.WriteLine($"2^10 : {IntegerExtension2.pow(2, 10)}");
            Console.WriteLine($"2^10 : {2.pow(10)}");
        }
    }
}

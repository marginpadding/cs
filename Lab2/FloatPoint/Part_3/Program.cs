using System;
using System.Text;

namespace Part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            float a= 125.125F, b = -12.0625F;
            var (def, binAnsw, result) = FloatPointMultiplier.Add(a, b);

            Console.WriteLine("Result: " + result);
            Console.WriteLine("Result Binary: " + binAnsw);
            Console.WriteLine("=====================================");
            Console.WriteLine(def);

            Console.ReadLine();
        }
    }
}

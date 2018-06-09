using System;

namespace Devider
{
  class Program
  {
    static void Main(string[] args)
    {
      (string def, long remainder, int quotient) = RemShiftDivider.Devide(22, 6);

      Console.WriteLine($"Remeinder: {remainder}\nQuotient: {quotient}\n{def}");
      Console.ReadLine();
    }
  }
}

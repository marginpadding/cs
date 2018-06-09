using System;

namespace BoothMultiplicator
{
  class Program
  {
    static void Main(string[] args)
    {
      InitializeValue(out int a);
      InitializeValue(out int b);

      (string explanation, string binAnswer, long result) = BoothMultiplicator.Multiply(a, b);

      Console.WriteLine($"{explanation} \n {binAnswer} \n {result}");
      Console.ReadKey();
    }

    static void InitializeValue(out int value)
    {
      bool isCorrect = false;
      value = 0;

      while (!isCorrect)
      {
        Console.WriteLine("Enter the number");

        if (int.TryParse(Console.ReadLine(), out value))
          isCorrect = true;
      }
    }
  }
}

using System;

namespace Devider
{
  public static class RemShiftDivider
  {
    public static (string def, long remainder, int quotient) Devide(int dividend, int divisor)
    {
      int lenght;
      long r = (long)Math.Abs(dividend);
      string def = $"divident: {Convert.ToString(dividend, 2)} \n divisor: {Convert.ToString(divisor, 2)} ";
      long b = ((long)Math.Abs(divisor)) << 32;
      int q = 0;

      def += $"remainder = {Convert.ToString(r, 2)}\n";
      for (lenght = 0; dividend != 0; dividend >>= 1, lenght++) ;

      def += $"Shift the remainder register to {32 - lenght - 1} bits left to optimize algorithm\n\n";
      r <<= (32 - lenght - 1);

      for (int i = 0; i < lenght + 1; i++)
      {
        r <<= 1;
        def += $"shift left remainder to 1 bit {Convert.ToString(r, 2)}\n";
        def += "subtract  divisor from remainder:\n ";
        def += $"remainder: {Convert.ToString(r, 2)} divisor: {Convert.ToString(divisor, 2)}\n";
        r += -b;
        def += $"operation result: (remainder) {Convert.ToString(r, 2)}\n";
        q <<= 1;

        if (r < 0)
        {
          r += b;
          def += $"Restoring the remainder original value:\n{Convert.ToString(r, 2)}\nShift quotient register left to 1 bit: {Convert.ToString(q, 2)}\n\n   ";
        }
        else
        {
          q++;
          def += $"Shift quotient register left to 1 bit and plus 1:  {Convert.ToString(q, 2)}\n\n";
        }
      }
      r >>= 32;

      if (dividend < 0)
      {
        r = -r;
        q = -q;
      }

      return (def, r, q);
    }
  }
}

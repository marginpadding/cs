using System;

namespace Part_3
{
  class FloatPointMultiplier
  {
    public static (string def, string floatResult, float result) Add(float a, float b)
    {
      uint a1 = BitConverter.ToUInt32(BitConverter.GetBytes(a), 0);
      uint b1 = BitConverter.ToUInt32(BitConverter.GetBytes(b), 0);

      uint sa = a1 >> 31;
      uint sb = b1 >> 31;
      uint sr = ~sa & sb | sa & ~sb;

      uint ea = (a1 >> 23) & 0xFF; //0xFF = 1111 1111
      uint eb = (b1 >> 23) & 0xFF;
      uint er = ea + eb - 127;

      uint ma = (a1 & 0x7FFFFF) + 8388608; //8388608 = 1000 0000 0000 0000 0000 00000
      uint mb = (b1 & 0x7FFFFF) + 8388608; //0x7FFFFF = 0111 1111 1111 1111 1111 1111
      uint mr = (uint)BitConverter.ToUInt64(BitConverter.GetBytes((ma * (ulong)mb) >> 24), 0);

      if (((mr >> 23) & 1) == 1)
        er += 1;

      string descr = $"{a} * {b}\n\n";
      descr += $"a = {Convert.ToString(a1, 2)}\n";
      descr += $"b = {Convert.ToString(b1, 2)}\n\n";
      descr += $"sa = {sa} ea = {Convert.ToString(ea, 2)} ma = {Convert.ToString(ma, 2)}\n";
      descr += $"sb = {sb} eb = {Convert.ToString(eb, 2)} mb = {Convert.ToString(mb, 2)}\n\n";

      descr += $"sign bit of result = { sr & 1 }\n";
      descr += $"mantisa of result = {Convert.ToString(mr, 2)}\n";
      descr += $"exponent of result = {Convert.ToString(er, 2)}\n";

      uint result = (((sr << 8) + er) << 23) + (mr & 0x7FFFFF);
      float floatResult = BitConverter.ToSingle(BitConverter.GetBytes(result), 0);

      return (descr, Convert.ToString(result, 2), floatResult);
    }
  }
}

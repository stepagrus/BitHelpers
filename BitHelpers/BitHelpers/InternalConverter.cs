using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BitHelpers
{
  internal static class InternalConverter
  {
    internal static float UInt32ToFloat(uint value)
    {
      var union = new FloatIntUnion()
      {
        UInt = value
      };
      return union.Float;
    }

    internal static uint FloatToUint32(float value)
    {
      var union = new FloatIntUnion
      {
        Float = value
      };
      return union.UInt;
    }

    internal static double UInt64ToDouble(ulong value)
    {
      var union = new DoubleIntUnion()
      {
        UInt = value
      };
      return union.Double;
    }

    internal static ulong DoubleToUInt64(double value)
    {
      var union = new DoubleIntUnion
      {
        Double = value
      };
      return union.UInt;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct FloatIntUnion
    {
      [FieldOffset(0)]
      public float Float;
      [FieldOffset(0)]
      public uint UInt;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct DoubleIntUnion
    {
      [FieldOffset(0)]
      public double Double;
      [FieldOffset(0)]
      public ulong UInt;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToInt128WithRef
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { new byte[0], 0, typeof(ArgumentException) },
      new object[] { new byte[1], 0, typeof(ArgumentException) },
      new object[] { new byte[2], 0, typeof(ArgumentException) },
      new object[] { new byte[3], 0, typeof(ArgumentException) },
      new object[] { new byte[4], 0, typeof(ArgumentException) },
      new object[] { new byte[5], 0, typeof(ArgumentException) },
      new object[] { new byte[6], 0, typeof(ArgumentException) },
      new object[] { new byte[7], 0, typeof(ArgumentException) },
      new object[] { new byte[8], 0, typeof(ArgumentException) },
      new object[] { new byte[9], 0, typeof(ArgumentException) },
      new object[] { new byte[10], 0, typeof(ArgumentException) },
      new object[] { new byte[11], 0, typeof(ArgumentException) },
      new object[] { new byte[12], 0, typeof(ArgumentException) },
      new object[] { new byte[13], 0, typeof(ArgumentException) },
      new object[] { new byte[14], 0, typeof(ArgumentException) },
      new object[] { new byte[15], 0, typeof(ArgumentException) },

      new object[] { new byte[16], -1, typeof(ArgumentOutOfRangeException) },
      new object[] { new byte[16], 1, typeof(ArgumentOutOfRangeException) },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes, int offset, Type exceptionType)
    {
      Assert.Throws(exceptionType, () => BigEndianConverter.ToInt128(bytes, ref offset));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 }, 0, Int128.One },
      new object[] { new byte[] { 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x02 }, 1, (Int128) 258 },
      new object[] { new byte[] { 0x00, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xfe, 0x00 }, 1, Int128.Zero - 2 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, int offset, Int128 expected)
    {
      var newOffset = offset;
      var value = BigEndianConverter.ToInt128(bytes, ref newOffset);

      Assert.That(value, Is.EqualTo(expected));
      Assert.That(newOffset, Is.EqualTo(offset + 16));
    }
  }
}

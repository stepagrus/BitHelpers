using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToFloatWithRef
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { new byte[0], 0, typeof(ArgumentException) },
      new object[] { new byte[1], 0, typeof(ArgumentException) },
      new object[] { new byte[2], 0, typeof(ArgumentException) },
      new object[] { new byte[3], 0, typeof(ArgumentException) },

      new object[] { new byte[4], -1, typeof(ArgumentOutOfRangeException) },
      new object[] { new byte[4], 1, typeof(ArgumentOutOfRangeException) },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes, int offset, Type exceptionType)
    {
      Assert.Throws(exceptionType, () => BigEndianConverter.ToFloat(bytes, ref offset));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] {0x3f, 0x80, 0x00, 0x00}, 0, (float) 1 },
      new object[] { new byte[] {0xff, 0xbf, 0x8c, 0xcc, 0xcd, 0xff}, 1, (float) -1.1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, int offset, float expected)
    {
      var newOffset = offset;
      var value = BigEndianConverter.ToFloat(bytes, ref newOffset);

      Assert.That(value, Is.EqualTo(expected));
      Assert.That(newOffset, Is.EqualTo(offset + sizeof(float)));
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToInt32WithRef
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
      Assert.Throws(exceptionType, () => BigEndianConverter.ToInt32(bytes, ref offset));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] { 0x00, 0x00, 0x00, 0x01 }, 0, (int) 1 },
      new object[] { new byte[] { 0xff, 0x00, 0x00, 0x01, 0x02 }, 1, (int) 258 },
      new object[] { new byte[] { 0x00, 0xff, 0xff, 0xff, 0xfe, 0x00 }, 1, -2 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, int offset, int expected)
    {
      var newOffset = offset;
      var value = BigEndianConverter.ToInt32(bytes, ref newOffset);

      Assert.That(value, Is.EqualTo(expected));
      Assert.That(newOffset, Is.EqualTo(offset + sizeof(int)));
    }
  }
}

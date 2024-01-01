using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToDoubleWithRef
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

			new object[] { new byte[8], -1, typeof(ArgumentOutOfRangeException) },
      new object[] { new byte[8], 1, typeof(ArgumentOutOfRangeException) },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes, int offset, Type exceptionType)
    {
      Assert.Throws(exceptionType, () => BigEndianConverter.ToDouble(bytes, ref offset));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] { 0x3f, 0xf0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, 0,  1d },
      new object[] { new byte[] {0x00, 0xbf, 0xf1, 0x99, 0x99, 0x99, 0x99, 0x99, 0x9a, 0x00}, 1, (double) -1.1d },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, int offset, double expected)
    {
      var newOffset = offset;
      var value = BigEndianConverter.ToDouble(bytes, ref newOffset);

      Assert.That(value, Is.EqualTo(expected));
      Assert.That(newOffset, Is.EqualTo(offset + sizeof(double)));
    }
  }
}

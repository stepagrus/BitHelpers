using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToByteWithRef
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { Array.Empty<byte>(), 0, typeof(ArgumentException) },
      new object[] { new byte[1], 1, typeof(ArgumentOutOfRangeException) },
      new object[] { new byte[2], 2, typeof(ArgumentOutOfRangeException) },
      new object[] { new byte[2], -1, typeof(ArgumentOutOfRangeException) },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes, int offset, Type exceptionType)
    {
      Assert.Throws(exceptionType, () => BigEndianConverter.ToByte(bytes, ref offset));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] { 1, 7, 13 }, 0, (byte) 1 },
      new object[] { new byte[] { 1, 7, 13 }, 1, (byte) 7 },
      new object[] { new byte[] { 1, 7, 13 }, 2, (byte) 13 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, int offset, byte expected)
    {
      var newOffset = offset;
      var value = BigEndianConverter.ToByte(bytes, ref newOffset);

      Assert.That(value, Is.EqualTo(expected));
      Assert.That(newOffset, Is.EqualTo(offset + sizeof(byte)));
    }
  }
}

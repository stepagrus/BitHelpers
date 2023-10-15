namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToUInt64
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { new byte[0] },
      new object[] { new byte[1] },
      new object[] { new byte[2] },
      new object[] { new byte[3] },
      new object[] { new byte[4] },
      new object[] { new byte[5] },
      new object[] { new byte[6] },
      new object[] { new byte[7] },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes)
    {
      Assert.Throws<ArgumentException>(() => BigEndianConverter.ToUInt64(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] {0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xfe}, ulong.MaxValue - 1 },
      new object[] { new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01}, (ulong) 1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, ulong expected)
    {
      var value = BigEndianConverter.ToUInt64(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

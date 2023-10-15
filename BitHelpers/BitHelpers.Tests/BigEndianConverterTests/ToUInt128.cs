namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToUInt128
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { new byte[0], typeof(ArgumentException) },
      new object[] { new byte[1], typeof(ArgumentException) },
      new object[] { new byte[2], typeof(ArgumentException) },
      new object[] { new byte[3], typeof(ArgumentException) },
      new object[] { new byte[4], typeof(ArgumentException) },
      new object[] { new byte[5], typeof(ArgumentException) },
      new object[] { new byte[6], typeof(ArgumentException) },
      new object[] { new byte[7], typeof(ArgumentException) },
      new object[] { new byte[8], typeof(ArgumentException) },
      new object[] { new byte[9], typeof(ArgumentException) },
      new object[] { new byte[10], typeof(ArgumentException) },
      new object[] { new byte[11], typeof(ArgumentException) },
      new object[] { new byte[12], typeof(ArgumentException) },
      new object[] { new byte[13], typeof(ArgumentException) },
      new object[] { new byte[14], typeof(ArgumentException) },
      new object[] { new byte[15], typeof(ArgumentException) },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes, Type exceptionType)
    {
      Assert.Throws(exceptionType, () => BigEndianConverter.ToUInt128(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xfe}, UInt128.MaxValue - 1 },
      new object[] { new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01}, (UInt128) 1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, UInt128 expected)
    {
      var value = BigEndianConverter.ToUInt128(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

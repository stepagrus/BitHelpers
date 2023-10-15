namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToInt64
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
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes, Type exceptionType)
    {
      Assert.Throws(exceptionType, () => BigEndianConverter.ToInt64(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xfe, 0xaa}, (long) -2 },
      new object[] { new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xaa}, (long) 1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, long expected)
    {
      var value = BigEndianConverter.ToInt64(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

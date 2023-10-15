namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToInt16
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { new byte[0] },
      new object[] { new byte[1] },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes)
    {
      Assert.Throws<ArgumentException>(() => BigEndianConverter.ToInt16(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] {0xff, 0xfe}, (short) -2 },
      new object[] { new byte[] {0x00, 0x01}, (short) 1 },
      new object[] { new byte[] {0xff, 0xff, 0x02}, (short) -1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, short expected)
    {
      var value = BigEndianConverter.ToInt16(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

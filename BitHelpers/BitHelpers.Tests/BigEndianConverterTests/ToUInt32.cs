namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToUInt32
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { new byte[0] },
      new object[] { new byte[1] },
      new object[] { new byte[2] },
      new object[] { new byte[3] },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes)
    {
      Assert.Throws<ArgumentException>(() => BigEndianConverter.ToUInt32(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] {0xff, 0xff, 0xff, 0xfe}, uint.MaxValue - 1 },
      new object[] { new byte[] {0x00, 0x00, 0x00, 0x01}, (uint) 1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, uint expected)
    {
      var value = BigEndianConverter.ToUInt32(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

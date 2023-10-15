namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToUint16
  {
    private static readonly object[] checks_boundaries_args = new object[]
    {
      new object[] { new byte[0] },
      new object[] { new byte[1] },
    };
    [TestCaseSource(nameof(checks_boundaries_args))]
    public void checks_boundaries(byte[] bytes)
    {
      Assert.Throws<ArgumentException>(() => BigEndianConverter.ToUInt16(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] {0xff, 0xfe}, (ushort) 65534 },
      new object[] { new byte[] {0x00, 0x01}, (ushort) 1 },
      new object[] { new byte[] {0x00, 0x01, 0x02}, (ushort) 1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, ushort expected)
    {
      var value = BigEndianConverter.ToUInt16(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

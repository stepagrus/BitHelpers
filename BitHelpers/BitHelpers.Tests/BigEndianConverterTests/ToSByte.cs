namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToSByte
  {
    [Test]
    public void checks_boundaries()
    {
      var bytes = Array.Empty<byte>();

      Assert.Throws<ArgumentException>(() => BigEndianConverter.ToSByte(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] { 255, 7, 254 }, (sbyte) -1 },
      new object[] { new byte[] { 7, 254 }, (sbyte) 7 },
      new object[] { new byte[] { 254, 255, 7}, (sbyte) -2 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, sbyte expected)
    {
      var value = BigEndianConverter.ToSByte(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

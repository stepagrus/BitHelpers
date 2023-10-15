namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToByte
  {
    [Test]
    public void checks_boundaries()
    {
      var bytes = Array.Empty<byte>();

      Assert.Throws<ArgumentException>(() => BigEndianConverter.ToByte(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] {255}, (byte) 255 },
      new object[] { new byte[] {1, 2}, (byte) 1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, byte expected)
    {
      var value = BigEndianConverter.ToByte(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }
  }
}

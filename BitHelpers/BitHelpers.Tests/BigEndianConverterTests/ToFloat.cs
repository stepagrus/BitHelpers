using System.Runtime.InteropServices;

namespace BitHelpers.Tests.BigEndianConverterTests
{
  internal class ToFloat
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
      Assert.Throws<ArgumentException>(() => BigEndianConverter.ToFloat(bytes));
    }

    private static readonly object[] read_value_args = new object[]
    {
      new object[] { new byte[] {0x3f, 0x80, 0x00, 0x00}, (float) 1 },
      new object[] { new byte[] {0xbf, 0x8c, 0xcc, 0xcd}, (float) -1.1 },
    };
    [TestCaseSource(nameof(read_value_args))]
    public void read_value(byte[] bytes, float expected)
    {
      var value = BigEndianConverter.ToFloat(bytes);

      Assert.That(value, Is.EqualTo(expected));
    }

    //[Test]
    //public void a()
    //{
    //  var array = new byte[4];
    //  float b = (float) -1.1;
    //  MemoryMarshal.Write<float>(array, ref b);
    //}
  }
}

namespace BitHelpers.Tests.BigEndianConverterTests;

internal class ToDouble
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
		Assert.Throws<ArgumentException>(() => BigEndianConverter.ToDouble(bytes));
	}

	private static readonly object[] read_value_args = new object[]
	{
		new object[] { new byte[] {0x3f, 0xf0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, (double) 1d },
		new object[] { new byte[] {0xbf, 0xf1, 0x99, 0x99, 0x99, 0x99, 0x99, 0x9a}, (double) -1.1d },
	};
	[TestCaseSource(nameof(read_value_args))]
	public void read_value(byte[] bytes, double expected)
	{
		var value = BigEndianConverter.ToDouble(bytes);

		Assert.That(value, Is.EqualTo(expected));
	}
}

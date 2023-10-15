namespace BitHelpers
{
  internal interface IByteConverter
  {
    static abstract void Write(byte value,  Span<byte> toBuffer, ref int offset);
    static abstract void Write(sbyte value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(ushort value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(short value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(uint value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(int value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(ulong value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(long value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(UInt128 value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(Int128 value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(float value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(double value, Span<byte> toBuffer, ref int offset);
    static abstract void Write(decimal value, Span<byte> toBuffer, ref int offset);

    static abstract byte ToByte(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract byte ToByte(ReadOnlySpan<byte> buffer);
    static abstract sbyte ToSByte(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract sbyte ToSByte(ReadOnlySpan<byte> buffer);
    static abstract ushort ToUInt16(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract ushort ToUInt16(ReadOnlySpan<byte> buffer);
    static abstract short ToInt16(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract short ToInt16(ReadOnlySpan<byte> buffer);
    static abstract uint ToUInt32(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract uint ToUInt32(ReadOnlySpan<byte> buffer);
    static abstract int ToInt32(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract int ToInt32(ReadOnlySpan<byte> buffer);
    static abstract ulong ToUInt64(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract ulong ToUInt64(ReadOnlySpan<byte> buffer);
    static abstract long ToInt64(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract long ToInt64(ReadOnlySpan<byte> buffer);
    static abstract UInt128 ToUInt128(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract UInt128 ToUInt128(ReadOnlySpan<byte> buffer);
    static abstract Int128 ToInt128(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract Int128 ToInt128(ReadOnlySpan<byte> buffer);
    static abstract float ToFloat(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract float ToFloat(ReadOnlySpan<byte> buffer);
    static abstract double ToDouble(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract double ToDouble(ReadOnlySpan<byte> buffer);
    static abstract decimal ToDecimal(ReadOnlySpan<byte> buffer, ref int offset);
    static abstract decimal ToDecimal(ReadOnlySpan<byte> buffer);
  }
}
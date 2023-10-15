using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BitHelpers
{
  public class BigEndianConverter : IByteConverter
  {
    public static byte ToByte(ReadOnlySpan<byte> buffer, ref int offset)
    {
      if (buffer.Length == 0)
        throw new ArgumentException($"{nameof(buffer)} is too small");
      if (offset < 0 || offset >= buffer.Length)
        throw new ArgumentOutOfRangeException($"{nameof(offset)} is out of range");

      return buffer[offset];
    }

    public static byte ToByte(ReadOnlySpan<byte> buffer)
    {
      if (buffer.Length < 1)
        throw new ArgumentException($"{nameof(buffer)} is too small");

      return buffer[0];
    }
    public static sbyte ToSByte(ReadOnlySpan<byte> buffer, ref int offset)
    {
      if (buffer.Length == 0)
        throw new ArgumentException($"{nameof(buffer)} is empty");
      if (offset < 0 || offset >= buffer.Length)
        throw new ArgumentOutOfRangeException($"{nameof(offset)} is out of range");

      return (sbyte)buffer[offset];
    }

    public static sbyte ToSByte(ReadOnlySpan<byte> buffer)
    {
      if (buffer.Length < 1)
        throw new ArgumentException($"buffer is too small");

      return (sbyte)buffer[0];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort ToUInt16(ReadOnlySpan<byte> buffer, ref int offset)
    {
      if (buffer.Length < sizeof(ushort))
        throw new ArgumentException($"{nameof(buffer)} is too small");

      var newOffset = offset + sizeof(ushort);
      if (offset < 0 || newOffset > buffer.Length)
        throw new ArgumentOutOfRangeException($"{nameof(offset)} is out of range");

      var value = (ushort)
        (buffer[offset + 0] << 8 |
        buffer[offset + 1] << 0);
      offset = newOffset;
      return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort ToUInt16(ReadOnlySpan<byte> buffer)
    {
      if (sizeof(ushort) > buffer.Length)
        throw new ArgumentException(nameof(buffer));

      return (ushort)(
        buffer[0] << 8 |
        buffer[1] << 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short ToInt16(ReadOnlySpan<byte> buffer, ref int offset)
    {
      return (short)ToUInt16(buffer, ref offset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short ToInt16(ReadOnlySpan<byte> buffer)
    {
      return (short)ToUInt16(buffer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint ToUInt32(ReadOnlySpan<byte> buffer, ref int offset)
    {
      if (buffer.Length < sizeof(uint))
        throw new ArgumentException($"{nameof(buffer)} length is too small");

      var newOffset = offset + sizeof(uint);
      if (offset < 0 || newOffset > buffer.Length)
        throw new ArgumentOutOfRangeException($"{nameof(offset)} is out of range");

      var value = (uint)(
        buffer[offset + 0] << 24 |
        buffer[offset + 1] << 16 |
        buffer[offset + 2] << 8 |
        buffer[offset + 3] << 0
        );
      offset = newOffset;
      return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint ToUInt32(ReadOnlySpan<byte> buffer)
    {
      if (buffer.Length < sizeof(uint))
        throw new ArgumentException($"{nameof(buffer)} length is too small");

      return (uint)(
        buffer[0] << 24 |
        buffer[1] << 16 |
        buffer[2] << 8 |
        buffer[3] << 0
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToInt32(ReadOnlySpan<byte> buffer, ref int offset)
    {
      return (int)ToUInt32(buffer, ref offset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToInt32(ReadOnlySpan<byte> buffer)
    {
      return (int)ToUInt32(buffer);
    }


    public static ulong ToUInt64(ReadOnlySpan<byte> buffer, ref int offset)
    {
      if (buffer.Length < sizeof(ulong))
        throw new ArgumentException($"{nameof(buffer)} length is too small");

      var newOffset = offset + sizeof(ulong);
      if (offset < 0 || newOffset > buffer.Length)
        throw new ArgumentOutOfRangeException($"{nameof(offset)} is out of range");

      var value = 
        (ulong)buffer[offset + 0] << 56 |
        (ulong)buffer[offset + 1] << 48 |
        (ulong)buffer[offset + 2] << 40 |
        (ulong)buffer[offset + 3] << 32 |
        (ulong)buffer[offset + 4] << 24 |
        (ulong)buffer[offset + 5] << 16 |
        (ulong)buffer[offset + 6] << 8 |
        (ulong)buffer[offset + 7] << 0
        ;
      offset = newOffset;
      return value;
    }

    public static ulong ToUInt64(ReadOnlySpan<byte> buffer)
    {
      if (buffer.Length < sizeof(ulong))
        throw new ArgumentException($"{nameof(buffer)} length is too small");

      return
        (ulong)buffer[0] << 56 |
        (ulong)buffer[1] << 48 |
        (ulong)buffer[2] << 40 |
        (ulong)buffer[3] << 32 |
        (ulong)buffer[4] << 24 |
        (ulong)buffer[5] << 16 |
        (ulong)buffer[6] << 8 |
        (ulong)buffer[7] << 0
        ;
    }

    public static decimal ToDecimal(ReadOnlySpan<byte> buffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static decimal ToDecimal(ReadOnlySpan<byte> buffer)
    {
      throw new NotImplementedException();
    }

    public static double ToDouble(ReadOnlySpan<byte> buffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static double ToDouble(ReadOnlySpan<byte> buffer)
    {
      throw new NotImplementedException();
    }

    public static float ToFloat(ReadOnlySpan<byte> buffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static float ToFloat(ReadOnlySpan<byte> buffer)
    {
      throw new NotImplementedException();
    }

    public static Int128 ToInt128(ReadOnlySpan<byte> buffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static Int128 ToInt128(ReadOnlySpan<byte> buffer)
    {
      throw new NotImplementedException();
    }


    public static long ToInt64(ReadOnlySpan<byte> buffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static long ToInt64(ReadOnlySpan<byte> buffer)
    {
      throw new NotImplementedException();
    }


    public static UInt128 ToUInt128(ReadOnlySpan<byte> buffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static UInt128 ToUInt128(ReadOnlySpan<byte> buffer)
    {
      throw new NotImplementedException();
    }




    public static void Write(byte value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(sbyte value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(ushort value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(short value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(uint value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(int value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(ulong value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(long value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(UInt128 value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(Int128 value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(float value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(double value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }

    public static void Write(decimal value, Span<byte> toBuffer, ref int offset)
    {
      throw new NotImplementedException();
    }
  }
}
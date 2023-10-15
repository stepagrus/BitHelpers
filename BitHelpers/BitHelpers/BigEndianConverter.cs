using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using Resx = BitHelpers.Properties.Resources;

namespace BitHelpers;

public class BigEndianConverter : IByteConverter
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static byte ToByte(ReadOnlySpan<byte> buffer, ref int offset)
  {
    CheckBoundaries(buffer, offset, sizeof(byte));

    var value = buffer[offset];
    offset += sizeof(byte);
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static byte ToByte(ReadOnlySpan<byte> buffer)
  {
    CheckBoundaries(buffer, sizeof(byte));

    return buffer[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static sbyte ToSByte(ReadOnlySpan<byte> buffer, ref int offset)
  {
    CheckBoundaries(buffer, offset, sizeof(sbyte));

    var value = (sbyte)buffer[offset];
    offset += sizeof(sbyte);
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static sbyte ToSByte(ReadOnlySpan<byte> buffer)
  {
    CheckBoundaries(buffer, sizeof(sbyte));

    return (sbyte)buffer[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ushort ToUInt16(ReadOnlySpan<byte> buffer, ref int offset)
  {
    CheckBoundaries(buffer, offset, sizeof(ushort));

    var value = (ushort)
      (buffer[offset + 0] << 8 |
      buffer[offset + 1] << 0);
    offset += sizeof(ushort);
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ushort ToUInt16(ReadOnlySpan<byte> buffer)
  {
    CheckBoundaries(buffer, sizeof(ushort));

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
    CheckBoundaries(buffer, offset, sizeof(uint));

    var value = (uint)(
      buffer[offset + 0] << 24 |
      buffer[offset + 1] << 16 |
      buffer[offset + 2] << 8 |
      buffer[offset + 3] << 0
      );
    offset += sizeof(uint);
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static uint ToUInt32(ReadOnlySpan<byte> buffer)
  {
    CheckBoundaries(buffer, sizeof(uint));

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

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ulong ToUInt64(ReadOnlySpan<byte> buffer, ref int offset)
  {
    CheckBoundaries(buffer, offset, sizeof(ulong));

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
    offset += sizeof(ulong);
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ulong ToUInt64(ReadOnlySpan<byte> buffer)
  {
    CheckBoundaries(buffer, sizeof(ulong));

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

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static long ToInt64(ReadOnlySpan<byte> buffer, ref int offset)
  {
    return (long)ToUInt64(buffer, ref offset);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static long ToInt64(ReadOnlySpan<byte> buffer)
  {
    return (long)ToUInt64(buffer);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128 ToUInt128(ReadOnlySpan<byte> buffer, ref int offset)
  {
    CheckBoundaries(buffer, offset, SizeOfInt128);

    var newOffset = offset;
    var upper = ToUInt64(buffer, ref newOffset);
    var lower = ToUInt64(buffer, ref newOffset);
    offset = newOffset;
    return new UInt128(upper, lower);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128 ToUInt128(ReadOnlySpan<byte> buffer)
  {
    CheckBoundaries(buffer, SizeOfInt128);

    var upper = ToUInt64(buffer);
    var lower = ToUInt64(buffer.Slice(8, 8));
    return new UInt128(upper, lower);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128 ToInt128(ReadOnlySpan<byte> buffer, ref int offset)
  {
    return (Int128)ToUInt128(buffer, ref offset);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128 ToInt128(ReadOnlySpan<byte> buffer)
  {
    return (Int128)ToUInt128(buffer);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float ToFloat(ReadOnlySpan<byte> buffer, ref int offset)
  {
    CheckBoundaries(buffer, offset, sizeof(float));

    return InternalConverter.UInt32ToFloat(ToUInt32(buffer, ref offset));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float ToFloat(ReadOnlySpan<byte> buffer)
  {
    CheckBoundaries(buffer, sizeof(float));

    return InternalConverter.UInt32ToFloat(ToUInt32(buffer));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static decimal ToDecimal(ReadOnlySpan<byte> buffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static decimal ToDecimal(ReadOnlySpan<byte> buffer)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static double ToDouble(ReadOnlySpan<byte> buffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static double ToDouble(ReadOnlySpan<byte> buffer)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(byte value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(sbyte value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(ushort value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(short value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(uint value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(int value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(ulong value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(long value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(UInt128 value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(Int128 value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(float value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(double value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write(decimal value, Span<byte> toBuffer, ref int offset)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static void CheckBoundaries(ReadOnlySpan<byte> buffer, int offset, int valueSize)
  {
    if (buffer.Length < valueSize)
      throw new ArgumentException(Resx.buffer_is_too_small);

    if (offset < 0 || offset + valueSize > buffer.Length)
      throw new ArgumentOutOfRangeException(nameof(offset), Resx.is_out_of_range);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static void CheckBoundaries(ReadOnlySpan<byte> buffer, int valueSize)
  {
    if (buffer.Length < valueSize)
      throw new ArgumentException(Resx.buffer_is_too_small);
  }

  private const int SizeOfInt128 = 16;
}

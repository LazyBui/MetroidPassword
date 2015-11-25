using System;

namespace MetroidPassword {
	internal static partial class Extensions {
		private const int BitsInByte = 8;
		private const int ByteSize = sizeof(byte) * BitsInByte;
		private const int ShortSize = sizeof(ushort) * BitsInByte;
		private const int IntSize = sizeof(uint) * BitsInByte;
		private const int LongSize = sizeof(ulong) * BitsInByte;

		private static byte[] sFlipTable = new byte[] { 
			0x00, 0x08, 0x04, 0x0C,
			0x02, 0x0A, 0x06, 0x0E,
			0x01, 0x09, 0x05, 0x0D,
			0x03, 0x0B, 0x07, 0x0F,
		};

		public static byte ReverseBits(this byte @this) {
			return (byte)((sFlipTable[@this & 0x0F] << 4) | sFlipTable[@this >> 4]);
		}

		public static byte RotateRight(this byte @this, int shiftCount) {
			shiftCount &= ByteSize - 1;
			return (byte)((byte)(@this >> shiftCount) | (byte)(@this << (ByteSize - shiftCount)));
		}

		public static byte RotateLeft(this byte @this, int shiftCount) {
			shiftCount &= ByteSize - 1;
			return (byte)((byte)(@this << shiftCount) | (byte)(@this >> (ByteSize - shiftCount)));
		}

		public static ushort RotateRight(this ushort @this, int shiftCount) {
			shiftCount &= ShortSize - 1;
			return (ushort)((ushort)(@this >> shiftCount) | (ushort)(@this << (ShortSize - shiftCount)));
		}

		public static ushort RotateLeft(this ushort @this, int shiftCount) {
			shiftCount &= ShortSize - 1;
			return (ushort)((ushort)(@this << shiftCount) | (ushort)(@this >> (ShortSize - shiftCount)));
		}

		public static uint RotateRight(this uint @this, int shiftCount) {
			shiftCount &= IntSize - 1;
			return (uint)((uint)(@this >> shiftCount) | (uint)(@this << (IntSize - shiftCount)));
		}

		public static uint RotateLeft(this uint @this, int shiftCount) {
			shiftCount &= IntSize - 1;
			return (uint)((uint)(@this << shiftCount) | (uint)(@this >> (IntSize - shiftCount)));
		}

		public static ulong RotateRight(this ulong @this, int shiftCount) {
			shiftCount &= LongSize - 1;
			return (ulong)((ulong)(@this >> shiftCount) | (ulong)(@this << (LongSize - shiftCount)));
		}

		public static ulong RotateLeft(this ulong @this, int shiftCount) {
			shiftCount &= LongSize - 1;
			return (ulong)((ulong)(@this << shiftCount) | (ulong)(@this >> (LongSize - shiftCount)));
		}

		public static byte[] RotateLeft(this byte[] @this, int shiftCount) {
			if (@this == null) return null;
			if (@this.Length == 0 || shiftCount == 0) return @this;
			shiftCount %= @this.Length * ByteSize;

			byte[] result = new byte[@this.Length];
			Buffer.BlockCopy(@this, 0, result, 0, @this.Length);
			if (@this.Length == 1) {
				result[0] = result[0].RotateLeft(shiftCount);
			}
			else {
				bool bit = true;
				bool tempBit = false;
				int end = @this.Length - 1;
				int first = end;
				byte bitValue = 0x01;
				byte bitMatch = 0x80;

				for (int shift = 0; shift < shiftCount; shift++) {
					byte b = result[first];

					for (int idx = end; idx >= 0; idx--) {
						tempBit = (result[idx] & bitMatch) == bitMatch;
						result[idx] <<= 1;
						result[idx] |= (byte)(bit ? bitValue : 0);
						bit = tempBit;
					}

					tempBit = (b & bitMatch) == bitMatch;
					b <<= 1;
					b |= (byte)(bit ? bitValue : 0);
					result[first] = b;
					bit = tempBit;
				}
			}
			return result;
		}

		public static byte[] RotateRight(this byte[] @this, int shiftCount) {
			if (@this == null) return null;
			if (@this.Length == 0 || shiftCount == 0) return @this;
			shiftCount %= @this.Length * ByteSize;

			byte[] result = new byte[@this.Length];
			Buffer.BlockCopy(@this, 0, result, 0, @this.Length);
			if (@this.Length == 1) {
				result[0] = result[0].RotateRight(shiftCount);
			}
			else {
				bool bit = true;
				bool tempBit = false;
				int end = @this.Length - 1;
				int first = 0;
				byte bitValue = 0x80;
				byte bitMatch = 0x01;

				for (int shift = 0; shift < shiftCount; shift++) {
					byte b = result[first];

					for (int idx = 0; idx <= end; idx++) {
						tempBit = (result[idx] & bitMatch) == bitMatch;
						result[idx] >>= 1;
						result[idx] |= (byte)(bit ? bitValue : 0);
						bit = tempBit;
					}

					tempBit = (b & bitMatch) == bitMatch;
					b >>= 1;
					b |= (byte)(bit ? bitValue : 0);
					result[first] = b;
					bit = tempBit;
				}
			}
			return result;
		}
	}
}
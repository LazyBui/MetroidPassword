using System;
using BitPackerTools;
using BitPackerTools.Serialization;

namespace MetroidPassword.Tools {
	internal sealed class Password {
		public string Encoded { get; private set; }
		public PasswordProperties Properties { get; private set; }

		public Password(string pRawEncoded) {
			Encoded = pRawEncoded;
			Decode();
		}

		public Password(PasswordProperties pDesired) {
			Properties = pDesired;
			Encode();
		}

		private const int ChecksumByte = 18;
		private const int ShiftByte = 17;
		private const int ChecksumByteCount = 16;
		private const int GameAgeEndByteIndex = 14;
		private const int GameAgeStartByteIndex = 11;

		private static void Swap(byte[] pBytes, int pIndex1, int pIndex2) {
			byte temp = pBytes[pIndex1];
			pBytes[pIndex1] = pBytes[pIndex2];
			pBytes[pIndex2] = temp;
		}

		private byte CalculateChecksum(byte[] pBytes, byte pShift) {
			byte checksum = pShift;
			for (int i = ChecksumByteCount - 1; i >= 0; i--) {
				unchecked {
					checksum += pBytes[i];
				}
			}
			return checksum;
		}

		public void Decode() {
			byte[] bytes = AlphabetMapper.TranslateMetroidStringToComputerBytes(Encoded);
			byte checksum = bytes[ChecksumByte - 1];
			byte shift = bytes[ShiftByte - 1];

			byte[] decoded = new byte[ChecksumByteCount];
			Buffer.BlockCopy(bytes, 0, decoded, 0, ChecksumByteCount);

			decoded = decoded.RotateLeft(shift);

			byte verifyChecksum = CalculateChecksum(decoded, shift);
			if (verifyChecksum != checksum) {
				throw new ChecksumException("Invalid Metroid password");
			}

			// The bitpacking we use assumes that information is packed from the left which means that it makes a big difference for a byte full of bools
			// Information is actually packed from the right of the byte
			// Ergo we just have to flip each byte
			// However first we handle the only 32-bit value (which can't be fixed by a naive flip)
			if (!BitConverter.IsLittleEndian) {
				// The game age value comes in little-endian format
				Swap(decoded, GameAgeStartByteIndex, GameAgeEndByteIndex);
				Swap(decoded, GameAgeStartByteIndex + 1, GameAgeEndByteIndex - 1);
			}
			for (int i = 0; i < decoded.Length; i++) {
				if (i >= GameAgeStartByteIndex && i <= GameAgeEndByteIndex) continue;
				decoded[i] = decoded[i].ReverseBits();
			}

			var reader = new PackedBitReader(decoded);
			var serializer = new PackedBitSerializer(typeof(PasswordProperties));
			Properties = serializer.Deserialize(reader) as PasswordProperties;

			Properties.Checksum = checksum;
			Properties.Shift = shift;
		}

		public void Encode() {
			var writer = new PackedBitWriter();
			var serializer = new PackedBitSerializer(typeof(PasswordProperties));
			serializer.Serialize(writer, Properties);

			byte[] bytes = writer.ToArray();

			// The bitpacking we use assumes that information is packed from the left which means that it makes a big difference for a byte full of bools
			// Information is actually packed from the right of the byte
			// Ergo we just have to flip each byte
			// However first we handle the only 32-bit value (which can't be fixed by a naive flip)
			if (!BitConverter.IsLittleEndian) {
				// The game age value comes in little-endian format
				Swap(bytes, GameAgeStartByteIndex, GameAgeEndByteIndex);
				Swap(bytes, GameAgeStartByteIndex + 1, GameAgeEndByteIndex - 1);
			}
			for (int i = 0; i < ChecksumByteCount; i++) {
				if (i >= GameAgeStartByteIndex && i <= GameAgeEndByteIndex) continue;
				bytes[i] = bytes[i].ReverseBits();
			}

			byte checksum = CalculateChecksum(bytes, Properties.Shift);
			Properties.Checksum = checksum;

			if (Properties.Shift > 0) {
				bytes = bytes.RotateRight(Properties.Shift);
			}

			byte[] encoded = new byte[ChecksumByte];
			Buffer.BlockCopy(bytes, 0, encoded, 0, ChecksumByteCount);
			encoded[ShiftByte - 1] = Properties.Shift;
			encoded[ChecksumByte - 1] = Properties.Checksum;

			Encoded = AlphabetMapper.TranslateComputerBytesToMetroidString(encoded);
		}
	}
}
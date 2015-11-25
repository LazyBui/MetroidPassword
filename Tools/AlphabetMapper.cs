using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroidPassword.Tools {
	internal enum CombinationResult {
		Part1Invalid,
		Part1InvalidChars,
		Part2Invalid,
		Part2InvalidChars,
		Part3Invalid,
		Part3InvalidChars,
		Part4Invalid,
		Part4InvalidChars,
		Success,
	}

	internal static class AlphabetMapper {
		public const int PartCharacterLength = PartCount;

		private const int BitsPerComputerByte = 8;
		private const int BitsPerCharacter = 6;
		private const int CharacterCount = PasswordProperties.TotalBits / BitsPerCharacter;
		private const int Parts = 4;
		private const int PartCount = CharacterCount / Parts;
		private const int ByteCount = PasswordProperties.TotalBits / BitsPerComputerByte;
		private const int AlphabetSize = 64;
		private const int SpaceValue = 255;

		// Space is part of the alphabet, but works very differently.
		// Everything except space is encoded in 6 bits and space has an 8-bit value of 255.
		// Currently no space support is planned.

		private static List<char> sTable = new List<char>() {
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C',
			'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
			'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c',
			'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
			'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '?', '-', ' ',
		};

		public static string[] Split(string raw) {
			if (!IsValidString(raw)) throw new ArgumentException("Invalid characters", nameof(raw));
			string[] split = new string[Parts];
			raw = Format(raw);
			for (int i = 0; i < Parts; i++) {
				split[i] = raw.Substring(i * PartCount, PartCount);
			}
			return split;
		}

		public static CombinationResult Combine(string part1, string part2, string part3, string part4, out string value) {
			if (string.IsNullOrEmpty(part1) || part1.Length != PartCount) {
				value = null;
				return CombinationResult.Part1Invalid;
			}
			if (string.IsNullOrEmpty(part2) || part2.Length != PartCount) {
				value = null;
				return CombinationResult.Part2Invalid;
			}
			if (string.IsNullOrEmpty(part3) || part3.Length != PartCount) {
				value = null;
				return CombinationResult.Part3Invalid;
			}
			if (string.IsNullOrEmpty(part4) || part4.Length != PartCount) {
				value = null;
				return CombinationResult.Part4Invalid;
			}

			Func<char, bool> isInvalid = (c) => sTable.IndexOf(c) == -1;
			if (part1.Any(isInvalid)) {
				value = null;
				return CombinationResult.Part1InvalidChars;
			}
			if (part2.Any(isInvalid)) {
				value = null;
				return CombinationResult.Part2InvalidChars;
			}
			if (part3.Any(isInvalid)) {
				value = null;
				return CombinationResult.Part3InvalidChars;
			}
			if (part4.Any(isInvalid)) {
				value = null;
				return CombinationResult.Part4InvalidChars;
			}

			value = string.Join("", new[] { part1, part2, part3, part4 });
			return CombinationResult.Success;
		}

		private static bool IsValidString(string raw) {
			if (string.IsNullOrEmpty(raw)) return false;
			if (raw.Length != CharacterCount) {
				// We can accept delimiters here, but we must be careful
				if (raw.Length != (CharacterCount + Parts - 1)) return false;

				// We would have 3 delimiters if there are 4 parts and they should all be the same
				string validDelimiter = null;
				for (int i = 0; i < (Parts - 1); i++) {
					string delimiter = raw.Substring(PartCount * (i + 1) + i, 1);
					if (validDelimiter == null) validDelimiter = delimiter;
					else if (delimiter != validDelimiter) return false;
				}
			}
			if (raw.Any(c => sTable.IndexOf(c) == -1)) return false;
			return true;
		}

		private static string Format(string raw) {
			if (raw.Length == CharacterCount) return raw;
			// We assume we have delimiters
			var sb = new StringBuilder();
			for (int i = 0; i < Parts; i++) {
				sb.Append(raw.Substring(i * PartCount + i, PartCount));
			}
			return sb.ToString();
		}

		public static byte[] TranslateMetroidStringToComputerBytes(string raw) {
			if (!IsValidString(raw)) throw new ArgumentException("Invalid string", nameof(raw));
			raw = Format(raw);

			return CollapseBytesFromRaw(ConvertMetroidStringToRawBytes(raw));
		}

		private static byte[] ConvertMetroidStringToRawBytes(string raw) {
			var result = new byte[CharacterCount];
			int idx = 0;
			foreach (char c in raw) {
				char test = c;
				if (test == ' ') {
					// Space is a special value
					result[idx++] = SpaceValue;
				}
				else {
					result[idx++] = (byte)sTable.IndexOf(test);
				}
			}
			return result;
		}

		private static byte[] CollapseBytesFromRaw(byte[] rawBytes) {
			var result = new byte[ByteCount];
			if (!rawBytes.Any(b => b == SpaceValue)) {
				// We have no spaces, this is a comparatively easy operation
				int byteIndex = 0;
				for (int i = 0; i < BitsPerCharacter; i++) {
					int baseIndex = i * 4;
					result[byteIndex++] = (byte)((rawBytes[baseIndex + 0] << 2) | (rawBytes[baseIndex + 1] >> 4));
					result[byteIndex++] = (byte)((rawBytes[baseIndex + 1] << 4) | (rawBytes[baseIndex + 2] >> 2));
					result[byteIndex++] = (byte)((rawBytes[baseIndex + 2] << 6) | (rawBytes[baseIndex + 3] >> 0));
				}
			}
			else {
				throw new NotImplementedException();
			}

			return result;
		}

		public static string TranslateComputerBytesToMetroidString(byte[] bytes) {
			if (bytes.Length != ByteCount) throw new ArgumentException("Invalid bit array", nameof(bytes));
			return ConvertRawBytesToMetroidString(ExpandBytesToRaw(bytes));
		}

		private static byte[] ExpandBytesToRaw(byte[] bytes) {
			var result = new byte[CharacterCount];

			int byteIndex = 0;
			for (int i = 0; i < 6; i++) {
				int baseIndex = i * 3;
				// Yes, I know the top left operation and the bottom right operation end up at being completely useless
				// It's a stylistic thing
				result[byteIndex++] = (byte)(((bytes[baseIndex + 0] & 0x00) << 6) | (bytes[baseIndex + 0] >> 2));
				result[byteIndex++] = (byte)(((bytes[baseIndex + 0] & 0x03) << 4) | (bytes[baseIndex + 1] >> 4));
				result[byteIndex++] = (byte)(((bytes[baseIndex + 1] & 0x0F) << 2) | (bytes[baseIndex + 2] >> 6));
				result[byteIndex++] = (byte)(((bytes[baseIndex + 2] & 0x3F) << 0) | (bytes[baseIndex + 0] >> 8));
			}

			return result;
		}

		private static string ConvertRawBytesToMetroidString(byte[] rawBytes) {
			var result = new StringBuilder();
			foreach (byte b in rawBytes) {
				if (b == SpaceValue) {
					result.Append(' ');
				}
				else {
					if (b > AlphabetSize) throw new ArgumentException("Byte value in excess of maximum value");
					result.Append(sTable[b]);
				}
			}
			return result.ToString();
		}
	}
}
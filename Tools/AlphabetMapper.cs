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

		public static string[] Split(string pRaw) {
			if (!IsValidString(pRaw)) throw new ArgumentException("Invalid characters", nameof(pRaw));
			string[] split = new string[Parts];
			pRaw = Format(pRaw);
			for (int i = 0; i < Parts; i++) {
				split[i] = pRaw.Substring(i * PartCount, PartCount);
			}
			return split;
		}

		public static CombinationResult Combine(string pPart1, string pPart2, string pPart3, string pPart4, out string pOut) {
			if (string.IsNullOrEmpty(pPart1) || pPart1.Length != PartCount) {
				pOut = null;
				return CombinationResult.Part1Invalid;
			}
			if (string.IsNullOrEmpty(pPart2) || pPart2.Length != PartCount) {
				pOut = null;
				return CombinationResult.Part2Invalid;
			}
			if (string.IsNullOrEmpty(pPart3) || pPart3.Length != PartCount) {
				pOut = null;
				return CombinationResult.Part3Invalid;
			}
			if (string.IsNullOrEmpty(pPart4) || pPart4.Length != PartCount) {
				pOut = null;
				return CombinationResult.Part4Invalid;
			}

			Func<char, bool> isInvalid = (c) => sTable.IndexOf(c) == -1;
			if (pPart1.Any(isInvalid)) {
				pOut = null;
				return CombinationResult.Part1InvalidChars;
			}
			if (pPart2.Any(isInvalid)) {
				pOut = null;
				return CombinationResult.Part2InvalidChars;
			}
			if (pPart3.Any(isInvalid)) {
				pOut = null;
				return CombinationResult.Part3InvalidChars;
			}
			if (pPart4.Any(isInvalid)) {
				pOut = null;
				return CombinationResult.Part4InvalidChars;
			}

			pOut = string.Join("", new[] { pPart1, pPart2, pPart3, pPart4 });
			return CombinationResult.Success;
		}

		private static bool IsValidString(string pRaw) {
			if (string.IsNullOrEmpty(pRaw)) return false;
			if (pRaw.Length != CharacterCount) {
				// We can accept delimiters here, but we must be careful
				if (pRaw.Length != (CharacterCount + Parts - 1)) return false;

				// We would have 3 delimiters if there are 4 parts and they should all be the same
				string validDelimiter = null;
				for (int i = 0; i < (Parts - 1); i++) {
					string delimiter = pRaw.Substring(PartCount * (i + 1) + i, 1);
					if (validDelimiter == null) validDelimiter = delimiter;
					else if (delimiter != validDelimiter) return false;
				}
			}
			if (pRaw.Any(c => sTable.IndexOf(c) == -1)) return false;
			return true;
		}

		private static string Format(string pRaw) {
			if (pRaw.Length == CharacterCount) return pRaw;
			// We assume we have delimiters
			var sb = new StringBuilder();
			for (int i = 0; i < Parts; i++) {
				sb.Append(pRaw.Substring(i * PartCount + i, PartCount));
			}
			return sb.ToString();
		}

		public static byte[] TranslateMetroidStringToComputerBytes(string pRaw) {
			if (!IsValidString(pRaw)) throw new ArgumentException("Invalid string", nameof(pRaw));
			pRaw = Format(pRaw);

			return CollapseBytesFromRaw(ConvertMetroidStringToRawBytes(pRaw));
		}

		private static byte[] ConvertMetroidStringToRawBytes(string pRaw) {
			var result = new byte[CharacterCount];
			int idx = 0;
			foreach (char c in pRaw) {
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

		private static byte[] CollapseBytesFromRaw(byte[] pRawBytes) {
			var result = new byte[ByteCount];
			if (!pRawBytes.Any(b => b == SpaceValue)) {
				// We have no spaces, this is a comparatively easy operation
				int byteIndex = 0;
				for (int i = 0; i < BitsPerCharacter; i++) {
					int baseIndex = i * 4;
					result[byteIndex++] = (byte)((pRawBytes[baseIndex + 0] << 2) | (pRawBytes[baseIndex + 1] >> 4));
					result[byteIndex++] = (byte)((pRawBytes[baseIndex + 1] << 4) | (pRawBytes[baseIndex + 2] >> 2));
					result[byteIndex++] = (byte)((pRawBytes[baseIndex + 2] << 6) | (pRawBytes[baseIndex + 3] >> 0));
				}
			}
			else {
				throw new NotImplementedException();
			}

			return result;
		}

		public static string TranslateComputerBytesToMetroidString(byte[] pBytes) {
			if (pBytes.Length != ByteCount) throw new ArgumentException("Invalid bit array", nameof(pBytes));
			return ConvertRawBytesToMetroidString(ExpandBytesToRaw(pBytes));
		}

		private static byte[] ExpandBytesToRaw(byte[] pBytes) {
			var result = new byte[CharacterCount];

			int byteIndex = 0;
			for (int i = 0; i < 6; i++) {
				int baseIndex = i * 3;
				// Yes, I know the top left operation and the bottom right operation end up at being completely useless
				// It's a stylistic thing
				result[byteIndex++] = (byte)(((pBytes[baseIndex + 0] & 0x00) << 6) | (pBytes[baseIndex + 0] >> 2));
				result[byteIndex++] = (byte)(((pBytes[baseIndex + 0] & 0x03) << 4) | (pBytes[baseIndex + 1] >> 4));
				result[byteIndex++] = (byte)(((pBytes[baseIndex + 1] & 0x0F) << 2) | (pBytes[baseIndex + 2] >> 6));
				result[byteIndex++] = (byte)(((pBytes[baseIndex + 2] & 0x3F) << 0) | (pBytes[baseIndex + 0] >> 8));
			}

			return result;
		}

		private static string ConvertRawBytesToMetroidString(byte[] pRawBytes) {
			var result = new StringBuilder();
			foreach (byte b in pRawBytes) {
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
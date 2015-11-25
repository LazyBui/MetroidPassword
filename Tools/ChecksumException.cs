using System;

namespace MetroidPassword.Tools {
	internal sealed class ChecksumException : Exception {
		public ChecksumException(string message) : base(message) { }
	}
}
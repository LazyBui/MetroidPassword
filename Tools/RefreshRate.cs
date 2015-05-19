using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroidPassword.Tools {
	internal sealed class RefreshRate {
		public int Value { get; private set; }
		public static RefreshRate Ntsc = new RefreshRate(60);
		public static RefreshRate Pal = new RefreshRate(50);

		private RefreshRate(int pValue) {
			if (pValue != 60 && pValue != 50) throw new ArgumentException("Must be 50 or 60", nameof(pValue));
			Value = pValue;
		}
	}
}
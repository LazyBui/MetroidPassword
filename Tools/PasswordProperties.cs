using System;
using System.Linq;
using BitPackerTools.Serialization;

namespace MetroidPassword.Tools {
	internal sealed class PasswordProperties {
		public const int TotalBits = 144;
		public const int InformationBits = 128;

		[PackedBitRange(1)] public bool MorphBallTaken { get; set; }
		[PackedBitRange(2)] public bool BrinstarMissileContainer1 { get; set; }
		[PackedBitRange(3)] public bool LongBeamRedDoor { get; set; }
		[PackedBitRange(4)] public bool TourianBridgeRedDoor { get; set; }
		[PackedBitRange(5)] public bool BrinstarEnergyTank1 { get; set; }
		[PackedBitRange(6)] public bool BombsRedDoor { get; set; }
		[PackedBitRange(7)] public bool BombsTaken { get; set; }
		[PackedBitRange(8)] public bool BrinstarIceBeamRedDoor { get; set; }
		[PackedBitRange(9)] public bool BrinstarMissileContainer2 { get; set; }
		[PackedBitRange(10)] public bool BrinstarEnergyTank2 { get; set; }
		[PackedBitRange(11)] public bool VariaSuitRedDoor { get; set; }
		[PackedBitRange(12)] public bool VariaSuitTaken { get; set; }
		[PackedBitRange(13)] public bool BrinstarEnergyTank3 { get; set; }
		[PackedBitRange(14)] public bool NorfairMissileContainer1 { get; set; }
		[PackedBitRange(15)] public bool NorfairMissileContainer2 { get; set; }
		[PackedBitRange(16)] public bool NorfairIceBeamRedDoor { get; set; }
		[PackedBitRange(17)] public bool NorfairMissileContainer3 { get; set; }
		[PackedBitRange(18)] public bool NorfairMissileContainer4 { get; set; }
		[PackedBitRange(19)] public bool NorfairMissileContainer5 { get; set; }
		[PackedBitRange(20)] public bool NorfairMissileContainer6 { get; set; }
		[PackedBitRange(21)] public bool NorfairMissileContainer7 { get; set; }
		[PackedBitRange(22)] public bool NorfairMissileContainer8 { get; set; }
		[PackedBitRange(23)] public bool NorfairMissileContainer9 { get; set; }
		[PackedBitRange(24)] public bool HighJumpBootsRedDoor { get; set; }
		[PackedBitRange(25)] public bool HighJumpBootsTaken { get; set; }
		[PackedBitRange(26)] public bool ScrewAttackRedDoor { get; set; }
		[PackedBitRange(27)] public bool ScrewAttackTaken { get; set; }
		[PackedBitRange(28)] public bool NorfairMissileContainer10 { get; set; }
		[PackedBitRange(29)] public bool NorfairMissileContainer11 { get; set; }
		[PackedBitRange(30)] public bool WaveBeamRedDoor { get; set; }
		[PackedBitRange(31)] public bool NorfairEnergyTank { get; set; }
		[PackedBitRange(32)] public bool NorfairMissileContainer12 { get; set; }
		[PackedBitRange(33)] public bool KraidLairRedDoor1 { get; set; }
		[PackedBitRange(34)] public bool KraidLairMissileContainer1 { get; set; }
		[PackedBitRange(35)] public bool KraidLairMissileContainer2 { get; set; }
		[PackedBitRange(36)] public bool KraidLairRedDoor2 { get; set; }
		[PackedBitRange(37)] public bool KraidLairEnergyTank { get; set; }
		[PackedBitRange(38)] public bool KraidLairRedDoor3 { get; set; }
		[PackedBitRange(39)] public bool KraidLairRedDoor4 { get; set; }
		[PackedBitRange(40)] public bool KraidLairMissileContainer3 { get; set; }
		[PackedBitRange(41)] public bool KraidLairMissileContainer4 { get; set; }
		[PackedBitRange(42)] public bool KraidRoomRedDoor { get; set; }
		[PackedBitRange(43)] public bool KraidRoomEnergyTank { get; set; }
		[PackedBitRange(44)] public bool RidleyLairMissileContainer1 { get; set; }
		[PackedBitRange(45)] public bool RidleyLairRedDoor { get; set; }
		[PackedBitRange(46)] public bool RidleyLairEnergyTank { get; set; }
		[PackedBitRange(47)] public bool RidleyLairMissileContainer2 { get; set; }
		[PackedBitRange(48)] public bool RidleyLairYellowDoor { get; set; }
		[PackedBitRange(49)] public bool RidleyEnergyTank { get; set; }
		[PackedBitRange(50)] public bool RidleyLairMissileContainer3 { get; set; }
		[PackedBitRange(51)] public bool TourianYellowDoor { get; set; }
		[PackedBitRange(52)] public bool TourianRedDoor1 { get; set; }
		[PackedBitRange(53)] public bool TourianRedDoor2 { get; set; }
		[PackedBitRange(54)] public bool Zebetite1Dead { get; set; }
		[PackedBitRange(55)] public bool Zebetite2Dead { get; set; }
		[PackedBitRange(56)] public bool Zebetite3Dead { get; set; }
		[PackedBitRange(57)] public bool Zebetite4Dead { get; set; }
		[PackedBitRange(58)] public bool Zebetite5Dead { get; set; }
		[PackedBitRange(59)] public bool MotherBrainDead { get; set; }
		[PackedBitRange(60, 64)] public byte Unk1 { get; set; }
		[PackedBitRange(65)] public bool RawStartInNorfair { get; set; }
		[PackedBitRange(66)] public bool RawStartInKraidLair { get; set; }
		[PackedBitRange(67)] public bool RawStartInRidleyLair { get; set; }
		[PackedBitRange(68)] public bool Reset { get; set; }
		[PackedBitRange(69, 71)] public byte Unk2 { get; set; }
		[PackedBitRange(72)] public bool Swimsuit { get; set; }
		[PackedBitRange(73)] public bool HasBombs { get; set; }
		[PackedBitRange(74)] public bool HasHighJumpBoots { get; set; }
		[PackedBitRange(75)] public bool HasLongBeam { get; set; }
		[PackedBitRange(76)] public bool HasScrewAttack { get; set; }
		[PackedBitRange(77)] public bool HasMorphBall { get; set; }
		[PackedBitRange(78)] public bool HasVariaSuit { get; set; }
		[PackedBitRange(79)] public bool RawHasWaveBeam { get; set; }
		[PackedBitRange(80)] public bool RawHasIceBeam { get; set; }
		[PackedBitRange(81)] public bool MissileCount1 { get; set; }
		[PackedBitRange(82)] public bool MissileCount2 { get; set; }
		[PackedBitRange(83)] public bool MissileCount4 { get; set; }
		[PackedBitRange(84)] public bool MissileCount8 { get; set; }
		[PackedBitRange(85)] public bool MissileCount16 { get; set; }
		[PackedBitRange(86)] public bool MissileCount32 { get; set; }
		[PackedBitRange(87)] public bool MissileCount64 { get; set; }
		[PackedBitRange(88)] public bool MissileCount128 { get; set; }
		[PackedBitRange(89, 120)] public uint GameAge { get; set; }
		[PackedBitRange(121, 124)] public byte Unk3 { get; set; }
		[PackedBitRange(125)] public bool RidleyDead { get; set; }
		[PackedBitRange(126)] public bool RidleyStatueRaised { get; set; }
		[PackedBitRange(127)] public bool KraidDead { get; set; }
		[PackedBitRange(128)] public bool KraidStatueRaised { get; set; }

		public byte Shift { get; set; }
		public byte Checksum { get; set; }

		public int MissileCount {
			get {
				int missiles = 0;
				missiles |= (MissileCount128 ? 0x80 : 0);
				missiles |= (MissileCount64 ? 0x40 : 0);
				missiles |= (MissileCount32 ? 0x20 : 0);
				missiles |= (MissileCount16 ? 0x10 : 0);
				missiles |= (MissileCount8 ? 0x8 : 0);
				missiles |= (MissileCount4 ? 0x4 : 0);
				missiles |= (MissileCount2 ? 0x2 : 0);
				missiles |= (MissileCount1 ? 0x1 : 0);
				return missiles;
			}
			set {
				MissileCount128 = (value & 0x80) == 0x80;
				MissileCount64 = (value & 0x40) == 0x40;
				MissileCount32 = (value & 0x20) == 0x20;
				MissileCount16 = (value & 0x10) == 0x10;
				MissileCount8 = (value & 0x8) == 0x8;
				MissileCount4 = (value & 0x4) == 0x4;
				MissileCount2 = (value & 0x2) == 0x2;
				MissileCount1 = (value & 0x1) == 0x1;
			}
		}

		public bool StartInNorfair {
			get { return RawStartInNorfair; }
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawStartInNorfair = true;
				RawStartInKraidLair = false;
				RawStartInRidleyLair = false;
			}
		}

		public bool StartInKraidLair {
			get { return RawStartInKraidLair; }
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawStartInNorfair = false;
				RawStartInKraidLair = true;
				RawStartInRidleyLair = false;
			}
		}

		public bool StartInRidleyLair {
			get { return RawStartInRidleyLair; }
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawStartInNorfair = false;
				RawStartInKraidLair = false;
				RawStartInRidleyLair = true;
			}
		}

		public bool StartInBrinstar {
			get {
				return !new[] { RawStartInNorfair, RawStartInKraidLair, RawStartInRidleyLair }.Any(b => b);
			}
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawStartInNorfair = false;
				RawStartInKraidLair = false;
				RawStartInRidleyLair = false;
			}
		}

		public bool StartInTourian {
			get {
				return new[] { RawStartInNorfair, RawStartInKraidLair }.All(b => b);
			}
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawStartInNorfair = true;
				RawStartInKraidLair = true;
				RawStartInRidleyLair = false;
			}
		}

		public bool HasWaveBeam {
			get { return RawHasWaveBeam; }
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawHasIceBeam = false;
				RawHasWaveBeam = true;
			}
		}

		public bool HasIceBeam {
			get { return RawHasIceBeam; }
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawHasIceBeam = true;
				RawHasWaveBeam = false;
			}
		}

		public bool HasNormalBeam {
			get { return !(RawHasIceBeam || RawHasWaveBeam); }
			set {
				if (!value) throw new ArgumentException("Boolean must be true, only set the one that should be populated");
				RawHasIceBeam = false;
				RawHasWaveBeam = false;
			}
		}

		public uint GetGameTimeInSeconds(int pRefreshRate) {
			if (pRefreshRate != 60 && pRefreshRate != 50) throw new ArgumentException("pRefreshRate must be 50 or 60");
			double gameTick = 256.0 / pRefreshRate;
			return (uint)(GameAge * gameTick);
		}

		public void SetGameTime(uint pSeconds, int pRefreshRate) {
			if (pRefreshRate != 60 && pRefreshRate != 50) throw new ArgumentException("pRefreshRate must be 50 or 60");
			double gameTick = 256.0 / pRefreshRate;
			GameAge = (uint)(pSeconds * gameTick);
		}
	}
}
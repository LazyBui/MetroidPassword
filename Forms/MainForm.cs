using System;
using System.Drawing;
using System.Windows.Forms;
using MetroidPassword.Tools;

namespace MetroidPassword.Forms {
	public partial class MainForm : Form {
		private PasswordProperties Current { get; set; }
		private bool Updating { get; set; }
		private Color DefaultTextBackColor { get; set; }

		public MainForm() {
			InitializeComponent();

			DefaultTextBackColor = txtUnk1.BackColor;
			Current = new PasswordProperties();
			UpdatePropertyDisplay();
		}

		private void btnImport_Click(object sender, EventArgs e) {
			var importer = new Importer();
			if (importer.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				var password = new Password(importer.Password);
				Current = password.Properties;
				UpdatePropertyDisplay();
			}
		}

		private void UpdatePassword() {
			var encoded = new Password(Current);
			var parts = AlphabetMapper.Split(encoded.Encoded);
			txtRaw.Text = string.Join(" ", parts);
		}

		private void UpdatePropertyDisplay() {
			// This updating code is here because each of the property settings in here triggers additional events
			// Which then, unsurprisingly, trigger this
			Updating = true;

			UpdatePassword();

			if (Current.StartInBrinstar) rbBrinstar.Checked = true;
			else if (Current.StartInTourian) rbTourian.Checked = true;
			else if (Current.StartInKraidLair) rbKraidLair.Checked = true;
			else if (Current.StartInNorfair) rbNorfair.Checked = true;
			else if (Current.StartInRidleyLair) rbRidleyLair.Checked = true;

			if (Current.HasWaveBeam) rbHasWaveBeam.Checked = true;
			else if (Current.HasIceBeam) rbHasIceBeam.Checked = true;
			else rbHasNeither.Checked = true;

			chkHasBombs.Checked = Current.HasBombs;
			chkBombsTaken.Checked = Current.BombsTaken;

			chkHasMorphBall.Checked = Current.HasMorphBall;
			chkMorphBallTaken.Checked = Current.MorphBallTaken;

			chkHasLongBeam.Checked = Current.HasLongBeam;

			chkHasVariaSuit.Checked = Current.HasVariaSuit;
			chkVariaSuitTaken.Checked = Current.VariaSuitTaken;

			chkHasScrewAttack.Checked = Current.HasScrewAttack;
			chkScrewAttackTaken.Checked = Current.ScrewAttackTaken;

			chkHasHighJumpBoots.Checked = Current.HasHighJumpBoots;
			chkHighJumpBootsTaken.Checked = Current.HighJumpBootsTaken;

			chkKraidDead.Checked = Current.KraidDead;
			chkKraidStatueRaised.Checked = Current.KraidStatueRaised;

			chkRidleyDead.Checked = Current.RidleyDead;
			chkRidleyStatueRaised.Checked = Current.RidleyStatueRaised;

			chkZebetite1Dead.Checked = Current.Zebetite1Dead;
			chkZebetite2Dead.Checked = Current.Zebetite2Dead;
			chkZebetite3Dead.Checked = Current.Zebetite3Dead;
			chkZebetite4Dead.Checked = Current.Zebetite4Dead;
			chkZebetite5Dead.Checked = Current.Zebetite5Dead;
			chkMotherBrainDead.Checked = Current.MotherBrainDead;

			chkReset.Checked = Current.Reset;

			if (Current.Swimsuit) rbHasSwimsuit.Checked = true;
			else rbNormalSuit.Checked = true;

			txtMissiles.Text = Current.MissileCount.ToString();

			txtUnk1.Text = Current.Unk1.ToString();
			txtUnk2.Text = Current.Unk2.ToString();
			txtUnk3.Text = Current.Unk3.ToString();

			chkRidleyEnergyTank.Checked = Current.RidleyEnergyTank;
			chkRidleyLairEnergyTank.Checked = Current.RidleyLairEnergyTank;
			chkKraidEnergyTank.Checked = Current.KraidRoomEnergyTank;
			chkKraidLairEnergyTank.Checked = Current.KraidLairEnergyTank;
			chkNorfairEnergyTank.Checked = Current.NorfairEnergyTank;
			chkBrinstarEnergyTank1.Checked = Current.BrinstarEnergyTank1;
			chkBrinstarEnergyTank2.Checked = Current.BrinstarEnergyTank2;
			chkBrinstarEnergyTank3.Checked = Current.BrinstarEnergyTank3;

			chkBrinstarMissileContainer1.Checked = Current.BrinstarMissileContainer1;
			chkBrinstarMissileContainer2.Checked = Current.BrinstarMissileContainer2;

			chkNorfairMissileContainer1.Checked = Current.NorfairMissileContainer1;
			chkNorfairMissileContainer2.Checked = Current.NorfairMissileContainer2;
			chkNorfairMissileContainer3.Checked = Current.NorfairMissileContainer3;
			chkNorfairMissileContainer4.Checked = Current.NorfairMissileContainer4;
			chkNorfairMissileContainer5.Checked = Current.NorfairMissileContainer5;
			chkNorfairMissileContainer6.Checked = Current.NorfairMissileContainer6;
			chkNorfairMissileContainer7.Checked = Current.NorfairMissileContainer7;
			chkNorfairMissileContainer8.Checked = Current.NorfairMissileContainer8;
			chkNorfairMissileContainer9.Checked = Current.NorfairMissileContainer9;
			chkNorfairMissileContainer10.Checked = Current.NorfairMissileContainer10;
			chkNorfairMissileContainer11.Checked = Current.NorfairMissileContainer11;
			chkNorfairMissileContainer12.Checked = Current.NorfairMissileContainer12;

			chkRidleyLairMissileContainer1.Checked = Current.RidleyLairMissileContainer1;
			chkRidleyLairMissileContainer2.Checked = Current.RidleyLairMissileContainer2;
			chkRidleyLairMissileContainer3.Checked = Current.RidleyLairMissileContainer3;

			chkKraidLairMissileContainer1.Checked = Current.KraidLairMissileContainer1;
			chkKraidLairMissileContainer2.Checked = Current.KraidLairMissileContainer2;
			chkKraidLairMissileContainer3.Checked = Current.KraidLairMissileContainer3;
			chkKraidLairMissileContainer4.Checked = Current.KraidLairMissileContainer4;

			chkWaveBeamRedDoor.Checked = Current.WaveBeamRedDoor;
			chkScrewAttackRedDoor.Checked = Current.ScrewAttackRedDoor;
			chkHighJumpBootsRedDoor.Checked = Current.HighJumpBootsRedDoor;
			chkVariaSuitRedDoor.Checked = Current.VariaSuitRedDoor;
			chkBombsRedDoor.Checked = Current.BombsRedDoor;
			chkBrinstarIceBeamRedDoor.Checked = Current.BrinstarIceBeamRedDoor;
			chkNorfairIceBeamRedDoor.Checked = Current.NorfairIceBeamRedDoor;
			chkLongBeamRedDoor.Checked = Current.LongBeamRedDoor;

			chkKraidLairRedDoor1.Checked = Current.KraidLairRedDoor1;
			chkKraidLairRedDoor2.Checked = Current.KraidLairRedDoor2;
			chkKraidLairRedDoor3.Checked = Current.KraidLairRedDoor3;
			chkKraidLairRedDoor4.Checked = Current.KraidLairRedDoor4;
			chkKraidRoomRedDoor.Checked = Current.KraidRoomRedDoor;
			chkTourianBridgeRedDoor.Checked = Current.TourianBridgeRedDoor;
			chkTourianRedDoor1.Checked = Current.TourianRedDoor1;
			chkTourianRedDoor2.Checked = Current.TourianRedDoor2;

			chkRidleyLairRedDoor.Checked = Current.RidleyLairRedDoor;
			chkRidleyLairYellowDoor.Checked = Current.RidleyLairYellowDoor;
			chkTourianYellowDoor.Checked = Current.TourianYellowDoor;

			uint gameTime = Current.GetGameTimeInSeconds(60);
			uint hours = gameTime / 60 / 60;
			uint minutes = (gameTime - (hours * 60 * 60)) / 60;
			uint seconds = (gameTime - (hours * 60 * 60) - (minutes * 60));
			txtGameTime.Text = Current.GameAge.ToString();
			lblGameTime.Text = string.Format("Approx {0:00}:{1:00}:{2:00}",
				hours,
				minutes,
				seconds);

			txtShift.Text = Current.Shift.ToString();
			txtChecksum.Text = Current.Checksum.ToString();

			Updating = false;
		}

		private void btnExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void chkHasVariaSuit_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HasVariaSuit = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkVariaSuitTaken_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.VariaSuitTaken = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void rbBrinstar_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.StartInTourian = false;
			Current.StartInRidleyLair = false;
			Current.StartInKraidLair = false;
			Current.StartInNorfair = false;
			Current.StartInBrinstar = true;
			UpdatePropertyDisplay();
		}

		private void rbKraidLair_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.StartInTourian = false;
			Current.StartInRidleyLair = false;
			Current.StartInNorfair = false;
			Current.StartInBrinstar = false;
			Current.StartInKraidLair = true;
			UpdatePropertyDisplay();
		}

		private void rbNorfair_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.StartInTourian = false;
			Current.StartInRidleyLair = false;
			Current.StartInKraidLair = false;
			Current.StartInBrinstar = false;
			Current.StartInNorfair = true;
			UpdatePropertyDisplay();
		}

		private void rbRidleyLair_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.StartInTourian = false;
			Current.StartInKraidLair = false;
			Current.StartInNorfair = false;
			Current.StartInBrinstar = false;
			Current.StartInRidleyLair = true;
			UpdatePropertyDisplay();
		}

		private void rbTourian_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.StartInRidleyLair = false;
			Current.StartInKraidLair = false;
			Current.StartInNorfair = false;
			Current.StartInBrinstar = false;
			Current.StartInTourian = true;
			UpdatePropertyDisplay();
		}

		private void chkHasScrewAttack_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HasScrewAttack = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkScrewAttackTaken_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.ScrewAttackTaken = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void rbHasWaveBeam_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			// We only care about these when their toggle state is on because the message is sent to the old one as well
			// e.g. if I have rbHasNeither currently checked and then check rbHasWaveBeam:
			// rbHasNeither_CheckedChanged fires
			// rbHasWaveBeam_CheckedChanged fires
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.HasWaveBeam = true;
			Current.HasIceBeam = false;
			UpdatePropertyDisplay();
		}

		private void rbHasIceBeam_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.HasWaveBeam = false;
			Current.HasIceBeam = true;
			UpdatePropertyDisplay();
		}

		private void rbHasNeither_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			bool newValue = (sender as RadioButton).Checked;
			if (!newValue) return;
			Current.HasIceBeam = false;
			Current.HasWaveBeam = false;
			UpdatePropertyDisplay();
		}

		private void chkHasLongBeam_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HasLongBeam = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkHasMorphBall_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HasMorphBall = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkMorphBallTaken_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.MorphBallTaken = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkHasHighJumpBoots_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HasHighJumpBoots = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkHighJumpBootsTaken_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HighJumpBootsTaken = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkHasBombs_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HasBombs = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBombsTaken_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BombsTaken = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyDead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyDead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidDead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidDead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkMotherBrainDead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.MotherBrainDead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void rbHasSwimsuit_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.Swimsuit = (sender as RadioButton).Checked;
			UpdatePropertyDisplay();
		}

		private void chkReset_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.Reset = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidStatueRaised_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidStatueRaised = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyStatueRaised_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyStatueRaised = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkZebetite1Dead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.Zebetite1Dead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkZebetite2Dead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.Zebetite2Dead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkZebetite3Dead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.Zebetite3Dead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkZebetite4Dead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.Zebetite4Dead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkZebetite5Dead_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.Zebetite5Dead = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void txtUnk1_TextChanged(object sender, EventArgs e) {
			if (Updating) return;
			byte value;
			var box = sender as TextBox;
			if (!byte.TryParse(box.Text, out value)) box.BackColor = Color.PaleVioletRed;
			else box.BackColor = DefaultTextBackColor;
			Current.Unk1 = value;
			UpdatePropertyDisplay();
		}

		private void txtUnk2_TextChanged(object sender, EventArgs e) {
			if (Updating) return;
			byte value;
			var box = sender as TextBox;
			if (!byte.TryParse(box.Text, out value)) box.BackColor = Color.PaleVioletRed;
			else box.BackColor = DefaultTextBackColor;
			Current.Unk2 = value;
			UpdatePropertyDisplay();
		}

		private void txtUnk3_TextChanged(object sender, EventArgs e) {
			if (Updating) return;
			byte value;
			var box = sender as TextBox;
			if (!byte.TryParse(box.Text, out value)) box.BackColor = Color.PaleVioletRed;
			else box.BackColor = DefaultTextBackColor;
			Current.Unk3 = value;
			UpdatePropertyDisplay();
		}

		private void txtShift_TextChanged(object sender, EventArgs e) {
			if (Updating) return;
			byte value;
			var box = sender as TextBox;
			if (!byte.TryParse(box.Text, out value)) box.BackColor = Color.PaleVioletRed;
			else box.BackColor = DefaultTextBackColor;
			Current.Shift = value;
			UpdatePropertyDisplay();
		}

		private void txtGameTime_TextChanged(object sender, EventArgs e) {
			if (Updating) return;
			uint value;
			var box = sender as TextBox;
			if (!uint.TryParse(box.Text, out value)) box.BackColor = Color.PaleVioletRed;
			else box.BackColor = DefaultTextBackColor;
			Current.GameAge = value;
			UpdatePropertyDisplay();
		}

		private void txtMissiles_TextChanged(object sender, EventArgs e) {
			if (Updating) return;
			byte value;
			var box = sender as TextBox;
			if (!byte.TryParse(box.Text, out value)) box.BackColor = Color.PaleVioletRed;
			else box.BackColor = DefaultTextBackColor;
			Current.MissileCount = value;
			UpdatePropertyDisplay();
		}

		private void chkKraidEnergyTank_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidRoomEnergyTank = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyEnergyTank_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyEnergyTank = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBrinstarEnergyTank3_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BrinstarEnergyTank3 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBrinstarEnergyTank2_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BrinstarEnergyTank2 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBrinstarEnergyTank1_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BrinstarEnergyTank1 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyLairEnergyTank_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyLairEnergyTank = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairEnergyTank_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairEnergyTank = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairEnergyTank_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairEnergyTank = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBrinstarMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BrinstarMissileContainer1 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBrinstarMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BrinstarMissileContainer2 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer1 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer2 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer3_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer3 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer4_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer4 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer5_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer5 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer6_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer6 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer7_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer7 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer8_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer8 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer9_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer9 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer10_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer10 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer11_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer11 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairMissileContainer12_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairMissileContainer12 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyLairMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyLairMissileContainer1 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyLairMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyLairMissileContainer2 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyLairMissileContainer3_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyLairMissileContainer3 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairMissileContainer1 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairMissileContainer2 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairMissileContainer3_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairMissileContainer3 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairMissileContainer4_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairMissileContainer4 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyLairRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyLairRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkRidleyLairYellowDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.RidleyLairYellowDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkTourianYellowDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.TourianYellowDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkWaveBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.WaveBeamRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkScrewAttackRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.ScrewAttackRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkHighJumpBootsRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.HighJumpBootsRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkVariaSuitRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.VariaSuitRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBombsRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BombsRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkLongBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.LongBeamRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkNorfairIceBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.NorfairIceBeamRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkBrinstarIceBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.BrinstarIceBeamRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairRedDoor1_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairRedDoor1 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairRedDoor2_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairRedDoor2 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairRedDoor3_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairRedDoor3 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidLairRedDoor4_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidLairRedDoor4 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkKraidRoomRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.KraidRoomRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkTourianBridgeRedDoor_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.TourianBridgeRedDoor = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkTourianRedDoor1_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.TourianRedDoor1 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}

		private void chkTourianRedDoor2_CheckedChanged(object sender, EventArgs e) {
			if (Updating) return;
			Current.TourianRedDoor2 = (sender as CheckBox).Checked;
			UpdatePropertyDisplay();
		}
	}
}

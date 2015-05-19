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

			DefaultTextBackColor = txtGameTime.BackColor;
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

			uint gameTime = Current.GetGameTimeInSeconds(RefreshRate.Ntsc);
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
			CheckboxCheckedChanged(sender, v => {
				Current.HasVariaSuit = v;
			});
		}

		private void chkVariaSuitTaken_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.VariaSuitTaken = v;
			});
		}

		private void rbBrinstar_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.StartInBrinstar = true;
			});
		}

		private void rbKraidLair_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.StartInKraidLair = true;
			});
		}

		private void rbNorfair_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.StartInNorfair = true;
			});
		}

		private void rbRidleyLair_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.StartInRidleyLair = true;
			});
		}

		private void rbTourian_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.StartInTourian = true;
			});
		}

		private void chkHasScrewAttack_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.HasScrewAttack = v;
			});
		}

		private void chkScrewAttackTaken_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.ScrewAttackTaken = v;
			});
		}

		private void rbHasWaveBeam_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.HasWaveBeam = true;
			});
		}

		private void rbHasIceBeam_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.HasIceBeam = true;
			});
		}

		private void rbHasNeither_CheckedChanged(object sender, EventArgs e) {
			RadioButtonCheckedChanged(sender, () => {
				Current.HasNormalBeam = true;
			});
		}

		private void chkHasLongBeam_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.HasLongBeam = v;
			});
		}

		private void chkHasMorphBall_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.HasMorphBall = v;
			});
		}

		private void chkMorphBallTaken_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.MorphBallTaken = v;
			});
		}

		private void chkHasHighJumpBoots_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.HasHighJumpBoots = v;
			});
		}

		private void chkHighJumpBootsTaken_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.HighJumpBootsTaken = v;
			});
		}

		private void chkHasBombs_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.HasBombs = v;
			});
		}

		private void chkBombsTaken_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BombsTaken = v;
			});
		}

		private void chkRidleyDead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyDead = v;
			});
		}

		private void chkKraidDead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidDead = v;
			});
		}

		private void chkMotherBrainDead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.MotherBrainDead = v;
			});
		}

		private void rbHasSwimsuit_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.Swimsuit = v;
			});
		}

		private void chkReset_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.Reset = v;
			});
		}

		private void chkKraidStatueRaised_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidStatueRaised = v;
			});
		}

		private void chkRidleyStatueRaised_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyStatueRaised = v;
			});
		}

		private void chkZebetite1Dead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.Zebetite1Dead = v;
			});
		}

		private void chkZebetite2Dead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.Zebetite2Dead = v;
			});
		}

		private void chkZebetite3Dead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.Zebetite3Dead = v;
			});
		}

		private void chkZebetite4Dead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.Zebetite4Dead = v;
			});
		}

		private void chkZebetite5Dead_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.Zebetite5Dead = v;
			});
		}

		private void txtUnk1_TextChanged(object sender, EventArgs e) {
			TextBoxChanged<byte>(sender,
				s => {
					byte value;
					return Tuple.Create(byte.TryParse(s, out value), value);
				},
				v => {
					Current.Unk1 = v;
				}
			);
		}

		private void txtUnk2_TextChanged(object sender, EventArgs e) {
			TextBoxChanged<byte>(sender,
				s => {
					byte value;
					return Tuple.Create(byte.TryParse(s, out value), value);
				},
				v => {
					Current.Unk2 = v;
				}
			);
		}

		private void txtUnk3_TextChanged(object sender, EventArgs e) {
			TextBoxChanged<byte>(sender,
				s => {
					byte value;
					return Tuple.Create(byte.TryParse(s, out value), value);
				},
				v => {
					Current.Unk3 = v;
				}
			);
		}

		private void txtShift_TextChanged(object sender, EventArgs e) {
			TextBoxChanged<byte>(sender,
				s => {
					byte value;
					return Tuple.Create(byte.TryParse(s, out value), value);
				},
				v => {
					Current.Shift = v;
				}
			);
		}

		private void txtGameTime_TextChanged(object sender, EventArgs e) {
			TextBoxChanged<uint>(sender,
				s => {
					uint value;
					return Tuple.Create(uint.TryParse(s, out value), value);
				},
				v => {
					Current.GameAge = v;
				}
			);
		}

		private void txtMissiles_TextChanged(object sender, EventArgs e) {
			TextBoxChanged<byte>(sender,
				s => {
					byte value;
					return Tuple.Create(byte.TryParse(s, out value), value);
				},
				v => {
					Current.MissileCount = v;
				}
			);
		}

		private void chkKraidEnergyTank_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidRoomEnergyTank = v;
			});
		}

		private void chkRidleyEnergyTank_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyEnergyTank = v;
			});
		}

		private void chkBrinstarEnergyTank3_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BrinstarEnergyTank3 = v;
			});
		}

		private void chkBrinstarEnergyTank2_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BrinstarEnergyTank2 = v;
			});
		}

		private void chkBrinstarEnergyTank1_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BrinstarEnergyTank1 = v;
			});
		}

		private void chkRidleyLairEnergyTank_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyLairEnergyTank = v;
			});
		}

		private void chkKraidLairEnergyTank_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairEnergyTank = v;
			});
		}

		private void chkNorfairEnergyTank_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairEnergyTank = v;
			});
		}

		private void chkBrinstarMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BrinstarMissileContainer1 = v;
			});
		}

		private void chkBrinstarMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BrinstarMissileContainer2 = v;
			});
		}

		private void chkNorfairMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer1 = v;
			});
		}

		private void chkNorfairMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer2 = v;
			});
		}

		private void chkNorfairMissileContainer3_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer3 = v;
			});
		}

		private void chkNorfairMissileContainer4_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer4 = v;
			});
		}

		private void chkNorfairMissileContainer5_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer5 = v;
			});
		}

		private void chkNorfairMissileContainer6_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer6 = v;
			});
		}

		private void chkNorfairMissileContainer7_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer7 = v;
			});
		}

		private void chkNorfairMissileContainer8_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer8 = v;
			});
		}

		private void chkNorfairMissileContainer9_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer9 = v;
			});
		}

		private void chkNorfairMissileContainer10_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer10 = v;
			});
		}

		private void chkNorfairMissileContainer11_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer11 = v;
			});
		}

		private void chkNorfairMissileContainer12_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairMissileContainer12 = v;
			});
		}

		private void chkRidleyLairMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyLairMissileContainer1 = v;
			});
		}

		private void chkRidleyLairMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyLairMissileContainer2 = v;
			});
		}

		private void chkRidleyLairMissileContainer3_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyLairMissileContainer3 = v;
			});
		}

		private void chkKraidLairMissileContainer1_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairMissileContainer1 = v;
			});
		}

		private void chkKraidLairMissileContainer2_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairMissileContainer2 = v;
			});
		}

		private void chkKraidLairMissileContainer3_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairMissileContainer3 = v;
			});
		}

		private void chkKraidLairMissileContainer4_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairMissileContainer4 = v;
			});
		}

		private void chkRidleyLairRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyLairRedDoor = v;
			});
		}

		private void chkRidleyLairYellowDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.RidleyLairYellowDoor = v;
			});
		}

		private void chkTourianYellowDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.TourianYellowDoor = v;
			});
		}

		private void chkWaveBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.WaveBeamRedDoor = v;
			});
		}

		private void chkScrewAttackRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.ScrewAttackRedDoor = v;
			});
		}

		private void chkHighJumpBootsRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.HighJumpBootsRedDoor = v;
			});
		}

		private void chkVariaSuitRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.VariaSuitRedDoor = v;
			});
		}

		private void chkBombsRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BombsRedDoor = v;
			});
		}

		private void chkLongBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.LongBeamRedDoor = v;
			});
		}

		private void chkNorfairIceBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.NorfairIceBeamRedDoor = v;
			});
		}

		private void chkBrinstarIceBeamRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.BrinstarIceBeamRedDoor = v;
			});
		}

		private void chkKraidLairRedDoor1_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairRedDoor1 = v;
			});
		}

		private void chkKraidLairRedDoor2_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairRedDoor2 = v;
			});
		}

		private void chkKraidLairRedDoor3_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairRedDoor3 = v;
			});
		}

		private void chkKraidLairRedDoor4_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidLairRedDoor4 = v;
			});
		}

		private void chkKraidRoomRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.KraidRoomRedDoor = v;
			});
		}

		private void chkTourianBridgeRedDoor_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.TourianBridgeRedDoor = v;
			});
		}

		private void chkTourianRedDoor1_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.TourianRedDoor1 = v;
			});
		}

		private void chkTourianRedDoor2_CheckedChanged(object sender, EventArgs e) {
			CheckboxCheckedChanged(sender, v => {
				Current.TourianRedDoor2 = v;
			});
		}

		private void CheckboxCheckedChanged(object pSender, Action<bool> pAction) {
			if (Updating) return;
			pAction((pSender as CheckBox).Checked);
			UpdatePropertyDisplay();
		}

		private void RadioButtonCheckedChanged(object pSender, Action pAction) {
			if (Updating) return;
			bool newValue = (pSender as RadioButton).Checked;
			if (!newValue) return;
			pAction();
			UpdatePropertyDisplay();
		}

		private void TextBoxChanged<TResult>(object pSender, Func<string, Tuple<bool, TResult>> pValidate, Action<TResult> pAction) {
			if (Updating) return;
			var box = pSender as TextBox;
			var result = pValidate(box.Text);
			if (!result.Item1) {
				box.BackColor = Color.PaleVioletRed;
				return;
			}
			box.BackColor = DefaultTextBackColor;
			pAction(result.Item2);
			UpdatePropertyDisplay();
		}
	}
}
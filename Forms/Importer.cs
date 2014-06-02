using System;
using System.Windows.Forms;
using MetroidPassword.Tools;

namespace MetroidPassword.Forms {
	public partial class Importer : Form {
		public string Password { get; private set; }

		public Importer() {
			InitializeComponent();
		}

		private string MakePassword() {
			return string.Join("", new[] { txtPart1.Text, txtPart2.Text, txtPart3.Text, txtPart4.Text });
		}

		private bool IsImportable() {
			if (string.IsNullOrEmpty(txtPart1.Text)) return false;
			if (string.IsNullOrEmpty(txtPart2.Text)) return false;
			if (string.IsNullOrEmpty(txtPart3.Text)) return false;
			if (string.IsNullOrEmpty(txtPart4.Text)) return false;
			try {
				var password = new Password(MakePassword());
				lblError.Text = string.Empty;
				return true;
			}
			catch (ArgumentException) { lblError.Text = "Invalid character(s)"; }
			catch (ChecksumException) { lblError.Text = "Invalid password"; }

			return false;
		}

		private void CheckButton() {
			btnImport.Enabled = IsImportable();
		}

		private void txtPart1_TextChanged(object sender, EventArgs e) {
			if ((sender as TextBox).TextLength == AlphabetMapper.PartCharacterLength) txtPart2.Focus();
			CheckButton();
		}

		private void txtPart2_TextChanged(object sender, EventArgs e) {
			if ((sender as TextBox).TextLength == AlphabetMapper.PartCharacterLength) txtPart3.Focus();
			CheckButton();
		}

		private void txtPart3_TextChanged(object sender, EventArgs e) {
			if ((sender as TextBox).TextLength == AlphabetMapper.PartCharacterLength) txtPart4.Focus();
			CheckButton();
		}

		private void txtPart4_TextChanged(object sender, EventArgs e) {
			if ((sender as TextBox).TextLength == AlphabetMapper.PartCharacterLength) btnImport.Focus();
			CheckButton();
		}

		private void txtPart1_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyCode == Keys.V) {
				string text = Clipboard.GetText();
				try {
					string[] parts = AlphabetMapper.Split(text);
					txtPart1.Text = parts[0];
					txtPart2.Text = parts[1];
					txtPart3.Text = parts[2];
					txtPart4.Text = parts[3];
					CheckButton();
				}
				catch (Exception) {
					lblError.Text = "Paste failed; invalid format";
				}
				e.SuppressKeyPress = true;
			}
		}

		private void btnImport_Click(object sender, EventArgs e) {
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Password = MakePassword();
		}
	}
}

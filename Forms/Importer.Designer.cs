namespace MetroidPassword.Forms {
	partial class Importer {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.txtPart1 = new System.Windows.Forms.TextBox();
			this.txtPart2 = new System.Windows.Forms.TextBox();
			this.txtPart3 = new System.Windows.Forms.TextBox();
			this.txtPart4 = new System.Windows.Forms.TextBox();
			this.btnImport = new System.Windows.Forms.Button();
			this.lblError = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtPart1
			// 
			this.txtPart1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPart1.Location = new System.Drawing.Point(4, 6);
			this.txtPart1.MaxLength = 6;
			this.txtPart1.Name = "txtPart1";
			this.txtPart1.Size = new System.Drawing.Size(110, 22);
			this.txtPart1.TabIndex = 0;
			this.txtPart1.TextChanged += new System.EventHandler(this.txtPart1_TextChanged);
			this.txtPart1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPart1_KeyDown);
			// 
			// txtPart2
			// 
			this.txtPart2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPart2.Location = new System.Drawing.Point(120, 6);
			this.txtPart2.MaxLength = 6;
			this.txtPart2.Name = "txtPart2";
			this.txtPart2.Size = new System.Drawing.Size(110, 22);
			this.txtPart2.TabIndex = 1;
			this.txtPart2.TextChanged += new System.EventHandler(this.txtPart2_TextChanged);
			// 
			// txtPart3
			// 
			this.txtPart3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPart3.Location = new System.Drawing.Point(4, 34);
			this.txtPart3.MaxLength = 6;
			this.txtPart3.Name = "txtPart3";
			this.txtPart3.Size = new System.Drawing.Size(110, 22);
			this.txtPart3.TabIndex = 2;
			this.txtPart3.TextChanged += new System.EventHandler(this.txtPart3_TextChanged);
			// 
			// txtPart4
			// 
			this.txtPart4.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPart4.Location = new System.Drawing.Point(120, 34);
			this.txtPart4.MaxLength = 6;
			this.txtPart4.Name = "txtPart4";
			this.txtPart4.Size = new System.Drawing.Size(110, 22);
			this.txtPart4.TabIndex = 3;
			this.txtPart4.TextChanged += new System.EventHandler(this.txtPart4_TextChanged);
			// 
			// btnImport
			// 
			this.btnImport.Enabled = false;
			this.btnImport.Location = new System.Drawing.Point(155, 78);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 23);
			this.btnImport.TabIndex = 4;
			this.btnImport.Text = "Impo&rt";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.Location = new System.Drawing.Point(12, 83);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(0, 13);
			this.lblError.TabIndex = 5;
			// 
			// Importer
			// 
			this.AcceptButton = this.btnImport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(237, 108);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.txtPart4);
			this.Controls.Add(this.txtPart3);
			this.Controls.Add(this.txtPart2);
			this.Controls.Add(this.txtPart1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Importer";
			this.Text = "Importer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPart1;
		private System.Windows.Forms.TextBox txtPart2;
		private System.Windows.Forms.TextBox txtPart3;
		private System.Windows.Forms.TextBox txtPart4;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Label lblError;
	}
}
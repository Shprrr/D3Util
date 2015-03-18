namespace D3Util
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnLoadProfile = new System.Windows.Forms.Button();
			this.btnSaveProfile = new System.Windows.Forms.Button();
			this.cboBattleTagName = new System.Windows.Forms.ComboBox();
			this.btnGetProfile = new System.Windows.Forms.Button();
			this.txtBattleTagCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBattleTagName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.flpProfile = new System.Windows.Forms.FlowLayoutPanel();
			this.btnHero = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.grbProgression = new System.Windows.Forms.GroupBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.lblProgression = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.flpProfile.SuspendLayout();
			this.grbProgression.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnLoadProfile);
			this.groupBox1.Controls.Add(this.btnSaveProfile);
			this.groupBox1.Controls.Add(this.cboBattleTagName);
			this.groupBox1.Controls.Add(this.btnGetProfile);
			this.groupBox1.Controls.Add(this.txtBattleTagCode);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtBattleTagName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(406, 76);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Career Info";
			// 
			// btnLoadProfile
			// 
			this.btnLoadProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnLoadProfile.Location = new System.Drawing.Point(87, 47);
			this.btnLoadProfile.Name = "btnLoadProfile";
			this.btnLoadProfile.Size = new System.Drawing.Size(75, 23);
			this.btnLoadProfile.TabIndex = 6;
			this.btnLoadProfile.Text = "&Load profile";
			this.btnLoadProfile.UseVisualStyleBackColor = true;
			this.btnLoadProfile.Click += new System.EventHandler(this.btnLoadProfile_Click);
			// 
			// btnSaveProfile
			// 
			this.btnSaveProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSaveProfile.Location = new System.Drawing.Point(6, 47);
			this.btnSaveProfile.Name = "btnSaveProfile";
			this.btnSaveProfile.Size = new System.Drawing.Size(75, 23);
			this.btnSaveProfile.TabIndex = 5;
			this.btnSaveProfile.Text = "&Save profile";
			this.btnSaveProfile.UseVisualStyleBackColor = true;
			this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
			// 
			// cboBattleTagName
			// 
			this.cboBattleTagName.FormattingEnabled = true;
			this.cboBattleTagName.Location = new System.Drawing.Point(99, 19);
			this.cboBattleTagName.Name = "cboBattleTagName";
			this.cboBattleTagName.Size = new System.Drawing.Size(99, 21);
			this.cboBattleTagName.TabIndex = 1;
			this.cboBattleTagName.SelectedIndexChanged += new System.EventHandler(this.cboBattleTagName_SelectedIndexChanged);
			this.cboBattleTagName.DropDownClosed += new System.EventHandler(this.cboBattleTagName_SelectedIndexChanged);
			// 
			// btnGetProfile
			// 
			this.btnGetProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGetProfile.Location = new System.Drawing.Point(325, 47);
			this.btnGetProfile.Name = "btnGetProfile";
			this.btnGetProfile.Size = new System.Drawing.Size(75, 23);
			this.btnGetProfile.TabIndex = 4;
			this.btnGetProfile.Text = "&Get Profile";
			this.btnGetProfile.UseVisualStyleBackColor = true;
			this.btnGetProfile.Click += new System.EventHandler(this.btnGetProfile_Click);
			// 
			// txtBattleTagCode
			// 
			this.txtBattleTagCode.Location = new System.Drawing.Point(295, 19);
			this.txtBattleTagCode.Name = "txtBattleTagCode";
			this.txtBattleTagCode.Size = new System.Drawing.Size(100, 20);
			this.txtBattleTagCode.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(205, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "BattleTag Code:";
			// 
			// txtBattleTagName
			// 
			this.txtBattleTagName.Location = new System.Drawing.Point(99, 19);
			this.txtBattleTagName.Name = "txtBattleTagName";
			this.txtBattleTagName.Size = new System.Drawing.Size(100, 20);
			this.txtBattleTagName.TabIndex = 1;
			this.txtBattleTagName.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "BattleTag Name:";
			// 
			// flpProfile
			// 
			this.flpProfile.Controls.Add(this.btnHero);
			this.flpProfile.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpProfile.Location = new System.Drawing.Point(12, 94);
			this.flpProfile.Name = "flpProfile";
			this.flpProfile.Size = new System.Drawing.Size(615, 181);
			this.flpProfile.TabIndex = 1;
			// 
			// btnHero
			// 
			this.btnHero.AutoEllipsis = true;
			this.btnHero.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnHero.Location = new System.Drawing.Point(3, 3);
			this.btnHero.Name = "btnHero";
			this.btnHero.Size = new System.Drawing.Size(195, 30);
			this.btnHero.TabIndex = 0;
			this.btnHero.Text = "Shprrr Lv:33 (Barbarian)";
			this.btnHero.UseVisualStyleBackColor = true;
			this.btnHero.Click += new System.EventHandler(this.btnHero_Click);
			// 
			// grbProgression
			// 
			this.grbProgression.AutoSize = true;
			this.grbProgression.Controls.Add(this.progressBar);
			this.grbProgression.Controls.Add(this.lblProgression);
			this.grbProgression.Location = new System.Drawing.Point(683, 12);
			this.grbProgression.Name = "grbProgression";
			this.grbProgression.Size = new System.Drawing.Size(212, 97);
			this.grbProgression.TabIndex = 2;
			this.grbProgression.TabStop = false;
			this.grbProgression.UseWaitCursor = true;
			this.grbProgression.Visible = false;
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(6, 32);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(200, 23);
			this.progressBar.TabIndex = 0;
			this.progressBar.UseWaitCursor = true;
			// 
			// lblProgression
			// 
			this.lblProgression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblProgression.Location = new System.Drawing.Point(9, 58);
			this.lblProgression.Name = "lblProgression";
			this.lblProgression.Size = new System.Drawing.Size(197, 23);
			this.lblProgression.TabIndex = 1;
			this.lblProgression.Text = "0/10";
			this.lblProgression.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblProgression.UseWaitCursor = true;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "JSON Profile|*.json|All files|*.*";
			// 
			// frmMain
			// 
			this.AcceptButton = this.btnGetProfile;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 717);
			this.Controls.Add(this.grbProgression);
			this.Controls.Add(this.flpProfile);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "Diablo 3 Util";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flpProfile.ResumeLayout(false);
			this.grbProgression.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtBattleTagName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGetProfile;
		private System.Windows.Forms.TextBox txtBattleTagCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FlowLayoutPanel flpProfile;
		private System.Windows.Forms.Button btnHero;
		private System.Windows.Forms.ComboBox cboBattleTagName;
		private System.Windows.Forms.Button btnLoadProfile;
		private System.Windows.Forms.Button btnSaveProfile;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.GroupBox grbProgression;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label lblProgression;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
namespace D3Util
{
	partial class ucItemTooltip
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblName = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.picImage = new System.Windows.Forms.PictureBox();
			this.lblDpsArmor = new System.Windows.Forms.Label();
			this.lblDpsArmorText = new System.Windows.Forms.Label();
			this.lblDamage = new System.Windows.Forms.Label();
			this.lblDamageText = new System.Windows.Forms.Label();
			this.lblAttackSecond = new System.Windows.Forms.Label();
			this.lblAttackSecondText = new System.Windows.Forms.Label();
			this.flpMagicAttribute = new System.Windows.Forms.FlowLayoutPanel();
			this.lblItemLevelText = new System.Windows.Forms.Label();
			this.lblItemLevel = new System.Windows.Forms.Label();
			this.lblRequiredLevelText = new System.Windows.Forms.Label();
			this.lblRequiredLevel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblName.AutoEllipsis = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(396, 20);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblType.Location = new System.Drawing.Point(111, 23);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(31, 13);
			this.lblType.TabIndex = 1;
			this.lblType.Text = "Type";
			// 
			// picImage
			// 
			this.picImage.Location = new System.Drawing.Point(3, 23);
			this.picImage.Name = "picImage";
			this.picImage.Size = new System.Drawing.Size(82, 164);
			this.picImage.TabIndex = 23;
			this.picImage.TabStop = false;
			// 
			// lblDpsArmor
			// 
			this.lblDpsArmor.AutoSize = true;
			this.lblDpsArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDpsArmor.Location = new System.Drawing.Point(106, 36);
			this.lblDpsArmor.Name = "lblDpsArmor";
			this.lblDpsArmor.Size = new System.Drawing.Size(147, 46);
			this.lblDpsArmor.TabIndex = 24;
			this.lblDpsArmor.Text = "9999.9";
			// 
			// lblDpsArmorText
			// 
			this.lblDpsArmorText.AutoSize = true;
			this.lblDpsArmorText.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblDpsArmorText.Location = new System.Drawing.Point(111, 82);
			this.lblDpsArmorText.Name = "lblDpsArmorText";
			this.lblDpsArmorText.Size = new System.Drawing.Size(138, 13);
			this.lblDpsArmorText.TabIndex = 25;
			this.lblDpsArmorText.Text = "Damage Per Second/Armor";
			// 
			// lblDamage
			// 
			this.lblDamage.AutoSize = true;
			this.lblDamage.Location = new System.Drawing.Point(111, 119);
			this.lblDamage.Name = "lblDamage";
			this.lblDamage.Size = new System.Drawing.Size(58, 13);
			this.lblDamage.TabIndex = 26;
			this.lblDamage.Text = "9999-9999";
			// 
			// lblDamageText
			// 
			this.lblDamageText.AutoSize = true;
			this.lblDamageText.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblDamageText.Location = new System.Drawing.Point(175, 119);
			this.lblDamageText.Name = "lblDamageText";
			this.lblDamageText.Size = new System.Drawing.Size(47, 13);
			this.lblDamageText.TabIndex = 27;
			this.lblDamageText.Text = "Damage";
			// 
			// lblAttackSecond
			// 
			this.lblAttackSecond.AutoSize = true;
			this.lblAttackSecond.Location = new System.Drawing.Point(111, 132);
			this.lblAttackSecond.Name = "lblAttackSecond";
			this.lblAttackSecond.Size = new System.Drawing.Size(28, 13);
			this.lblAttackSecond.TabIndex = 26;
			this.lblAttackSecond.Text = "1.99";
			// 
			// lblAttackSecondText
			// 
			this.lblAttackSecondText.AutoSize = true;
			this.lblAttackSecondText.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblAttackSecondText.Location = new System.Drawing.Point(175, 132);
			this.lblAttackSecondText.Name = "lblAttackSecondText";
			this.lblAttackSecondText.Size = new System.Drawing.Size(101, 13);
			this.lblAttackSecondText.TabIndex = 27;
			this.lblAttackSecondText.Text = "Attacks per Second";
			// 
			// flpMagicAttribute
			// 
			this.flpMagicAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpMagicAttribute.AutoScroll = true;
			this.flpMagicAttribute.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpMagicAttribute.Location = new System.Drawing.Point(3, 193);
			this.flpMagicAttribute.Name = "flpMagicAttribute";
			this.flpMagicAttribute.Size = new System.Drawing.Size(396, 71);
			this.flpMagicAttribute.TabIndex = 28;
			// 
			// lblItemLevelText
			// 
			this.lblItemLevelText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblItemLevelText.AutoSize = true;
			this.lblItemLevelText.Location = new System.Drawing.Point(3, 267);
			this.lblItemLevelText.Name = "lblItemLevelText";
			this.lblItemLevelText.Size = new System.Drawing.Size(59, 13);
			this.lblItemLevelText.TabIndex = 29;
			this.lblItemLevelText.Text = "Item Level:";
			// 
			// lblItemLevel
			// 
			this.lblItemLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblItemLevel.AutoSize = true;
			this.lblItemLevel.Location = new System.Drawing.Point(68, 267);
			this.lblItemLevel.Name = "lblItemLevel";
			this.lblItemLevel.Size = new System.Drawing.Size(19, 13);
			this.lblItemLevel.TabIndex = 30;
			this.lblItemLevel.Text = "99";
			// 
			// lblRequiredLevelText
			// 
			this.lblRequiredLevelText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRequiredLevelText.AutoSize = true;
			this.lblRequiredLevelText.Location = new System.Drawing.Point(292, 267);
			this.lblRequiredLevelText.Name = "lblRequiredLevelText";
			this.lblRequiredLevelText.Size = new System.Drawing.Size(82, 13);
			this.lblRequiredLevelText.TabIndex = 29;
			this.lblRequiredLevelText.Text = "Required Level:";
			// 
			// lblRequiredLevel
			// 
			this.lblRequiredLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRequiredLevel.AutoSize = true;
			this.lblRequiredLevel.Location = new System.Drawing.Point(380, 267);
			this.lblRequiredLevel.Name = "lblRequiredLevel";
			this.lblRequiredLevel.Size = new System.Drawing.Size(19, 13);
			this.lblRequiredLevel.TabIndex = 30;
			this.lblRequiredLevel.Text = "99";
			// 
			// ucItemTooltip
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblRequiredLevel);
			this.Controls.Add(this.lblRequiredLevelText);
			this.Controls.Add(this.lblItemLevel);
			this.Controls.Add(this.lblItemLevelText);
			this.Controls.Add(this.flpMagicAttribute);
			this.Controls.Add(this.lblAttackSecondText);
			this.Controls.Add(this.lblDamageText);
			this.Controls.Add(this.lblAttackSecond);
			this.Controls.Add(this.lblDamage);
			this.Controls.Add(this.lblDpsArmorText);
			this.Controls.Add(this.lblDpsArmor);
			this.Controls.Add(this.picImage);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.lblName);
			this.DoubleBuffered = true;
			this.Name = "ucItemTooltip";
			this.Size = new System.Drawing.Size(402, 280);
			((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.PictureBox picImage;
		private System.Windows.Forms.Label lblDpsArmor;
		private System.Windows.Forms.Label lblDpsArmorText;
		private System.Windows.Forms.Label lblDamage;
		private System.Windows.Forms.Label lblDamageText;
		private System.Windows.Forms.Label lblAttackSecond;
		private System.Windows.Forms.Label lblAttackSecondText;
		private System.Windows.Forms.FlowLayoutPanel flpMagicAttribute;
		private System.Windows.Forms.Label lblItemLevelText;
		private System.Windows.Forms.Label lblItemLevel;
		private System.Windows.Forms.Label lblRequiredLevelText;
		private System.Windows.Forms.Label lblRequiredLevel;
	}
}

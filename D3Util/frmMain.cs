using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace D3Util
{
	public partial class frmMain : Form
	{
		const string CONFIG_FILENAME = "d3Util.config";

		public Profile profile;
		public Config config;

		public frmMain()
		{
			InitializeComponent();

			config = Config.Load(CONFIG_FILENAME);
			LoadProfiles();

			flpProfile.Controls.Clear();
		}

		private void LoadProfiles()
		{
			cboBattleTagName.Items.Clear();

			foreach (var battleTag in config.BattleTags)
			{
				cboBattleTagName.Items.Add(battleTag);
			}
		}

		private void cboBattleTagName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboBattleTagName.SelectedItem == null)
				return;

			BattleTag battleTag = (BattleTag)cboBattleTagName.SelectedItem;
			cboBattleTagName.SelectedIndex = -1;
			BeginInvoke((MethodInvoker)delegate { cboBattleTagName.Text = battleTag.Name; });
			txtBattleTagCode.Text = battleTag.Code.ToString();
		}

		private Button CreateHero(JsonHero hero)
		{
			Button btnHero = new Button();

			// 
			// btnHero
			// 
			btnHero.AutoEllipsis = true;
			btnHero.FlatStyle = FlatStyle.Popup;
			btnHero.Location = new Point(3, 3);
			btnHero.Name = "btnHero";
			btnHero.Size = new Size(195, 30);
			btnHero.TabIndex = 0;
			btnHero.Text = hero.name + " Lv:" + hero.level + (hero.paragonLevel > 0 ? " (" + hero.paragonLevel + ")" : string.Empty)
				+ " (" + hero.@class + ")";
			if (hero.hardcore)
				btnHero.ForeColor = Color.DarkRed;
			btnHero.UseVisualStyleBackColor = true;
			btnHero.Click += new EventHandler(btnHero_Click);
			btnHero.Tag = hero;

			return btnHero;
		}

		private void btnGetProfile_Click(object sender, EventArgs e)
		{
			// Put some validation here.

			DataContractJsonSerializer profileSerializer = new DataContractJsonSerializer(typeof(Profile));
			profile = (Profile)profileSerializer.ReadObject(
				GetStream("http://us.battle.net/api/d3/profile/" + cboBattleTagName.Text + "-" + txtBattleTagCode.Text + "/"));

			flpProfile.Controls.Clear();
			if (profile.heroes == null)
			{
				profile = null;
				return;
			}

			BattleTag battleTag = new BattleTag(cboBattleTagName.Text, int.Parse(txtBattleTagCode.Text));
			if (!config.BattleTags.Exists(bt => bt == battleTag))
			{
				config.BattleTags.Add(battleTag);
				config.Save(CONFIG_FILENAME);
				cboBattleTagName.Items.Add(battleTag);
			}

			foreach (JsonHero hero in profile.heroes)
			{
				flpProfile.Controls.Add(CreateHero(hero));
			}
		}

		public static Stream GetStream(string url)
		{
			return HttpWebRequest.Create(url).GetResponse().GetResponseStream();
		}

		private void btnHero_Click(object sender, EventArgs e)
		{
			Button btnHero = (Button)sender;

			ucHero ucHero = new ucHero(profile.battleTag, (JsonHero)btnHero.Tag);
			ucHero.Dock = DockStyle.Fill;
			Controls.Add(ucHero);
			ucHero.BringToFront();
		}
	}
}

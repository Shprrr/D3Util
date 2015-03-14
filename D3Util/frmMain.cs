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
				GetStream(string.Format(Profile.PROFILE_URL, cboBattleTagName.Text, txtBattleTagCode.Text)));

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

		private void btnSaveProfile_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(cboBattleTagName.Text) || string.IsNullOrWhiteSpace(txtBattleTagCode.Text))
				return;

			try
			{
				string battleTagPath = cboBattleTagName.Text + "-" + txtBattleTagCode.Text;
				Profile profileTemp;
				using (MemoryStream ms = new MemoryStream())
				{
					// Copy le stream reçu dans un MemoryStream pour le lire plusieurs fois.
					using (Stream stream = GetStream(string.Format(Profile.PROFILE_URL, cboBattleTagName.Text, txtBattleTagCode.Text)))
					{
						stream.CopyTo(ms);
						ms.Seek(0, SeekOrigin.Begin);
					}

					DataContractJsonSerializer profileSerializer = new DataContractJsonSerializer(typeof(Profile));
					profileTemp = (Profile)profileSerializer.ReadObject(ms);
					if (profileTemp.heroes == null)
						return;

					folderBrowserDialog.SelectedPath = Directory.GetCurrentDirectory();
					if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
						return;

					// Set progress window
					progressBar.Value = 0;
					progressBar.Maximum = 1 + profileTemp.heroes.Count * 14;
					lblProgression.Text = progressBar.Value + "/" + progressBar.Maximum;
					grbProgression.Location = new Point(Width / 2 - grbProgression.Width / 2, Height / 2 - grbProgression.Height / 2);
					grbProgression.Visible = true;

					using (var file = File.Create(folderBrowserDialog.SelectedPath + "\\" + battleTagPath + ".json"))
					{
						ms.Seek(0, SeekOrigin.Begin);
						ms.CopyTo(file);
						Progress();
					}
				}

				string path = folderBrowserDialog.SelectedPath + "\\" + battleTagPath + "\\";
				Directory.CreateDirectory(path);
				foreach (JsonHero hero in profileTemp.heroes)
				{
					path = folderBrowserDialog.SelectedPath + "\\" + battleTagPath + "\\";
					HeroRoot heroTemp;
					using (MemoryStream ms = new MemoryStream())
					{
						using (Stream stream = GetStream(string.Format(HeroRoot.HERO_URL, battleTagPath, hero.id)))
						{
							stream.CopyTo(ms);
							ms.Seek(0, SeekOrigin.Begin);
						}

						DataContractJsonSerializer heroSerializer = new DataContractJsonSerializer(typeof(HeroRoot));
						heroTemp = (HeroRoot)heroSerializer.ReadObject(ms);
						ms.Seek(0, SeekOrigin.Begin);

						using (var file = File.Create(path + hero.id + ".json"))
						{
							ms.CopyTo(file);
							Progress();
						}
					}

					path += hero.id + "\\";
					Directory.CreateDirectory(path);
					SaveItemJson(path, heroTemp.items.head);
					SaveItemJson(path, heroTemp.items.torso);
					SaveItemJson(path, heroTemp.items.feet);
					SaveItemJson(path, heroTemp.items.hands);
					SaveItemJson(path, heroTemp.items.shoulders);
					SaveItemJson(path, heroTemp.items.legs);
					SaveItemJson(path, heroTemp.items.bracers);
					SaveItemJson(path, heroTemp.items.mainHand);
					SaveItemJson(path, heroTemp.items.offHand);
					SaveItemJson(path, heroTemp.items.waist);
					SaveItemJson(path, heroTemp.items.rightFinger);
					SaveItemJson(path, heroTemp.items.leftFinger);
					SaveItemJson(path, heroTemp.items.neck);
				}

				MessageBox.Show("Save completed.");
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Saving is unauthorized.");
			}
			finally
			{
				grbProgression.Visible = false;
			}
		}

		private void SaveItemJson(string path, JsonItem item)
		{
			if (item == null)
			{
				Progress();
				return;
			}

			using (Stream s = GetStream(string.Format(ItemRoot.ITEM_URL, item.tooltipParams)))
			{
				using (var file = File.Create(path + item.GetType().Name + ".json"))
				{
					s.CopyTo(file);
					Progress();
				}
			}
		}

		private void Progress()
		{
			progressBar.Value++;
			lblProgression.Text = progressBar.Value + "/" + progressBar.Maximum;
			Update();
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

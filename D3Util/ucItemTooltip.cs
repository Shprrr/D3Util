﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace D3Util
{
	public partial class ucItemTooltip : UserControl
	{
		private Item _Item;

		/// <summary>
		/// Item to show in the tooltip
		/// </summary>
		public Item Item
		{
			get { return _Item; }
			set
			{
				_Item = value;
				ShowItem();
			}
		}

		public ucItemTooltip()
		{
			InitializeComponent();
		}

		private void ShowItem()
		{
			lblName.Text = Item != null ? Item.name : string.Empty;
			picImage.ImageLocation = Item != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + Item.icon + ".png" : string.Empty;
			lblType.Text = Item != null ? Item.typeName : string.Empty;

			if (Item == null || (Item.dps == null && Item.armor == null))
			{
				lblDpsArmor.Text = string.Empty;
				lblDpsArmorText.Text = string.Empty;
				lblDamage.Text = string.Empty;
				lblDamageText.Text = string.Empty;
				lblAttackSecond.Text = string.Empty;
				lblAttackSecondText.Text = string.Empty;
			}
			else if (Item.dps != null)
			{
				lblDpsArmor.Text = Item.dps.average.ToString("F1");
				lblDpsArmorText.Text = "Damage Per Second";
				lblDamage.Text = Item.damage.min.ToString("F0") + "-" + Item.damage.max.ToString("F0");
				lblDamageText.Text = "Damage";
				lblAttackSecond.Text = Item.attacksPerSecond.average.ToString("F2");
				lblAttackSecondText.Text = "Attacks per Second";
			}
			else if (Item.armor != null)
			{
				lblDpsArmor.Text = Item.armor.average.ToString();
				lblDpsArmorText.Text = "Armor";
				lblDamage.Text = string.Empty;
				lblDamageText.Text = string.Empty;
				lblAttackSecond.Text = string.Empty;
				lblAttackSecondText.Text = string.Empty;
			}

			flpMagicAttribute.Controls.Clear();
			if (Item != null)
			{
				foreach (var attribute in Item.attributes)
				{
					Label lblAttribute = new Label();
					lblAttribute.AutoSize = true;
					lblAttribute.Text = attribute;
					flpMagicAttribute.Controls.Add(lblAttribute);
				}

				foreach (var gem in Item.gems)
				{
					foreach (var attribute in gem.attributes)
					{
						Label lblAttribute = new Label();
						lblAttribute.AutoSize = true;
						lblAttribute.Text = attribute + " (Gem)";
						flpMagicAttribute.Controls.Add(lblAttribute);
					}
				}

				if (Item.attributesRaw.Sockets != null)
					for (int i = 0; i < Item.attributesRaw.Sockets.average - Item.gems.Count; i++)
					{
						Label lblAttribute = new Label();
						lblAttribute.AutoSize = true;
						lblAttribute.Text = "Empty Socket";
						flpMagicAttribute.Controls.Add(lblAttribute);
					}

				if (Item.set != null)
				{
					Label lblAttribute = new Label();
					lblAttribute.AutoSize = true;
					lblAttribute.ForeColor = Color.Green;
					lblAttribute.Margin = new Padding(lblAttribute.Margin.Left, lblAttribute.PreferredHeight, lblAttribute.Margin.Right, lblAttribute.Margin.Bottom);
					lblAttribute.Text = Item.set.name;
					flpMagicAttribute.Controls.Add(lblAttribute);

					foreach (var item in Item.set.items)
					{
						lblAttribute = new Label();
						lblAttribute.AutoSize = true;
						lblAttribute.ForeColor = Color.Gray;
						lblAttribute.Margin = new Padding(lblAttribute.Margin.Left + lblAttribute.PreferredHeight, lblAttribute.Margin.Top, lblAttribute.Margin.Right, lblAttribute.Margin.Bottom);
						lblAttribute.Text = item.name;
						flpMagicAttribute.Controls.Add(lblAttribute);
					}

					foreach (var rank in Item.set.ranks)
					{
						lblAttribute = new Label();
						lblAttribute.AutoSize = true;
						lblAttribute.ForeColor = Color.Gray;
						lblAttribute.Text = "(" + rank.required + ") Set:";
						flpMagicAttribute.Controls.Add(lblAttribute);

						foreach (var item in rank.attributes)
						{
							lblAttribute = new Label();
							lblAttribute.AutoSize = true;
							lblAttribute.ForeColor = Color.Gray;
							lblAttribute.Margin = new Padding(lblAttribute.Margin.Left + lblAttribute.PreferredHeight, lblAttribute.Margin.Top, lblAttribute.Margin.Right, lblAttribute.Margin.Bottom);
							lblAttribute.Text = item;
							flpMagicAttribute.Controls.Add(lblAttribute);
						}
					}
				}
			}

			lblDps.Text = Item != null ? Item.DpsDifference.ToString("N2") : string.Empty;
			lblEhp.Text = Item != null ? Item.EhpDifference.ToString("N0") : string.Empty;

			lblItemLevel.Text = Item != null ? Item.itemLevel.ToString() : string.Empty;
			lblRequiredLevel.Text = Item != null ? Item.requiredLevel.ToString() : string.Empty;
		}
	}
}

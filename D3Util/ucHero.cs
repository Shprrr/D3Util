using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace D3Util
{
	public partial class ucHero : UserControl
	{
		public HeroRoot heroRoot;
		public Hero hero;

		public ucHero(string battleTag, JsonHero jsonHero)
		{
			InitializeComponent();

			DataContractJsonSerializer heroSerializer = new DataContractJsonSerializer(typeof(HeroRoot));
			heroRoot = (HeroRoot)heroSerializer.ReadObject(
				frmMain.GetStream(string.Format(HeroRoot.HERO_URL, battleTag.Replace('#', '-'), jsonHero.id)));

			hero = new Hero(heroRoot);

			// Hide these label because it's not calculated.
			label30.Visible = false;
			lblEffectiveHp.Visible = false;
			label31.Location = label30.Location;
			lblEffectiveHpUnbuffed.Location = lblEffectiveHp.Location;

			lblHeroName.Text = heroRoot.name;
			ShowHeroStats();
			ShowItem();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void ShowHeroStats()
		{
			lblLife.Text = heroRoot.stats.life.ToString("N0");
			lblDps.Text = heroRoot.stats.damage.ToString("N2");
			lblAttackSpeed.Text = heroRoot.stats.attackSpeed.ToString("F2");
			lblArmor.Text = heroRoot.stats.armor.ToString();
			lblStrength.Text = heroRoot.stats.strength.ToString();
			lblDexterity.Text = heroRoot.stats.dexterity.ToString();
			lblIntelligence.Text = heroRoot.stats.intelligence.ToString();
			lblVitality.Text = heroRoot.stats.vitality.ToString();
			lblPhysicalResist.Text = hero.stats.physicalResist.ToString(); //entier manque resist provient de lvl
			lblFireResist.Text = hero.stats.fireResist.ToString();
			lblColdResist.Text = hero.stats.coldResist.ToString();
			lblLightningResist.Text = hero.stats.lightningResist.ToString();
			lblPoisonResist.Text = hero.stats.poisonResist.ToString();
			lblArcaneResist.Text = hero.stats.arcaneResist.ToString();
			lblCritChance.Text = heroRoot.stats.critChance.ToString("P2");
			lblCritDamage.Text = hero.stats.critDamage.ToString("P2");
			lblDamageIncrease.Text = heroRoot.stats.damageIncrease.ToString("P2");
			lblDamageReduction.Text = heroRoot.stats.damageReduction.ToString("P2");
			lblBlockChance.Text = heroRoot.stats.blockChance.ToString("P1");
			lblBlockAmountMin.Text = heroRoot.stats.blockAmountMin.ToString();
			lblBlockAmountMax.Text = heroRoot.stats.blockAmountMax.ToString();
			lblThorns.Text = heroRoot.stats.thorns.ToString("F2");
			lblLifeSteal.Text = heroRoot.stats.lifeSteal.ToString("P2");
			lblLifePerKill.Text = heroRoot.stats.lifePerKill.ToString("F2");
			lblLifeOnHit.Text = heroRoot.stats.lifeOnHit.ToString("F2");
			lblGoldFind.Text = heroRoot.stats.goldFind.ToString("P2");
			lblMagicFind.Text = heroRoot.stats.magicFind.ToString("P2");
			lblPrimaryResource.Text = heroRoot.stats.primaryResource.ToString();

			// Dodge chance
			// Crowd control reduction
			// Missile damage reduction
			// Melee damage reduction
			// Life bonus% ?
			// Life per second
			// Health globe bonus
			// Pickup radius
			// Mana regen per second
			// Mouvement speed
			// Bonus exp%
			// Bonus exp per kill

			switch (heroRoot.@class)
			{
				case "demon-hunter":
					lblSecondaryResource.Text = heroRoot.stats.secondaryResource.ToString();
					lblPrimaryResourceText.Text = "Hatred:";
					lblSecondaryResourceText.Text = "Discipline:";
					break;

				case "barbarian":
					lblSecondaryResource.Text = string.Empty;
					lblPrimaryResourceText.Text = "Fury:";
					lblSecondaryResourceText.Text = string.Empty;
					break;

				case "monk":
					lblSecondaryResource.Text = string.Empty;
					lblPrimaryResourceText.Text = "Spirit:";
					lblSecondaryResourceText.Text = string.Empty;
					break;

				case "witch-doctor":
					lblSecondaryResource.Text = string.Empty;
					lblPrimaryResourceText.Text = "Mana:";
					lblSecondaryResourceText.Text = string.Empty;
					break;

				case "wizard":
					lblSecondaryResource.Text = string.Empty;
					lblPrimaryResourceText.Text = "Arcane Power:";
					lblSecondaryResourceText.Text = string.Empty;
					break;

				default:
					lblSecondaryResource.Text = string.Empty;
					lblSecondaryResourceText.Text = string.Empty;
					break;
			}

			// Invented stats
			lblDpsUnbuffed.Text = hero.statsUnbuffed.dps.ToString("N2");
			lblDamage.Text = hero.statsUnbuffed.damage.ToString("N2");
			lblEffectiveHp.Text = hero.statsUnbuffed.effectiveHp.ToString("N0") + " (No Skill)";
			lblEffectiveHpUnbuffed.Text = hero.statsUnbuffed.effectiveHp.ToString("N0");

			lblDpsAverageDamage.Text = "+" + (hero.DpsUnbuffedAdd(damageAvg: 1) - hero.statsUnbuffed.dps).ToString("N2")
				+ (hero.weaponNumber > 1 ? " ÷" + hero.weaponNumber + " if on Weapon" : string.Empty);
			lblDpsPrimaryStat.Text = "+" + (hero.DpsUnbuffedAdd(primaryStat: 1) - hero.statsUnbuffed.dps).ToString("N2");
			lblDpsAttackSpeed.Text = "+" + (hero.DpsUnbuffedAdd(attackSpeedAvg: 0.01) - hero.statsUnbuffed.dps).ToString("N2");
			lblDpsCritChance.Text = "+" + (hero.DpsUnbuffedAdd(critChance: 0.01) - hero.statsUnbuffed.dps).ToString("N2");
			lblDpsCritDamage.Text = "+" + (hero.DpsUnbuffedAdd(critDamage: 0.01) - hero.statsUnbuffed.dps).ToString("N2");

			lblEhpVitality.Text = "+" + (hero.EhpUnbuffedAdd(vitality: 1) - hero.statsUnbuffed.effectiveHp).ToString("N0");
			lblEhpLifePourcent.Text = "+" + (hero.EhpUnbuffedAdd(lifePourcent: 0.01) - hero.statsUnbuffed.effectiveHp).ToString("N0");
			lblEhpArmor.Text = "+" + (hero.EhpUnbuffedAdd(armor: 10) - hero.statsUnbuffed.effectiveHp).ToString("N0");
			lblEhpResistAll.Text = "+" + (hero.EhpUnbuffedAdd(resist: 1) - hero.statsUnbuffed.effectiveHp).ToString("N0");
			lblEhpIntelligence.Text = "+" + ((hero.EhpUnbuffedAdd(intelligence: 10) - hero.statsUnbuffed.effectiveHp) / 10).ToString("N0");
			lblEhpHp.Text = ((double)hero.statsUnbuffed.effectiveHp / hero.statsUnbuffed.life).ToString("N2") + " EHP";
		}

		private void ShowItem()
		{
			picHead.ImageLocation = heroRoot.items.head != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.head.icon + ".png" : string.Empty;
			picTorso.ImageLocation = heroRoot.items.torso != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.torso.icon + ".png" : string.Empty;
			picFeet.ImageLocation = heroRoot.items.feet != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.feet.icon + ".png" : string.Empty;
			picHands.ImageLocation = heroRoot.items.hands != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.hands.icon + ".png" : string.Empty;
			picShoulders.ImageLocation = heroRoot.items.shoulders != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.shoulders.icon + ".png" : string.Empty;
			picLegs.ImageLocation = heroRoot.items.legs != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.legs.icon + ".png" : string.Empty;
			picBracers.ImageLocation = heroRoot.items.bracers != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.bracers.icon + ".png" : string.Empty;
			picMainHand.ImageLocation = heroRoot.items.mainHand != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.mainHand.icon + ".png" : string.Empty;
			picOffHand.ImageLocation = heroRoot.items.offHand != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.offHand.icon + ".png" : string.Empty;
			picWaist.ImageLocation = heroRoot.items.waist != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.waist.icon + ".png" : string.Empty;
			picLeftFinger.ImageLocation = heroRoot.items.leftFinger != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.leftFinger.icon + ".png" : string.Empty;
			picRightFinger.ImageLocation = heroRoot.items.rightFinger != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.rightFinger.icon + ".png" : string.Empty;
			picNeck.ImageLocation = heroRoot.items.neck != null ? "http://us.media.blizzard.com/d3/icons/items/large/" + heroRoot.items.neck.icon + ".png" : string.Empty;
		}

		private void picSlot_MouseEnter(object sender, EventArgs e)
		{
			switch (((PictureBox)sender).Name)
			{
				case "picHead":
					if (hero.items.ContainsKey(Hero.Slot.Head))
						ucItemTooltip.Item = hero.items[Hero.Slot.Head];
					break;

				case "picTorso":
					if (hero.items.ContainsKey(Hero.Slot.Torso))
						ucItemTooltip.Item = hero.items[Hero.Slot.Torso];
					break;

				case "picFeet":
					if (hero.items.ContainsKey(Hero.Slot.Feet))
						ucItemTooltip.Item = hero.items[Hero.Slot.Feet];
					break;

				case "picHands":
					if (hero.items.ContainsKey(Hero.Slot.Hands))
						ucItemTooltip.Item = hero.items[Hero.Slot.Hands];
					break;

				case "picShoulders":
					if (hero.items.ContainsKey(Hero.Slot.Shoulders))
						ucItemTooltip.Item = hero.items[Hero.Slot.Shoulders];
					break;

				case "picLegs":
					if (hero.items.ContainsKey(Hero.Slot.Legs))
						ucItemTooltip.Item = hero.items[Hero.Slot.Legs];
					break;

				case "picBracers":
					if (hero.items.ContainsKey(Hero.Slot.Bracers))
						ucItemTooltip.Item = hero.items[Hero.Slot.Bracers];
					break;

				case "picMainHand":
					if (hero.items.ContainsKey(Hero.Slot.MainHand))
						ucItemTooltip.Item = hero.items[Hero.Slot.MainHand];
					break;

				case "picOffHand":
					if (hero.items.ContainsKey(Hero.Slot.OffHand))
						ucItemTooltip.Item = hero.items[Hero.Slot.OffHand];
					break;

				case "picWaist":
					if (hero.items.ContainsKey(Hero.Slot.Waist))
						ucItemTooltip.Item = hero.items[Hero.Slot.Waist];
					break;

				case "picLeftFinger":
					if (hero.items.ContainsKey(Hero.Slot.LeftFinger))
						ucItemTooltip.Item = hero.items[Hero.Slot.LeftFinger];
					break;

				case "picRightFinger":
					if (hero.items.ContainsKey(Hero.Slot.RightFinger))
						ucItemTooltip.Item = hero.items[Hero.Slot.RightFinger];
					break;

				case "picNeck":
					if (hero.items.ContainsKey(Hero.Slot.Neck))
						ucItemTooltip.Item = hero.items[Hero.Slot.Neck];
					break;
			}
		}
	}
}

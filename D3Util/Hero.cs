using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace D3Util
{
	public class Stats
	{
		public int life { get; set; }
		public double dps { get; set; }
		public double damage { get; set; }
		public double attackSpeed { get; set; }
		public int armor { get; set; }
		public int primaryStat { get; set; }
		public int strength { get; set; }
		public int dexterity { get; set; }
		public int intelligence { get; set; }
		public int vitality { get; set; }
		public int physicalResist { get; set; }
		public int fireResist { get; set; }
		public int coldResist { get; set; }
		public int lightningResist { get; set; }
		public int poisonResist { get; set; }
		public int arcaneResist { get; set; }
		public double critDamage { get; set; }
		public double damageIncrease { get; set; }
		public double critChance { get; set; }
		public double damageReduction { get; set; }
		public double blockChance { get; set; }
		public double thorns { get; set; }
		public double lifeSteal { get; set; }
		public double lifePerKill { get; set; }
		public double goldFind { get; set; }
		public double magicFind { get; set; }
		public int blockAmountMin { get; set; }
		public int blockAmountMax { get; set; }
		public double lifeOnHit { get; set; }
		public int primaryResource { get; set; }
		public int secondaryResource { get; set; }

		public double lifePourcent { get; set; }
		public int effectiveHp { get; set; }
	}

	public class Hero
	{
		public enum Slot
		{
			Head,
			Torso,
			Feet,
			Hands,
			Shoulders,
			Legs,
			Bracers,
			MainHand,
			OffHand,
			Waist,
			LeftFinger,
			RightFinger,
			Neck
		}

		private double weaponDamageAvgTot = 0, weaponSpeed = 0, damageAvg = 0, attackSpeedAvg = 0, critChance = 0.05, critDamage = 0.5;
		public int weaponNumber = 0;
		private int resistAll = 0, resistPhysical = 0, resistFire = 0, resistCold = 0, resistLightning = 0, resistPoison = 0, resistArcane = 0;
		private double resistAvg = 0, damageReductionResist = 0;
		private double lifePourcent = 0;

		public int HeroLevel { get; set; }
		public int MonsterLevel { get; set; }
		public Stats stats { get; set; }
		public Stats statsUnbuffed { get; set; }
		private Dictionary<Slot, ItemRoot> _items = new Dictionary<Slot, ItemRoot>();
		public Dictionary<Slot, ItemRoot> items { get { return _items; } }

		public Hero(HeroRoot heroRoot)
		{
			InitItems(heroRoot);

			SetItemsValues();

			//TODO: Gets all value needed from skills

			HeroLevel = heroRoot.level;
			MonsterLevel = heroRoot.level;

			stats = new Stats();

			stats.life = heroRoot.stats.life;
			stats.dps = heroRoot.stats.damage;
			stats.damage = heroRoot.stats.damage;
			stats.attackSpeed = heroRoot.stats.attackSpeed;
			stats.armor = heroRoot.stats.armor;

			switch (heroRoot.@class)
			{
				case "barbarian":
					stats.primaryStat = heroRoot.stats.strength;
					break;

				case "demon-hunter":
				case "monk":
					stats.primaryStat = heroRoot.stats.dexterity;
					break;

				case "witch-doctor":
				case "wizard":
					stats.primaryStat = heroRoot.stats.intelligence;
					break;
			}

			stats.strength = heroRoot.stats.strength;
			stats.dexterity = heroRoot.stats.dexterity;
			stats.intelligence = heroRoot.stats.intelligence;
			stats.vitality = heroRoot.stats.vitality;

			// Resist = Intel / 10 + Resist All + Resist Element
			stats.physicalResist = heroRoot.stats.intelligence / 10 + resistAll + resistPhysical;
			stats.fireResist = heroRoot.stats.intelligence / 10 + resistAll + resistFire;
			stats.coldResist = heroRoot.stats.intelligence / 10 + resistAll + resistCold;
			stats.lightningResist = heroRoot.stats.intelligence / 10 + resistAll + resistLightning;
			stats.poisonResist = heroRoot.stats.intelligence / 10 + resistAll + resistPoison;
			stats.arcaneResist = heroRoot.stats.intelligence / 10 + resistAll + resistArcane;

			stats.critDamage = heroRoot.stats.critDamage - 1;
			stats.damageIncrease = heroRoot.stats.damageIncrease;
			stats.critChance = heroRoot.stats.critChance;
			stats.damageReduction = heroRoot.stats.damageReduction;
			stats.blockChance = heroRoot.stats.blockChance;
			stats.thorns = heroRoot.stats.thorns;
			stats.lifeSteal = heroRoot.stats.lifeSteal;
			stats.lifePerKill = heroRoot.stats.lifePerKill;
			stats.goldFind = heroRoot.stats.goldFind;
			stats.magicFind = heroRoot.stats.magicFind;
			stats.blockAmountMin = heroRoot.stats.blockAmountMin;
			stats.blockAmountMax = heroRoot.stats.blockAmountMax;
			stats.lifeOnHit = heroRoot.stats.lifeOnHit;
			stats.primaryResource = heroRoot.stats.primaryResource;
			stats.secondaryResource = heroRoot.stats.secondaryResource;


			statsUnbuffed = new Stats();

			statsUnbuffed.primaryStat = stats.primaryStat;
			statsUnbuffed.strength = stats.strength;
			statsUnbuffed.dexterity = stats.dexterity;
			statsUnbuffed.intelligence = stats.intelligence;
			statsUnbuffed.vitality = stats.vitality;

			//Life when player level < 35: = 36 + 4 × Level + 10 × Vitality
			//Life when player level ≥ 35: = 36 + 4 × Level + (Level - 25) × Vitality
			if (HeroLevel < 35)
				statsUnbuffed.life = 36 + 4 * HeroLevel + 10 * statsUnbuffed.vitality;
			else
				statsUnbuffed.life = 36 + 4 * HeroLevel + (HeroLevel - 25) * statsUnbuffed.vitality;
			statsUnbuffed.lifePourcent = lifePourcent;
			statsUnbuffed.life = (int)(statsUnbuffed.life * (1 + statsUnbuffed.lifePourcent));

			//=IF((B74>0);(((B71+B74)/2)*(1,15+B86));(B71*(1+B86)))+((+IF((U9="Yes");0,03;0)+IF(((U23="Yes")*(U3="B"));0,1;0))+IF(((U16="Yes")*(U3="M"));0,08;0))
			//IF(AttackSpeedOffhand>0)
			//{
			//    (((AttackSpeedMainhand+AttackSpeedOffhand)/2)*(1.15+attackSpeedAvg))
			//}
			//ELSE
			//{
			//    (AttackSpeedMainhand*(1+attackSpeedAvg))
			//}
			//+((IF(EnchantressFocusedMind){0.03}else{0}
			//  +IF(BarbarianWeaponMasterPolearmSpear){0.1}else{0})
			// +IF(MonkMantraOfRetributionTransgression){0.08}else{0})
			statsUnbuffed.attackSpeed = 0;
			if (items.ContainsKey(Slot.OffHand) && items[Slot.OffHand].attacksPerSecond != null)
			{
				statsUnbuffed.attackSpeed += ((items[Slot.MainHand].attacksPerSecond.average + items[Slot.OffHand].attacksPerSecond.average) / 2) * (1.15f + attackSpeedAvg);
			}
			else
			{
				statsUnbuffed.attackSpeed += items[Slot.MainHand].attacksPerSecond.average * (1 + attackSpeedAvg);
			}
			statsUnbuffed.attackSpeed = Math.Round(statsUnbuffed.attackSpeed, 3, MidpointRounding.AwayFromZero);

			statsUnbuffed.dps = Math.Round((weaponDamageAvgTot / weaponNumber + damageAvg) * (1 + (float)statsUnbuffed.primaryStat / 100) * statsUnbuffed.attackSpeed * (1 + critChance * critDamage), 2, MidpointRounding.AwayFromZero);
			statsUnbuffed.damage = Math.Round((weaponDamageAvgTot / weaponNumber + damageAvg) * (1 + (float)statsUnbuffed.primaryStat / 100) * (1 + critChance * critDamage), 2, MidpointRounding.AwayFromZero);

			statsUnbuffed.armor = stats.armor;
			statsUnbuffed.damageReduction = Math.Round((double)statsUnbuffed.armor / (50 * MonsterLevel + statsUnbuffed.armor), 4, MidpointRounding.AwayFromZero);

			statsUnbuffed.physicalResist = statsUnbuffed.intelligence / 10 + resistAll + resistPhysical;
			statsUnbuffed.fireResist = statsUnbuffed.intelligence / 10 + resistAll + resistFire;
			statsUnbuffed.coldResist = statsUnbuffed.intelligence / 10 + resistAll + resistCold;
			statsUnbuffed.lightningResist = statsUnbuffed.intelligence / 10 + resistAll + resistLightning;
			statsUnbuffed.poisonResist = statsUnbuffed.intelligence / 10 + resistAll + resistPoison;
			statsUnbuffed.arcaneResist = statsUnbuffed.intelligence / 10 + resistAll + resistArcane;
			resistAvg = Math.Round((double)(statsUnbuffed.physicalResist + statsUnbuffed.fireResist + statsUnbuffed.coldResist + statsUnbuffed.lightningResist + statsUnbuffed.poisonResist + statsUnbuffed.arcaneResist) / 6, MidpointRounding.AwayFromZero);
			//resistAvg = Math.Min(Math.Min(statsUnbuffed.physicalResist, statsUnbuffed.fireResist), statsUnbuffed.arcaneResist);
			damageReductionResist = Math.Round(resistAvg / (5 * MonsterLevel + resistAvg), 4, MidpointRounding.AwayFromZero);

			//EHP: = Life / ((1 - DR from Armor) * (1 - DR from Resistance) * (1 - 0.30 if monk or barbarian) * (1 - DR from other source))
			statsUnbuffed.effectiveHp = (int)(statsUnbuffed.life / ((1 - statsUnbuffed.damageReduction) * (1 - damageReductionResist)));
			//EHP: = Life * ((1 + Armor / (50 * Monster Level)) * (1 + Resistance / (5 * Monster Level)))
			//statsUnbuffed.effectiveHp = (int)(statsUnbuffed.life * ((1 + (double)statsUnbuffed.armor / (50 * MonsterLevel)) * (1 + resistAvg / (5 * MonsterLevel))));
		}

		protected void InitItems(HeroRoot heroRoot)
		{
			DataContractJsonSerializer itemSerializer = new DataContractJsonSerializer(typeof(ItemRoot));
			if (heroRoot.items.head != null)
				_items.Add(Slot.Head, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.head.tooltipParams)));
			if (heroRoot.items.torso != null)
				_items.Add(Slot.Torso, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.torso.tooltipParams)));
			if (heroRoot.items.feet != null)
				_items.Add(Slot.Feet, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.feet.tooltipParams)));
			if (heroRoot.items.hands != null)
				_items.Add(Slot.Hands, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.hands.tooltipParams)));
			if (heroRoot.items.shoulders != null)
				_items.Add(Slot.Shoulders, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.shoulders.tooltipParams)));
			if (heroRoot.items.legs != null)
				_items.Add(Slot.Legs, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.legs.tooltipParams)));
			if (heroRoot.items.bracers != null)
				_items.Add(Slot.Bracers, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.bracers.tooltipParams)));
			if (heroRoot.items.mainHand != null)
				_items.Add(Slot.MainHand, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.mainHand.tooltipParams)));
			if (heroRoot.items.offHand != null)
				_items.Add(Slot.OffHand, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.offHand.tooltipParams)));
			if (heroRoot.items.waist != null)
				_items.Add(Slot.Waist, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.waist.tooltipParams)));
			if (heroRoot.items.leftFinger != null)
				_items.Add(Slot.LeftFinger, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.leftFinger.tooltipParams)));
			if (heroRoot.items.rightFinger != null)
				_items.Add(Slot.RightFinger, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.rightFinger.tooltipParams)));
			if (heroRoot.items.neck != null)
				_items.Add(Slot.Neck, (ItemRoot)itemSerializer.ReadObject(frmMain.GetStream("http://us.battle.net/api/d3/data/" + heroRoot.items.neck.tooltipParams)));
		}

		protected void SetItemsValues()
		{
			foreach (var item in items.Values)
			{
				if (item.damage != null)
				{
					weaponDamageAvgTot += (float)Math.Round(item.damage.average, 1, MidpointRounding.AwayFromZero);
					++weaponNumber;
					weaponSpeed += item.attacksPerSecond.average;
				}

				if (item.attributesRaw.Damage_Min_Physical != null)
					damageAvg += (float)Math.Round(item.attributesRaw.Damage_Min_Physical.average / 2, 1, MidpointRounding.AwayFromZero);
				if (item.attributesRaw.Damage_Delta_Physical != null)
				{
					if (item.attributesRaw.Damage_Min_Physical != null)
						damageAvg += (float)Math.Round((item.attributesRaw.Damage_Min_Physical.average + item.attributesRaw.Damage_Delta_Physical.average) / 2, 1, MidpointRounding.AwayFromZero);
					else
						damageAvg += (float)Math.Round(item.attributesRaw.Damage_Delta_Physical.average / 2, 1, MidpointRounding.AwayFromZero);
				}

				if (item.attributesRaw.Attacks_Per_Second_Percent != null)
					attackSpeedAvg += item.attributesRaw.Attacks_Per_Second_Percent.average;

				if (item.attributesRaw.Crit_Percent_Bonus_Capped != null)
					critChance += (float)Math.Round(item.attributesRaw.Crit_Percent_Bonus_Capped.average, 3, MidpointRounding.AwayFromZero);
				if (item.attributesRaw.Crit_Damage_Percent != null)
					critDamage += item.attributesRaw.Crit_Damage_Percent.average;

				if (item.attributesRaw.Resistance_All != null)
					resistAll += (int)item.attributesRaw.Resistance_All.average;

				if (item.attributesRaw.Resistance_Physical != null)
					resistPhysical += (int)item.attributesRaw.Resistance_Physical.average;

				if (item.attributesRaw.Resistance_Fire != null)
					resistFire += (int)item.attributesRaw.Resistance_Fire.average;

				if (item.attributesRaw.Resistance_Cold != null)
					resistCold += (int)item.attributesRaw.Resistance_Cold.average;

				if (item.attributesRaw.Resistance_Lightning != null)
					resistLightning += (int)item.attributesRaw.Resistance_Lightning.average;

				if (item.attributesRaw.Resistance_Poison != null)
					resistPoison += (int)item.attributesRaw.Resistance_Poison.average;

				if (item.attributesRaw.Resistance_Arcane != null)
					resistArcane += (int)item.attributesRaw.Resistance_Arcane.average;

				if (item.attributesRaw.Hitpoints_Max_Percent_Bonus_Item != null)
					lifePourcent += item.attributesRaw.Hitpoints_Max_Percent_Bonus_Item.average;

				foreach (var gem in item.gems)
				{
					if (gem.attributesRaw.Crit_Damage_Percent != null)
						critDamage += gem.attributesRaw.Crit_Damage_Percent.average;

					if (gem.attributesRaw.Hitpoints_Max_Percent_Bonus_Item != null)
						lifePourcent += gem.attributesRaw.Hitpoints_Max_Percent_Bonus_Item.average;
				}
			}

			critChance = Math.Round(critChance, 3, MidpointRounding.AwayFromZero);
			critDamage = Math.Round(critDamage, 2, MidpointRounding.AwayFromZero);
			lifePourcent = Math.Round(lifePourcent, 2, MidpointRounding.AwayFromZero);
		}

		public double DpsUnbuffedAdd(double damageAvg = 0, int primaryStat = 0, double attackSpeedAvg = 0, double critChance = 0, double critDamage = 0)
		{
			double attackSpeed = 0;
			if (items.ContainsKey(Slot.OffHand) && items[Slot.OffHand].attacksPerSecond != null)
			{
				attackSpeed += ((items[Slot.MainHand].attacksPerSecond.average + items[Slot.OffHand].attacksPerSecond.average) / 2) * (1.15f + this.attackSpeedAvg + attackSpeedAvg);
			}
			else
			{
				attackSpeed += items[Slot.MainHand].attacksPerSecond.average * (1 + this.attackSpeedAvg + attackSpeedAvg);
			}
			attackSpeed = Math.Round(attackSpeed, 3, MidpointRounding.AwayFromZero);

			double dps = Math.Round((weaponDamageAvgTot / weaponNumber + this.damageAvg + damageAvg) * (1 + (float)(statsUnbuffed.primaryStat + primaryStat) / 100) * attackSpeed * (1 + (this.critChance + critChance) * (this.critDamage + critDamage)), 2, MidpointRounding.AwayFromZero);
			return dps;
		}

		public double EhpUnbuffedAdd(int vitality = 0, double lifePourcent = 0, int armor = 0, int strength = 0, int resist = 0, int intelligence = 0)
		{
			int life = 0;
			if (HeroLevel < 35)
				life = 36 + 4 * HeroLevel + 10 * (statsUnbuffed.vitality + vitality);
			else
				life = 36 + 4 * HeroLevel + (HeroLevel - 25) * (statsUnbuffed.vitality + vitality);
			double lifePourcentTemp = this.lifePourcent + lifePourcent;
			life = (int)(life * (1 + lifePourcentTemp));

			int armorTemp = stats.armor + armor + strength;
			double damageReduction = Math.Round((double)armorTemp / (50 * MonsterLevel + armorTemp), 4, MidpointRounding.AwayFromZero);

			int physicalResist = (statsUnbuffed.intelligence + intelligence) / 10 + resistAll + resistPhysical + resist;
			int fireResist = (statsUnbuffed.intelligence + intelligence) / 10 + resistAll + resistFire + resist;
			int coldResist = (statsUnbuffed.intelligence + intelligence) / 10 + resistAll + resistCold + resist;
			int lightningResist = (statsUnbuffed.intelligence + intelligence) / 10 + resistAll + resistLightning + resist;
			int poisonResist = (statsUnbuffed.intelligence + intelligence) / 10 + resistAll + resistPoison + resist;
			int arcaneResist = (statsUnbuffed.intelligence + intelligence) / 10 + resistAll + resistArcane + resist;
			double resistAvg = Math.Round((double)(physicalResist + fireResist + coldResist + lightningResist + poisonResist + arcaneResist) / 6, MidpointRounding.AwayFromZero);
			double damageReductionResist = Math.Round(resistAvg / (5 * MonsterLevel + resistAvg), 4, MidpointRounding.AwayFromZero);

			double ehp = (int)(life / ((1 - damageReduction) * (1 - damageReductionResist)));
			return ehp;
		}
	}
}

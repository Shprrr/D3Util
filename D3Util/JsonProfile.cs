using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace D3Util
{
	public class Profile
	{
		public string battleTag { get; set; }
		public int paragonLevel { get; set; }
		public int paragonLevelHardcore { get; set; }
		public int paragonLevelSeason { get; set; }
		public int paragonLevelSeasonHardcore { get; set; }
		public List<JsonHero> heroes { get; set; }
		public int lastHeroPlayed { get; set; }
		public int lastUpdated { get; set; }
		public Kills kills { get; set; }
		public int highestHardcoreLevel { get; set; }
		public TimePlayed timePlayed { get; set; }
		public List<FallenHero> fallenHeroes { get; set; }
		public Artisan blacksmith { get; set; }
		public Artisan jeweler { get; set; }
		public Artisan mystic { get; set; }
		public Artisan blacksmithHardcore { get; set; }
		public Artisan jewelerHardcore { get; set; }
		public Artisan mysticHardcore { get; set; }
		public Artisan blacksmithSeason { get; set; }
		public Artisan jewelerSeason { get; set; }
		public Artisan mysticSeason { get; set; }
		public Artisan blacksmithSeasonHardcore { get; set; }
		public Artisan jewelerSeasonHardcore { get; set; }
		public Artisan mysticSeasonHardcore { get; set; }
		public Progression progression { get; set; }
		public SeasonProfile seasonalProfiles { get; set; }

		public override string ToString()
		{
			return battleTag;
		}

		public static DateTime FromUnixTimestamp(long timestamp)
		{
			DateTime unixRef = new DateTime(1970, 1, 1, 0, 0, 0);
			return unixRef.AddSeconds(timestamp);
		}
	}

	[DataContract(Name = "Hero")]
	public class JsonHero
	{
		[DataMember(Name = "name")]
		public string name { get; set; }
		[DataMember(Name = "id")]
		public int id { get; set; }
		[DataMember(Name = "level")]
		public int level { get; set; }
		[DataMember(Name = "hardcore")]
		public bool hardcore { get; set; }
		[DataMember(Name = "seasonal")]
		public bool seasonal { get; set; }
		[DataMember(Name = "paragonLevel")]
		public int paragonLevel { get; set; }
		[DataMember(Name = "gender")]
		public int gender { get; set; }
		[DataMember(Name = "dead")]
		public bool dead { get; set; }
		[DataMember(Name = "class")]
		public string @class { get; set; }
		[DataMember(Name = "last-updated")]
		public int lastUpdated { get; set; }

		public override string ToString()
		{
			return name + " Lv:" + level + (paragonLevel > 0 ? "(" + paragonLevel + ")" : string.Empty);
		}
	}

	public class Artisan
	{
		public string slug { get; set; }
		public int level { get; set; }
		public int stepCurrent { get; set; }
		public int stepMax { get; set; }

		public override string ToString()
		{
			return slug + " Lv:" + level;
		}
	}

	public class Kills
	{
		public int monsters { get; set; }
		public int elites { get; set; }
		public int hardcoreMonsters { get; set; }
	}

	[DataContract(Name = "TimePlayed")]
	public class TimePlayed
	{
		[DataMember(Name = "barbarian")]
		public double barbarian { get; set; }
		[DataMember(Name = "crusader")]
		public double crusader { get; set; }
		[DataMember(Name = "demon-hunter")]
		public double demonHunter { get; set; }
		[DataMember(Name = "monk")]
		public double monk { get; set; }
		[DataMember(Name = "witch-doctor")]
		public double witchDoctor { get; set; }
		[DataMember(Name = "wizard")]
		public double wizard { get; set; }
	}

	public class JsonStats
	{
		public int life { get; set; }
		public float damage { get; set; }
		public float toughness { get; set; }
		public float healing { get; set; }
		public float attackSpeed { get; set; }
		public int armor { get; set; }
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
		public float blockChance { get; set; }
		public int blockAmountMin { get; set; }
		public int blockAmountMax { get; set; }
		public float damageIncrease { get; set; }
		public float critChance { get; set; }
		public float critDamage { get; set; }
		public float damageReduction { get; set; }
		public float thorns { get; set; }
		public float lifeSteal { get; set; }
		public float lifePerKill { get; set; }
		public float goldFind { get; set; }
		public float magicFind { get; set; }
		public float lifeOnHit { get; set; }
		public int primaryResource { get; set; }
		public int secondaryResource { get; set; }
	}

	public class JsonItem
	{
		public string id { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public string displayColor { get; set; }
		public string tooltipParams { get; set; }
		public JsonItem transmogItem { get; set; }
		public List<object> randomAffixes { get; set; }
		public List<CraftedBy> craftedBy { get; set; }

		public override string ToString()
		{
			return name;
		}
	}

	public class CraftedBy
	{
		public string id { get; set; }
		public string slug { get; set; }
		public string name { get; set; }
		public int cost { get; set; }
		public List<Reagent> reagents { get; set; }
		public JsonItem itemProduced { get; set; }
	}

	public class Reagent
	{
		public int quantity { get; set; }
		public JsonItem item { get; set; }
	}

	public class Head : JsonItem { }

	public class Torso : JsonItem { }

	public class Feet : JsonItem { }

	public class Hands : JsonItem { }

	public class Shoulders : JsonItem { }

	public class Legs : JsonItem { }

	public class Bracers : JsonItem { }

	public class MainHand : JsonItem { }

	public class OffHand : JsonItem { }

	public class Waist : JsonItem { }

	public class Ring : JsonItem { }

	public class Neck : JsonItem { }

	public class Special : JsonItem { }

	public class Items
	{
		public Head head { get; set; }
		public Torso torso { get; set; }
		public Feet feet { get; set; }
		public Hands hands { get; set; }
		public Shoulders shoulders { get; set; }
		public Legs legs { get; set; }
		public Bracers bracers { get; set; }
		public MainHand mainHand { get; set; }
		public OffHand offHand { get; set; }
		public Waist waist { get; set; }
		public Ring rightFinger { get; set; }
		public Ring leftFinger { get; set; }
		public Neck neck { get; set; }
	}

	public class Death
	{
		public int killer { get; set; }
		public int location { get; set; }
		public int time { get; set; }
	}

	public class FallenHero
	{
		public string name { get; set; }
		public int level { get; set; }
		public JsonStats stats { get; set; }
		public Items items { get; set; }
		public Kills kills { get; set; }
		public bool hardcore { get; set; }
		public Death death { get; set; }
		public int heroId { get; set; }
		public int gender { get; set; }
		public string @class { get; set; }

		public override string ToString()
		{
			return name + " Lv:" + level;
		}
	}

	public class Progression
	{
		public bool act1 { get; set; }
		public bool act2 { get; set; }
		public bool act3 { get; set; }
		public bool act4 { get; set; }
		public bool act5 { get; set; }
	}

	public class SeasonProfile
	{
		public Season season0 { get; set; }
		public Season season1 { get; set; }
		public Season season2 { get; set; }
	}

	public class Season
	{
		public int seasonId { get; set; }
		public int paragonLevel { get; set; }
		public int paragonLevelHardcore { get; set; }
		public Kills kills { get; set; }
		public TimePlayed timePlayed { get; set; }
		public int highestHardcoreLevel { get; set; }
		public Progression progression { get; set; }
	}
}

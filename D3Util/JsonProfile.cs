using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace D3Util
{
	public class Profile
	{
		public List<JsonHero> heroes { get; set; }
		public int lastHeroPlayed { get; set; }
		public int lastUpdated { get; set; }
		public List<Artisan> artisans { get; set; }
		public List<Artisan> hardcoreArtisans { get; set; }
		public Kills kills { get; set; }
		public TimePlayed timePlayed { get; set; }
		public List<FallenHero> fallenHeroes { get; set; }
		public string battleTag { get; set; }
		public Progression progression { get; set; }
		public Progression hardcoreProgression { get; set; }

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
		public float critDamage { get; set; }
		public float damageIncrease { get; set; }
		public float critChance { get; set; }
		public float damageReduction { get; set; }
		public float blockChance { get; set; }
		public float thorns { get; set; }
		public float lifeSteal { get; set; }
		public float lifePerKill { get; set; }
		public float goldFind { get; set; }
		public float magicFind { get; set; }
		public int blockAmountMin { get; set; }
		public int blockAmountMax { get; set; }
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
		//public int requiredLevel { get; set; }
		//public string typeName { get; set; }
		//public Type type { get; set; }
		//public List<Gem> gems { get; set; }

		public override string ToString()
		{
			return name;
		}
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
		public JsonStats stats { get; set; }
		public Kills kills { get; set; }
		public Items items { get; set; }
		public Death death { get; set; }
		public string name { get; set; }
		public int level { get; set; }
		public bool hardcore { get; set; }
		public int heroId { get; set; }
		public int gender { get; set; }
		public string @class { get; set; }

		public override string ToString()
		{
			return name + " Lv:" + level;
		}
	}

	public class CompletedQuest
	{
		public string slug { get; set; }
		public string name { get; set; }

		public override string ToString()
		{
			return name;
		}
	}

	public class Act
	{
		public bool completed { get; set; }
		public List<CompletedQuest> completedQuests { get; set; }
	}

	public class Difficulty
	{
		public Act act1 { get; set; }
		public Act act2 { get; set; }
		public Act act3 { get; set; }
		public Act act4 { get; set; }
	}

	public class Progression
	{
		public Difficulty normal { get; set; }
		public Difficulty nightmare { get; set; }
		public Difficulty hell { get; set; }
		public Difficulty inferno { get; set; }
	}
}

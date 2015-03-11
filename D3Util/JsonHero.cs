using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace D3Util
{
	[DataContract(Name = "hero")]
	public class HeroRoot
	{
		[DataMember(Name = "id")]
		public int id { get; set; }
		[DataMember(Name = "name")]
		public string name { get; set; }
		[DataMember(Name = "class")]
		public string @class { get; set; }
		[DataMember(Name = "gender")]
		public int gender { get; set; }
		[DataMember(Name = "level")]
		public int level { get; set; }
		[DataMember(Name = "paragonLevel")]
		public int paragonLevel { get; set; }
		[DataMember(Name = "hardcore")]
		public bool hardcore { get; set; }
		[DataMember(Name = "seasonal")]
		public bool seasonal { get; set; }
		[DataMember(Name = "seasonCreated")]
		public int seasonCreated { get; set; }
		[DataMember(Name = "skills")]
		public Skills skills { get; set; }
		[DataMember(Name = "items")]
		public Items items { get; set; }
		[DataMember(Name = "followers")]
		public Followers followers { get; set; }
		[DataMember(Name = "stats")]
		public JsonStats stats { get; set; }
		[DataMember(Name = "kills")]
		public Kills kills { get; set; }
		[DataMember(Name = "progression")]
		public HeroProgression progression { get; set; }
		[DataMember(Name = "dead")]
		public bool dead { get; set; }
		[DataMember(Name = "last-updated")]
		public int lastUpdated { get; set; }

		public override string ToString()
		{
			return name + " Lv:" + level + (paragonLevel > 0 ? "(" + paragonLevel + ")" : string.Empty);
		}
	}

	public class SkillActive
	{
		public string slug { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public int level { get; set; }
		public string categorySlug { get; set; }
		public string tooltipUrl { get; set; }
		public string description { get; set; }
		public string simpleDescription { get; set; }
		public string skillCalcId { get; set; }

		public override string ToString()
		{
			return name;
		}
	}

	public class Rune
	{
		public string slug { get; set; }
		public string type { get; set; }
		public string name { get; set; }
		public int level { get; set; }
		public string description { get; set; }
		public string simpleDescription { get; set; }
		public string tooltipParams { get; set; }
		public string skillCalcId { get; set; }
		public int order { get; set; }
	}

	public class Active
	{
		public SkillActive skill { get; set; }
		public Rune rune { get; set; }

		public override string ToString()
		{
			if (skill == null) return string.Empty;
			return skill.name + (rune != null ? "(" + rune.name + ")" : string.Empty);
		}
	}

	public class SkillPassive
	{
		public string slug { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public string tooltipUrl { get; set; }
		public string description { get; set; }
		public string flavor { get; set; }
		public string skillCalcId { get; set; }
		public int level { get; set; }

		public override string ToString()
		{
			return name;
		}
	}

	public class Passive
	{
		public SkillPassive skill { get; set; }

		public override string ToString()
		{
			return skill != null ? skill.name : string.Empty;
		}
	}

	public class Skills
	{
		public List<Active> active { get; set; }
		public List<Passive> passive { get; set; }
	}

	public class ItemsFollower
	{
		public MainHand mainHand { get; set; }
		public OffHand offHand { get; set; }
		public Ring rightFinger { get; set; }
		public Ring leftFinger { get; set; }
		public Neck neck { get; set; }
		public Special special { get; set; }
	}

	public class StatsFollower
	{
		public int goldFind { get; set; }
		public int magicFind { get; set; }
		public int experienceBonus { get; set; }
	}

	public class SkillFollower
	{
		public string slug { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public int level { get; set; }
		public string tooltipUrl { get; set; }
		public string description { get; set; }
		public string simpleDescription { get; set; }
		public string skillCalcId { get; set; }

		public override string ToString()
		{
			return name;
		}
	}

	public class FollowerSkill
	{
		public SkillFollower skill { get; set; }

		public override string ToString()
		{
			return skill != null ? skill.name : string.Empty;
		}
	}

	public class Follower
	{
		public string slug { get; set; }
		public int level { get; set; }
		public ItemsFollower items { get; set; }
		public StatsFollower stats { get; set; }
		public List<FollowerSkill> skills { get; set; }

		public override string ToString()
		{
			return slug + " Lv:" + level;
		}
	}

	public class Followers
	{
		public Follower templar { get; set; }
		public Follower scoundrel { get; set; }
		public Follower enchantress { get; set; }
	}

	public class HeroProgression
	{
		public Act act1 { get; set; }
		public Act act2 { get; set; }
		public Act act3 { get; set; }
		public Act act4 { get; set; }
		public Act act5 { get; set; }
	}

	public class Act
	{
		public bool completed { get; set; }
		public List<CompletedQuest> completedQuests { get; set; }
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
}

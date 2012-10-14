using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace D3Util
{
	public class ItemRoot
	{
		public string id { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public string displayColor { get; set; }
		public string tooltipParams { get; set; }
		public int requiredLevel { get; set; }
		public int itemLevel { get; set; }
		public int bonusAffixes { get; set; }
		public string flavorText { get; set; }
		public string typeName { get; set; }
		public Type type { get; set; }
		public Attribute dps { get; set; }
		public Attribute attacksPerSecond { get; set; }
		public Attribute minDamage { get; set; }
		public Attribute maxDamage { get; set; }
		public Attribute armor { get; set; }
		public List<string> attributes { get; set; }
		public AttributesRaw attributesRaw { get; set; }
		public List<SocketEffect> socketEffects { get; set; }
		public List<Salvage> salvage { get; set; }
		public Set set { get; set; }
		public List<Gem> gems { get; set; }

		public Attribute damage
		{
			get
			{
				if (minDamage == null || maxDamage == null)
					return null;

				Attribute dam = new Attribute(minDamage.min, maxDamage.max);

				if (attributesRaw.Damage_Weapon_Min_Fire != null)
				{
					dam.min += attributesRaw.Damage_Weapon_Min_Fire.min;
					dam.max += attributesRaw.Damage_Weapon_Min_Fire.min + attributesRaw.Damage_Weapon_Delta_Fire.max;
				}

				if (attributesRaw.Damage_Weapon_Min_Cold != null)
				{
				dam.min += attributesRaw.Damage_Weapon_Min_Cold.min;
				dam.max += attributesRaw.Damage_Weapon_Min_Cold.min + attributesRaw.Damage_Weapon_Delta_Cold.max;
				}

				if (attributesRaw.Damage_Weapon_Min_Lightning != null)
				{
				dam.min += attributesRaw.Damage_Weapon_Min_Lightning.min;
				dam.max += attributesRaw.Damage_Weapon_Min_Lightning.min + attributesRaw.Damage_Weapon_Delta_Lightning.max;
				}

				if (attributesRaw.Damage_Weapon_Min_Poison != null)
				{
				dam.min += attributesRaw.Damage_Weapon_Min_Poison.min;
				dam.max += attributesRaw.Damage_Weapon_Min_Poison.min + attributesRaw.Damage_Weapon_Delta_Poison.max;
				}

				if (attributesRaw.Damage_Weapon_Min_Arcane != null)
				{
					dam.min += attributesRaw.Damage_Weapon_Min_Arcane.min;
					dam.max += attributesRaw.Damage_Weapon_Min_Arcane.min + attributesRaw.Damage_Weapon_Delta_Arcane.max;
				}

				if (attributesRaw.Damage_Weapon_Min_Holy != null)
				{
					dam.min += attributesRaw.Damage_Weapon_Min_Holy.min;
					dam.max += attributesRaw.Damage_Weapon_Min_Holy.min + attributesRaw.Damage_Weapon_Delta_Holy.max;
				}

				return dam;
			}
		}

		public override string ToString()
		{
			return name;
		}
	}

	public class Type
	{
		public string id { get; set; }
		public bool twoHanded { get; set; }
	}

	public class Attribute
	{
		public float min { get; set; }
		public float max { get; set; }
		public float average { get { return (max + min) / 2; } }

		public Attribute()
		{
		}

		public Attribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}

		public override string ToString()
		{
			return min + "-" + max;
		}
	}

	[DataContract(Name = "AttributesRaw")]
	public class AttributesRaw
	{
		[DataMember(Name = "Durability_Cur")]
		public Attribute Durability_Cur { get; set; }
		[DataMember(Name = "Durability_Max")]
		public Attribute Durability_Max { get; set; }
		[DataMember(Name = "Attacks_Per_Second_Item")]
		public Attribute Attacks_Per_Second_Item { get; set; }
		/// <summary>
		/// Attack speed bonus on Weapon
		/// </summary>
		[DataMember(Name = "Attacks_Per_Second_Item_Percent")]
		public Attribute Attacks_Per_Second_Item_Percent { get; set; }
		/// <summary>
		/// Attack speed bonus on Armor
		/// </summary>
		[DataMember(Name = "Attacks_Per_Second_Percent")]
		public Attribute Attacks_Per_Second_Percent { get; set; }
		[DataMember(Name = "Damage_Weapon_Min#Physical")]
		public Attribute Damage_Weapon_Min_Physical { get; set; }
		[DataMember(Name = "Damage_Weapon_Delta#Physical")]
		public Attribute Damage_Weapon_Delta_Physical { get; set; }
		[DataMember(Name = "Damage_Weapon_Min#Fire")]
		public Attribute Damage_Weapon_Min_Fire { get; set; }
		[DataMember(Name = "Damage_Weapon_Delta#Fire")]
		public Attribute Damage_Weapon_Delta_Fire { get; set; }
		[DataMember(Name = "Damage_Weapon_Min#Cold")]
		public Attribute Damage_Weapon_Min_Cold { get; set; }
		[DataMember(Name = "Damage_Weapon_Delta#Cold")]
		public Attribute Damage_Weapon_Delta_Cold { get; set; }
		[DataMember(Name = "Damage_Weapon_Min#Lightning")]
		public Attribute Damage_Weapon_Min_Lightning { get; set; }
		[DataMember(Name = "Damage_Weapon_Delta#Lightning")]
		public Attribute Damage_Weapon_Delta_Lightning { get; set; }
		[DataMember(Name = "Damage_Weapon_Min#Poison")]
		public Attribute Damage_Weapon_Min_Poison { get; set; }
		[DataMember(Name = "Damage_Weapon_Delta#Poison")]
		public Attribute Damage_Weapon_Delta_Poison { get; set; }
		[DataMember(Name = "Damage_Weapon_Min#Arcane")]
		public Attribute Damage_Weapon_Min_Arcane { get; set; }
		[DataMember(Name = "Damage_Weapon_Delta#Arcane")]
		public Attribute Damage_Weapon_Delta_Arcane { get; set; }
		[DataMember(Name = "Damage_Weapon_Min#Holy")]
		public Attribute Damage_Weapon_Min_Holy { get; set; }
		[DataMember(Name = "Damage_Weapon_Delta#Holy")]
		public Attribute Damage_Weapon_Delta_Holy { get; set; }
		[DataMember(Name = "Damage_Min#Physical")]
		public Attribute Damage_Min_Physical { get; set; }
		[DataMember(Name = "Damage_Delta#Physical")]
		public Attribute Damage_Delta_Physical { get; set; }
		[DataMember(Name = "Damage_Weapon_Percent_Bonus#Physical")]
		public Attribute Damage_Weapon_Percent_Bonus_Physical { get; set; }
		[DataMember(Name = "Crossbow")]
		public Attribute Crossbow { get; set; }
		[DataMember(Name = "Armor_Item")]
		public Attribute Armor_Item { get; set; }
		[DataMember(Name = "Armor_Bonus_Item")]
		public Attribute Armor_Bonus_Item { get; set; }
		[DataMember(Name = "GemQuality")]
		public Attribute GemQuality { get; set; }
		[DataMember(Name = "Sockets")]
		public Attribute Sockets { get; set; }
		[DataMember(Name = "Strength_Item")]
		public Attribute Strength_Item { get; set; }
		[DataMember(Name = "Dexterity_Item")]
		public Attribute Dexterity_Item { get; set; }
		[DataMember(Name = "Intelligence_Item")]
		public Attribute Intelligence_Item { get; set; }
		[DataMember(Name = "Vitality_Item")]
		public Attribute Vitality_Item { get; set; }
		[DataMember(Name = "Hitpoints_Max_Percent_Bonus_Item")]
		public Attribute Hitpoints_Max_Percent_Bonus_Item { get; set; }
		[DataMember(Name = "Hitpoints_Regen_Per_Second")]
		public Attribute Hitpoints_Regen_Per_Second { get; set; }
		[DataMember(Name = "Hitpoints_On_Hit")]
		public Attribute Hitpoints_On_Hit { get; set; }
		[DataMember(Name = "Health_Globe_Bonus_Health")]
		public Attribute Health_Globe_Bonus_Health { get; set; }
		[DataMember(Name = "Resource_Regen_Per_Second#Mana")]
		public Attribute Resource_Regen_Per_Second_Mana { get; set; }
		[DataMember(Name = "Resource_On_Crit#Arcanum")]
		public Attribute Resource_On_Crit_Arcanum { get; set; }
		[DataMember(Name = "Spending_Resource_Heals_Percent#Fury")]
		public Attribute Spending_Resource_Heals_Percent_Fury { get; set; }
		[DataMember(Name = "Crit_Percent_Bonus_Capped")]
		public Attribute Crit_Percent_Bonus_Capped { get; set; }
		[DataMember(Name = "Crit_Damage_Percent")]
		public Attribute Crit_Damage_Percent { get; set; }
		[DataMember(Name = "Resistance_All")]
		public Attribute Resistance_All { get; set; }
		[DataMember(Name = "Resistance#Physical")]
		public Attribute Resistance_Physical { get; set; }
		[DataMember(Name = "Resistance#Fire")]
		public Attribute Resistance_Fire { get; set; }
		[DataMember(Name = "Resistance#Cold")]
		public Attribute Resistance_Cold { get; set; }
		[DataMember(Name = "Resistance#Lightning")]
		public Attribute Resistance_Lightning { get; set; }
		[DataMember(Name = "Resistance#Poison")]
		public Attribute Resistance_Poison { get; set; }
		[DataMember(Name = "Resistance#Arcane")]
		public Attribute Resistance_Arcane { get; set; }
		[DataMember(Name = "Resistance#Holy")]
		public Attribute Resistance_Holy { get; set; }
		[DataMember(Name = "Damage_Percent_Reduction_From_Melee")]
		public Attribute Damage_Percent_Reduction_From_Melee { get; set; }
		[DataMember(Name = "Thorns_Fixed#Physical")]
		public Attribute Thorns_Fixed_Physical { get; set; }
		[DataMember(Name = "CrowdControl_Reduction")]
		public Attribute CrowdControl_Reduction { get; set; }
		[DataMember(Name = "Gold_PickUp_Radius")]
		public Attribute Gold_PickUp_Radius { get; set; }
		[DataMember(Name = "Movement_Scalar")]
		public Attribute Movement_Scalar { get; set; }
		[DataMember(Name = "Gold_Find")]
		public Attribute Gold_Find { get; set; }
		[DataMember(Name = "Magic_Find")]
		public Attribute Magic_Find { get; set; }
		[DataMember(Name = "Experience_Bonus_Percent")]
		public Attribute Experience_Bonus_Percent { get; set; }
		[DataMember(Name = "Experience_Bonus")]
		public Attribute Experience_Bonus { get; set; }
		[DataMember(Name = "Weapon_On_Hit_Knockback_Proc_Chance")]
		public Attribute Weapon_On_Hit_Knockback_Proc_Chance { get; set; }
		/*
		[DataMember(Name = "")]
		public Attribute Damage_Weapon_Delta_Poison { get; set; }
		*/
	}

	public class Salvage
	{
		public double chance { get; set; }
		public Item item { get; set; }
		public int quantity { get; set; }

		public override string ToString()
		{
			return chance.ToString("P") + " " + item.name + " x" + quantity;
		}
	}

	public class SocketEffect
	{
		public string itemTypeId { get; set; }
		public string itemTypeName { get; set; }
		public AttributesRawGem attributesRaw { get; set; }
		public List<string> attributes { get; set; }

		public override string ToString()
		{
			return itemTypeName;
		}
	}

	public class Rank
	{
		public int required { get; set; }
		public List<string> attributes { get; set; }

		public override string ToString()
		{
			return "(" + required + ") Set";
		}
	}

	public class Set
	{
		public string slug { get; set; }
		public string name { get; set; }
		public List<Rank> ranks { get; set; }
		public List<Item> items { get; set; }
	}

	[DataContract(Name = "AttributesRaw")]
	public class AttributesRawGem
	{
		[DataMember(Name = "Experience_Bonus_Percent")]
		public Attribute Experience_Bonus_Percent { get; set; }
		[DataMember(Name = "Gold_Find")]
		public Attribute Gold_Find { get; set; }
		[DataMember(Name = "Magic_Find")]
		public Attribute Magic_Find { get; set; }
		[DataMember(Name = "Hitpoints_Max_Percent_Bonus_Item")]
		public Attribute Hitpoints_Max_Percent_Bonus_Item { get; set; }
		[DataMember(Name = "Damage_Weapon_Bonus_Min#Physical")]
		public Attribute Damage_Weapon_Bonus_Min_Physical { get; set; }
		[DataMember(Name = "Damage_Weapon_Bonus_Delta#Physical")]
		public Attribute Damage_Weapon_Bonus_Delta_Physical { get; set; }
		[DataMember(Name = "Crit_Damage_Percent")]
		public Attribute Crit_Damage_Percent { get; set; }
		[DataMember(Name = "Thorns_Fixed#Physical")]
		public Attribute Thorns_Fixed_Physical { get; set; }
		[DataMember(Name = "Hitpoints_On_Hit")]
		public Attribute Hitpoints_On_Hit { get; set; }
		[DataMember(Name = "Strength_Item")]
		public Attribute Strength_Item { get; set; }
		[DataMember(Name = "Dexterity_Item")]
		public Attribute Dexterity_Item { get; set; }
		[DataMember(Name = "Intelligence_Item")]
		public Attribute Intelligence_Item { get; set; }
		[DataMember(Name = "Vitality_Item")]
		public Attribute Vitality_Item { get; set; }
	}

	public class Gem
	{
		public Item item { get; set; }
		public AttributesRawGem attributesRaw { get; set; }
		public List<string> attributes { get; set; }

		public override string ToString()
		{
			return item.name;
		}
	}
}

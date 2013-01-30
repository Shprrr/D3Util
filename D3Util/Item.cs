using System;
using System.Collections.Generic;
using System.Linq;

namespace D3Util
{
	public class Item
	{
		private ItemRoot _Root;

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

		public Attribute damage { get; set; }

		public Set setOwned { get; set; }
		public double DpsDifference { get; set; }
		public int EhpDifference { get; set; }

		public Item(ItemRoot root)
		{
			_Root = root;

			id = root.id;
			name = root.name;
			icon = root.icon;
			displayColor = root.displayColor;
			tooltipParams = root.tooltipParams;
			requiredLevel = root.requiredLevel;
			itemLevel = root.itemLevel;
			bonusAffixes = root.bonusAffixes;
			flavorText = root.flavorText;
			typeName = root.typeName;
			type = root.type;
			dps = root.dps;
			attacksPerSecond = root.attacksPerSecond;
			minDamage = root.minDamage;
			maxDamage = root.maxDamage;
			armor = root.armor;
			attributes = root.attributes;
			attributesRaw = root.attributesRaw;
			socketEffects = root.socketEffects;
			salvage = root.salvage;
			set = root.set;
			gems = root.gems;

			damage = root.damage;
		}

		public void CalculWithHero(Hero hero, Hero.Slot slot)
		{
			if (set != null)
			{
				setOwned = new Set();
				setOwned.slug = set.slug;
				setOwned.name = set.name;
				setOwned.ranks = new List<Rank>();
				setOwned.items = new List<JsonItem>();
				foreach (var setItem in set.items)
				{
					foreach (var item in hero.items)
					{
						if (item.Value._Root.id == setItem.id)
						{
							setOwned.items.Add(setItem);
							foreach (var rank in set.ranks)
							{
								if (rank.required == setOwned.items.Count)
								{
									setOwned.ranks.Add(rank);
									break;
								}
							}
							break;
						}
					}
				}
			}

			Stats statsWithout = hero.CalculStatsWithout(slot);

			DpsDifference = hero.statsUnbuffed.dps - statsWithout.dps;
			EhpDifference = hero.statsUnbuffed.effectiveHp - statsWithout.effectiveHp;
		}

		public override string ToString()
		{
			return name;
		}
	}
}

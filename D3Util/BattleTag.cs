using System;

namespace D3Util
{
	public struct BattleTag
	{
		public string Name { get; set; }
		public int Code { get; set; }

		public string Id { get { return Name + "-" + Code; } }

		public override string ToString()
		{
			return Name + "#" + Code;
		}

		public BattleTag(string name, int code)
			: this()
		{
			Name = name;
			Code = code;
		}

		public BattleTag(string battleTag)
			: this()
		{
			string[] split = battleTag.Split('#', '-');
			Name = split[0];
			Code = int.Parse(split[1]);
		}

		public override bool Equals(object obj)
		{
			if (obj is BattleTag)
				return this == (BattleTag)obj;
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public static bool operator ==(BattleTag bt1, BattleTag bt2)
		{
			return bt1.Id == bt2.Id;
		}

		public static bool operator !=(BattleTag bt1, BattleTag bt2)
		{
			return !(bt1 == bt2);
		}
	}
}

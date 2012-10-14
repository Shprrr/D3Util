using System;
using System.Collections.Generic;
using System.IO;

namespace D3Util
{
	public class Config
	{
		public List<BattleTag> BattleTags { get; set; }

		public Config()
		{
			BattleTags = new List<BattleTag>();
		}

		public static Config Load(string filename)
		{
			Config config = new Config();

			if (!File.Exists(filename))
				return config;

			string[] lines = File.ReadAllLines(filename);
			foreach (string line in lines)
			{
				config.BattleTags.Add(new BattleTag(line));
			}

			return config;
		}

		public void Save(string filename)
		{
			List<string> lines = new List<string>();
			foreach (BattleTag battleTag in BattleTags)
			{
				lines.Add(battleTag.ToString());
			}
			File.WriteAllLines(filename, lines);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace D3Util
{
	public partial class frmDebug : Form
	{
		public frmDebug()
		{
			InitializeComponent();

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Profile));
			//Profile profile = (Profile)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/profile/maxtal-1668/"));
			//Profile profile = (Profile)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/profile/Sebjean-1630/"));
			Profile profile = (Profile)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/profile/Zepaz-1571/"));

			//Text = profile.battleTag;
			//FillProfile(profile);

			serializer = new DataContractJsonSerializer(typeof(HeroRoot));
			HeroRoot hero1 = (HeroRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/profile/maxtal-1668/hero/5466231"));
			//HeroRoot hero1 = (HeroRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/profile/maxtal-1668/hero/894692"));
			//HeroRoot hero1 = (HeroRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/profile/Zepaz-1571/hero/7118673"));
			//Text = hero1.ToString();
			//FillHero(hero1);

			serializer = new DataContractJsonSerializer(typeof(ItemRoot));
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CmwIw_mmbhIHCAQVwwtLnR11EXUVHUljTzAddPdKBx2OsMzQHdCI9w0dYVCqByILCAEVcUIDABgEICQwCTiPBUAAUBBgjwVqJQoMCAAQoYb_p4CAgKApEhUI1JCm-Q8SBwgEFUX1i18wDTgAQAEY-dCnqwxQAlgA")); //Shprrr offHand
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CkEI5Pnf5AsSBwgEFbOWItod52EH8h1H45XjHWH0yGodDVz0_B3FjW0dIgsIABXD_gEAGA4gCjAJOKADQABQDGCgAxiZpevdBFAGWAA")); //maxtal mainHand
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CkgIot_8sQISBwgEFZQA9SQdxY1tHR12Tww1Hd1h_R0d0DciAx2L8T_7HZKZU2giCwgAFbH-AQAYHCAkMAk4kgRAAEgDUBBgkgQYqIKozwRQBlgA")); //maxtal head
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/chipped-emerald")); //chipped emerald
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CIKr_NgFEgcIBBWDsaRoHVugG9gdKRJz4B1l3mdxHe0woCgdhgJj6h05byLFIgsIARWIQgMAGAAgHjAJOFxAAEgDUBBg8gJqIQoMCAAQ6uqK1YCAgOA4EhEIABIHCAQVz122ejAJOABAAQ")); //item random Wizard hat
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CkEI_c7drAISBwgEFXujQtQdkCb-qx28W-hIHY-CxX0dci-OJx305FIqIgsIARV4QgMAGBAgDjANOIkDQABQDmCJAxiJ8uq7BVAGWAA")); //maxtal belt
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CmgIxurZ3QgSBwgEFQ8X9vkdePaMzx1390oHHQnRkggdwYQCWB07sszQIgsIARVsQgMAGAwgGDAJOMwDQABQDmDMA2olCgwIABCT67CYgYCAwBESFQijw-2sCRIHCAQVSPWLXzAJOABAARjho89gUAhYAA")); //Talon mainHand
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CkwIzaH5sgoSBwgEFfVUXUQd1x3Qih2FvzSKMAk4kQRAAFAIYJEEaiUKDAgAEIvfr5iBgIDAERIVCNjZtIYHEgcIBBUAlq6YMAk4AEABGOrT6sUIUAhYAA")); //Talon ringRight
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CmAI_4WS5QwSBwgEFUisKWEdlL80ih3nvppxHdmZhNgdtOJ6kx2gbLMUHTbMOzowCTjkAUAAUBJgnwJqJQoMCAAQ9Y-j3ICAgOAIEhUI1vXMiAESBwgEFR6WrpgwCTgAQAEYkLHNkgxQAlgA")); //random Barb mainHand
			//ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CjkI2KLrlg8SBwgEFYMEfeodWGlQXx2Ivr4hHQrqUAgdaNwK8R0i7My4HVtOgMkwCTjGAkAAUBJgjAMY-e2X2AJQAlgAoAHxsdXjDaAB-e2X2AKgAcCEs6EDoAHokMvhA6ABosHHvg0")); //random Barb boot
			ItemRoot item1 = (ItemRoot)serializer.ReadObject(GetStream("http://us.battle.net/api/d3/data/item/CjkI-9-ChQ8SBwgEFVHw6GsdDVfMGh2W1cOdHdZmipQdDmt__R3SXcJLHcJqmxEwCTjDAUAAUBJg-wEYosHHvg1QAlgAoAHxsdXjDaAB-e2X2AKgAcCEs6EDoAHokMvhA6ABosHHvg0")); //random Barb glove
			Text = item1.ToString();
			FillItem(item1);
		}

		public Stream GetStream(string url)
		{
			return HttpWebRequest.Create(url).GetResponse().GetResponseStream();
		}

		private void FillProfile(Profile profile)
		{
			foreach (var property in profile.GetType().GetProperties())
			{
				if (property.PropertyType.IsGenericType)
				{
					TreeNode nodeParent = new TreeNode(property.Name);
					ICollection list = (ICollection)property.GetValue(profile, null);
					if (list != null)
						foreach (var item in list)
						{
							TreeNode node = new TreeNode(item.ToString());
							FillProfile(item, node);
							nodeParent.Nodes.Add(node);
						}
					trvProfile.Nodes.Add(nodeParent);
				}
				else if (property.PropertyType.IsClass && property.PropertyType.Namespace == "D3Util")
				{
					TreeNode node = new TreeNode(property.Name);
					object obj = property.GetValue(profile, null);
					FillProfile(obj, node);
					trvProfile.Nodes.Add(node);
				}
				else
					trvProfile.Nodes.Add(property.Name + "=" + property.GetValue(profile, null));
			}
		}

		private void FillProfile(object profile, TreeNode nodeParent)
		{
			if (profile == null || profile.GetType().Namespace != "D3Util")
				return;

			foreach (var property in profile.GetType().GetProperties())
			{
				if (property.PropertyType.IsGenericType)
				{
					TreeNode nodeParentGeneric = new TreeNode(property.Name);
					ICollection list = (ICollection)property.GetValue(profile, null);
					if (list != null)
						foreach (var item in list)
						{
							TreeNode node = new TreeNode(item.ToString());
							FillProfile(item, node);
							nodeParentGeneric.Nodes.Add(node);
						}
					nodeParent.Nodes.Add(nodeParentGeneric);
				}
				else if (property.PropertyType.IsClass && property.PropertyType.Namespace == "D3Util")
				{
					TreeNode node = new TreeNode(property.Name);
					object obj = property.GetValue(profile, null);
					FillProfile(obj, node);
					nodeParent.Nodes.Add(node);
				}
				else
					nodeParent.Nodes.Add(property.Name + "=" + property.GetValue(profile, null));
			}
		}

		private void FillHero(HeroRoot hero)
		{
			foreach (var property in hero.GetType().GetProperties())
			{
				if (property.PropertyType.IsGenericType)
				{
					TreeNode nodeParent = new TreeNode(property.Name);
					ICollection list = (ICollection)property.GetValue(hero, null);
					if (list != null)
						foreach (var item in list)
						{
							TreeNode node = new TreeNode(item.ToString());
							FillProfile(item, node);
							nodeParent.Nodes.Add(node);
						}
					trvProfile.Nodes.Add(nodeParent);
				}
				else if (property.PropertyType.IsClass && property.PropertyType.Namespace == "D3Util")
				{
					TreeNode node = new TreeNode(property.Name);
					object obj = property.GetValue(hero, null);
					FillProfile(obj, node);
					trvProfile.Nodes.Add(node);
				}
				else
					trvProfile.Nodes.Add(property.Name + "=" + property.GetValue(hero, null));
			}
		}

		private void FillItem(ItemRoot itemRoot)
		{
			foreach (var property in itemRoot.GetType().GetProperties())
			{
				if (property.PropertyType.IsGenericType)
				{
					TreeNode nodeParent = new TreeNode(property.Name);
					ICollection list = (ICollection)property.GetValue(itemRoot, null);
					if (list != null)
						foreach (var item in list)
						{
							TreeNode node = new TreeNode(item.ToString());
							FillProfile(item, node);
							nodeParent.Nodes.Add(node);
						}
					trvProfile.Nodes.Add(nodeParent);
				}
				else if (property.PropertyType.IsClass && property.PropertyType.Namespace == "D3Util")
				{
					TreeNode node = new TreeNode(property.Name);
					object obj = property.GetValue(itemRoot, null);
					FillProfile(obj, node);
					trvProfile.Nodes.Add(node);
				}
				else
					trvProfile.Nodes.Add(property.Name + "=" + property.GetValue(itemRoot, null));
			}
		}
	}
}

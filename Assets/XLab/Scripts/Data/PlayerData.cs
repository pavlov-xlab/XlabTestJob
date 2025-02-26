using System;
using System.Collections.Generic;
using UnityEngine;

namespace Xlab
{
	public class PlayerData
	{
		public Inventory inventory { private set; get; }

		private Dictionary<string, PlayerResource> m_resources = new Dictionary<string, PlayerResource>();

		public PlayerState lastPlayerState = new PlayerState();


		public PlayerData()
		{
			Reset();
		}

		public void Reset()
		{
			lastPlayerState = new PlayerState();
			inventory = new Inventory(10);
			inventory.SetItem(0, "9ba6eeeb-faa1-47d7-9c25-c0699c0a6d81");

			m_resources.Clear();
			m_resources.Add("soft", new PlayerResource() { id = "soft", count = 100 });
			m_resources.Add("hard", new PlayerResource() { id = "hard", count = 10 });
			m_resources.Add("exp", new PlayerResource() { id = "exp", count = 0 });
		}

		public void RefreshInventory(Inventory inventory)
		{
			this.inventory = inventory.Clone();
		}

		public void IncResources(string id, int value)
		{
			if (m_resources.TryGetValue(id, out var res))
			{
				res.count += value;
			}
		}

		public void SpendResources(string id, int value)
		{
			if (m_resources.TryGetValue(id, out var res))
			{
				res.count = Mathf.Max(res.count - value, 0);
			}
		}

		public string ToJson()
		{
			SaveData saveData = new SaveData();
			saveData.state = lastPlayerState;

			foreach (var res in m_resources)
			{
				saveData.resources.Add(res.Value);
			}

			return JsonUtility.ToJson(saveData);
		}

		public void FromJson(string json)
		{
			SaveData saveData = JsonUtility.FromJson<SaveData>(json);
			if (saveData != null)
			{
				lastPlayerState = saveData.state;

				foreach (var res in saveData.resources)
				{
					m_resources[res.id].count = res.count;
				}
			}
		}

		[System.Serializable]
		private class SaveData
		{
			public PlayerState state;
			public List<PlayerResource> resources = new List<PlayerResource>();
		}
	}

	[System.Serializable]
	public class PlayerState
	{
		public Vector3 pos;
		public Vector3 rot;
		public int hp;
		public bool valid;
	}

	[System.Serializable]
	public class PlayerResource
	{
		public string id;
		public int count;

		public PlayerResource()
		{
			
		}

		public PlayerResource(string id, int count)
		{
			this.id = id;
			this.count = count;
		}
	}
}
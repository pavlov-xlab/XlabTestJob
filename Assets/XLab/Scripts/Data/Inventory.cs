using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Xlab
{
	public class Inventory
	{
		private List<InventorySlot> m_slots;

		public IReadOnlyList<InventorySlot> slots => m_slots;

		public Inventory(int slotSize)
		{
			m_slots = new List<InventorySlot>(slotSize);
			for (int i = 0; i < slotSize; ++i)
			{
				m_slots.Add(new InventorySlot());
			}
		}

		public Inventory Clone()
		{
			Inventory clone = new Inventory(m_slots.Count);
			clone.m_slots.Clear();

			foreach (var slot in m_slots)
			{
				clone.m_slots.Add(new InventorySlot() { item = slot.item, count = slot.count });
			}

			return clone;
		}

		public void AddItem(string item)
		{
			int index = m_slots.FindIndex(x => x.item == item);
			if (index >= 0)
			{
				SetItem(index, item);
			}
		}

		public bool Exist(string item)
		{
			return m_slots.FindIndex(x => x.item == item) >= 0;
		}

		public void AddItemInNextSlot(string item)
		{
			int index = m_slots.FindIndex(x => x.item == item);
			if (index >= 0)
			{
				SetItem(index, item);
			}
			else
			{
				index = m_slots.FindIndex(x => string.IsNullOrEmpty(x.item));
				if (index >= 0)
				{
					SetItem(index, item);
				}
			}
		}

		public void RemoveItem(string item)
		{
			var slot = m_slots.Find(x => x.item == item);
			if (slot != null)
			{
				if (--slot.count == 0)
				{
					slot.item = null;
				}
			}
		}

		public void SetItem(int indexSlot, string item)
		{
			if (m_slots.Count > 0 && indexSlot < m_slots.Count)
			{
				var slot = m_slots[indexSlot];
				slot.item = item;
				slot.count++;
			}
		}

		public string ToJson()
		{
			SaveData saveData = new SaveData();
			saveData.slots = m_slots;

			return JsonUtility.ToJson(saveData);
		}

		public void FromJson(string json)
		{
			SaveData saveData = JsonUtility.FromJson<SaveData>(json);
			if (saveData != null)
			{
				m_slots = saveData.slots;
			}
		}

		[System.Serializable]
		private class SaveData
		{
			public List<InventorySlot> slots;
		}
	}

	[System.Serializable]
	public class InventorySlot
	{
		public string item;
		public int count;
	}

    public enum ItemCategory 
    {
        None, 
        Weapon,
    }
}
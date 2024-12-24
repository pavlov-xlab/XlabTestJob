using System.Collections.Generic;
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

        public void AddItem(string item)
        {
            int index = m_slots.FindIndex(x=>x.item == item);
            if (index >= 0)
            {
                SetItem(index, item);
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
    }

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
using TMPro;
using UnityEngine;

namespace Xlab
{

    public class UInventory : MonoBehaviour
    {
        public Transform container;
        public ItemsDB itemsDB;
        public TMP_Text m_itemDescription;

        private Inventory m_inventory;

        private void Start()
        {
            m_inventory = new Inventory(16);

            Fill(m_inventory);
        }

        public void RandomFill()
        {
            m_inventory = new Inventory(Random.Range(4, 16));

            for (int i = 0; i < 5; i++)
            {
                var rIndex = Random.Range(0, m_inventory.slots.Count);
                var rItemIndex = Random.Range(0, itemsDB.items.Count);
                m_inventory.SetItem(rIndex, itemsDB.items[rItemIndex].id);
            }

            Fill(m_inventory);
        }

        private void Fill(Inventory inventory)
        {
            var child = container.GetChild(0);
            var slotPrefab = child.GetComponent<UIInventorySlot>();
            var slots = inventory.slots;
            
            int maxCount = Mathf.Max(slots.Count, container.childCount);
            for (int i = 0; i < maxCount; ++i)
            {
                InventorySlot slot = null;
                UIInventorySlot uiSlot = null;

                if (i < slots.Count)
                {
                    slot = slots[i];
                }

                if (i < container.childCount)
                {
                    uiSlot = container.GetChild(i).GetComponent<UIInventorySlot>();;
                }
                else
                {
                    uiSlot = Instantiate(slotPrefab, container);
                }

                if (slot != null)
                {
                    uiSlot.SetData(itemsDB.GetItem(slot.item), slot.count);
                }
                else
                {
                    uiSlot.SetData(null, 0);
                }
                
                uiSlot.gameObject.SetActive(i < slots.Count);
                
                uiSlot.onMouseOver -= OnItemMouseOver;
                uiSlot.onMouseOver += OnItemMouseOver; 
            }
        }

        private void OnItemMouseOver(ItemsDB.Item item)
        {
            m_itemDescription.text = item != null ? item.description : "Empty";
        }
    }
}
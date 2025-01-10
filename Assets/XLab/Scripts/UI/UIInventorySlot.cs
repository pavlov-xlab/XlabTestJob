using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Xlab.ItemsDB;

namespace Xlab
{
    public class UIInventorySlot : MonoBehaviour, IPointerEnterHandler
    {
        public Image icon;
        public TMP_Text text;

        public event System.Action<Item> onMouseOver;

        private Item m_itemData;

        public void OnPointerEnter(PointerEventData eventData)
        {
            onMouseOver?.Invoke(m_itemData);
        }

        public void SetData(Item item, int count)
        {
            m_itemData = item;
            bool has = count > 0;

            if (has)
            {
                if (m_itemData != null)
                {
                    icon.sprite = m_itemData.icon;
                }

                text.text = count.ToString();
            }

            icon.gameObject.SetActive(has);
            text.gameObject.SetActive(has);
        }
    }
}
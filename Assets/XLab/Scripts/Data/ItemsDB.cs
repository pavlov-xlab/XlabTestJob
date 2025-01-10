using System;
using System.Collections.Generic;
using UnityEngine;

namespace Xlab
{
    [CreateAssetMenu(fileName = "ItemsDB", menuName = "Xlab/ItemsDB")]
    public class ItemsDB : ScriptableObject
    {
        [System.Serializable]
        public class Item
        {
            public string name;
            public string id;
            public Sprite icon;
            public string description;
            public ItemCategory category;
        }

        public List<Item> items;

        public Item GetItem(string id)
        {
            return items.Find(x=>x.id == id);
        }

        private void OnValidate()
        {
            items.ForEach(item =>
            {
                if (string.IsNullOrEmpty(item.id))
                {
                    item.id = Guid.NewGuid().ToString();
                }
            });
        }
    }
}

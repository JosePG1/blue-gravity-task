using System.Collections.Generic;
using UnityEngine;
using BlueGravity.World;

namespace BlueGravity.UI
{
    public class ShopListing : Panel
    {
        [SerializeField] ItemPurchaseEntry EntryTemplate;
        [SerializeField] List<Item> Items;

        public void OnEnable()
        {
            foreach ( var item in Items )
            {
                var entry = Instantiate( EntryTemplate, transform );
                entry.Item = item;
            }
        }
    }
}

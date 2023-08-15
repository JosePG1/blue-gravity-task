using System.Collections.Generic;
using UnityEngine;
using BlueGravity.World;
using TMPro;

namespace BlueGravity.UI
{
    public class ShopListing : Panel
    {
        [SerializeField] ItemPurchaseEntry EntryTemplate;
        [SerializeField] List<Item> Items;

        public void Awake()
        {
            foreach ( var item in Items )
            {
                var entry = Instantiate( EntryTemplate, transform ).GetComponent<ItemPurchaseEntry>();
                if ( item != null )
                {
                    entry.Item = item;
                }
                else
                {
                    Debug.LogError( $"Item do not exist" );
                }
            }
        }
    }
}

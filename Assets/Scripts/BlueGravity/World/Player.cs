using System.Collections.Generic;
using BlueGravity.UI;
using UnityEngine;
using Utilities;

namespace BlueGravity.World
{
    public class Player : Singleton<Player>
    {
        public int Coins = 100;

        public List<Item> Inventory = new();

        [SerializeField] PlayerController Controller;
        [SerializeField] Inventory InventoryPanel;

        public void GiveItem( Item item )
        {
            Inventory.Add( item );
            InventoryPanel.Refresh();
        }
    }
}
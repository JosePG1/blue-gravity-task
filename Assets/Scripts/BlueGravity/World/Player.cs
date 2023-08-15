using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace BlueGravity.World
{
    public class Player : Singleton<Player>
    {
        public int Coins = 100;

        public List<Item> Inventory = new();

        [SerializeField] PlayerController Controller;
    }
}
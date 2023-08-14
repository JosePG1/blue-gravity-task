using UnityEngine;

namespace BlueGravity.World
{
    public class Item : Entity
    {
        [SerializeField] Sprite Sprite;
        public int Price;
    }
}
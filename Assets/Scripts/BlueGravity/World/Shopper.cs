using BlueGravity.UI;
using UnityEngine;

namespace BlueGravity.World
{
    public class Shopper : Character, IInteractable
    {
        [SerializeField] ShopListing ShopListing;

        public void Interact()
        {
            ShopListing.Toggle();
        }
    }
}
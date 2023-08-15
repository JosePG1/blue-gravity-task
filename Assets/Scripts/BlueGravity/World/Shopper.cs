using System;
using BlueGravity.UI;
using UnityEngine;

namespace BlueGravity.World
{
    public class Shopper : Character, IInteractable
    {
        [SerializeField] GameObject Shop;
        [SerializeField] ShopListing ShopListing;
        

        public void Interact()
        {
            Shop.SetActive( true );
            ShopListing.Toggle();
        }

        void OnTriggerEnter2D( Collider2D other )
        {
            if ( other.gameObject.CompareTag( "Player" ) )
            {
                Interact();
            }
        }

        void OnTriggerExit2D( Collider2D other )
        {
            if ( other.gameObject.CompareTag( "Player" ) )
            {
                Shop.SetActive( false );
                ShopListing.Toggle();
            }
        }
    }
}
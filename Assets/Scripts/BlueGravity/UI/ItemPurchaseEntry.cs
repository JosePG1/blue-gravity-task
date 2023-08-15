using BlueGravity.World;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI
{
    public class ItemPurchaseEntry: UIElement
    {
        public Item Item;
        [SerializeField] Image EntryItemImage;
        [SerializeField] TextMeshProUGUI ItemName;
        [SerializeField] Button PurchaseButton;

        [SerializeField] Panel LowBalancePanel;
        
        public void Start()
        {
            if ( Item != null )
            {
                EntryItemImage.sprite = Item.ItemSprite;
                ItemName.text = Item.Name;
                PurchaseButton.onClick.AddListener( BuyItem );
            }
            else
            {
                Debug.LogError( "Item is null" );
            }
        }

        void BuyItem()
        {
            
            if ( Player.Instance.Coins > Item.Price )
            {
                Debug.LogError( $"Buy item" );
                Player.Instance.Inventory.Add( Item );
            }
            else
            {
                Debug.LogError( $"No buy the item" );
                LowBalancePanel.Show();
            }
        }
    }
}
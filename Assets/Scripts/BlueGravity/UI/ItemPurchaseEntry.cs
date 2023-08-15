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
        [SerializeField] TextMeshProUGUI ItemPrice;
        [SerializeField] Button PurchaseButton;
        [SerializeField] Panel LowBalancePanel;
        
        public void Start()
        {
            if ( Item != null )
            {
                EntryItemImage.sprite = Item.ItemSprite;
                ItemName.text = Item.Name;
                ItemPrice.text = Item.Price.ToString();
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
                Player.Instance.Coins -= Item.Price;
                FindObjectOfType<GamePlayPanel>().UpdateCoinsValue();
                Player.Instance.GiveItem( Item );
            }
            else
            {
                LowBalancePanel.Show();
            }
        }
    }
}
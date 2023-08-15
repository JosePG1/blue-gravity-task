using BlueGravity.World;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI
{
    public class ItemPurchaseEntry: MonoBehaviour
    {
        public Item Item;
        [SerializeField] Button PurchaseButton;

        [SerializeField] Panel LowBalancePanel;
        
        public void OnEnable()
        {
            PurchaseButton.onClick.AddListener( BuyItem );
        }

        void BuyItem()
        {
            if ( Player.Instance.Money > Item.Price )
            {
                Player.Instance.Inventory.Add( Item );
            }
            else
            {
                LowBalancePanel.Show();
            }
        }
    }
}
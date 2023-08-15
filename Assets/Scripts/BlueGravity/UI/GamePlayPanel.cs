using BlueGravity.World;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI
{
    public class GamePlayPanel : Panel
    {
        [SerializeField] Player Player;
        [SerializeField] TextMeshProUGUI CoinsValue;
        [SerializeField] Button InventoryButton;
        [SerializeField] Button HideInventoryButton;
        [SerializeField] Inventory InventoryPanel;
        
        void Awake()
        {
            InventoryButton.gameObject.SetActive( true );
            HideInventoryButton.gameObject.SetActive( false );
            InventoryButton.onClick.AddListener( ShowInventory );
            HideInventoryButton.onClick.AddListener( HideInventory );
            UpdateCoinsValue();
        }

        public void UpdateCoinsValue()
        {
            CoinsValue.text = Player.Coins.ToString();
        }

        void ShowInventory()
        {
            InventoryPanel.gameObject.SetActive( true );
            InventoryPanel.GetComponentInChildren<Inventory>().Show();
            InventoryButton.gameObject.SetActive( false );
            HideInventoryButton.gameObject.SetActive( true );
        }

        void HideInventory()
        {
            InventoryPanel.gameObject.SetActive( false );
            InventoryPanel.GetComponentInChildren<Inventory>().Hide();
            InventoryButton.gameObject.SetActive( true );
            HideInventoryButton.gameObject.SetActive( false );
        }
    }
}

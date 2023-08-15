using BlueGravity.UI;
using BlueGravity.World;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryEntry : Panel
{
    public Item Item;
    [SerializeField] Image EntryItemImage;
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] GameObject Root;

    public override void Show()
    {
        EntryItemImage.sprite = Item.ItemSprite;
        ItemName.text = Item.Name;
        Root.SetActive( true );
    }
    
    public override void Hide()
    {
        Root.SetActive( false );
    }
}

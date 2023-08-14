namespace BlueGravity.World
{
    public class CollectableItem : Item, IInteractable
    {
        public void Interact()
        {
            Player.Instance.Inventory.Add( this );
        }
    }
}

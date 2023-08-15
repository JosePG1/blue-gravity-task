using BlueGravity.World;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI
{
    public class Inventory : Panel
    {
        [SerializeField] ItemInventoryEntry InventoryTemplate;
        [SerializeField] Transform Root;

        void OnEnable()
        {
            foreach ( var item in Player.Instance.Inventory )
            {
                var entry = Instantiate( InventoryTemplate, Root ).GetComponent<ItemInventoryEntry>();
                entry.Item = item;
                entry.Show();
            }
        }

        public void OnDisable()
        {
            foreach ( Transform child in Root )
            {
                var le = child.GetComponent<LayoutElement>();
                if ( le != null )
                {
                    Destroy( le );
                }
                Destroy( child.gameObject );
            }
        }

        public void Refresh()
        {
            if ( gameObject.activeSelf )
            {
                OnDisable();
                OnEnable();
            }
        }
    }
}

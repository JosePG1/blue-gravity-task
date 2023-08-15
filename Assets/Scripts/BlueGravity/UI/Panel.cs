using UnityEngine;

namespace BlueGravity.UI
{
    public class Panel : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive( !gameObject.activeSelf );
        }
        
        public void Show()
        {
            // TODO: Use animator and fancy animation instead
        }
    
        public void Hide()
        {
            gameObject.SetActive( false );
        }
    }
}

using UnityEngine;

namespace BlueGravity.UI
{
    public class UIElement : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive( !gameObject.activeSelf );
        }
        
        public virtual void Show()
        {
            gameObject.SetActive( true );
        }
    
        public virtual void Hide()
        {
            gameObject.SetActive( false );
        }
    }
}

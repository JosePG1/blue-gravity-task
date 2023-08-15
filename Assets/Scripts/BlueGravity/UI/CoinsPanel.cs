using BlueGravity.World;
using TMPro;
using UnityEngine;

namespace BlueGravity.UI
{
    public class CoinsPanel : Panel
    {
        [SerializeField] Player Player;
        [SerializeField] TextMeshProUGUI CoinsValue;

        void Awake()
        {
            UpdateCoinsValue();
        }

        void UpdateCoinsValue()
        {
            CoinsValue.text = Player.Coins.ToString();

        }
    }
}

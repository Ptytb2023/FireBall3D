using UnityEngine;
using TMPro;

namespace Menu.Levels
{
    public class MenuLevelPlatfrom : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _levelNumber;
        [field: SerializeField] public Transform MarketHolder { get; private set; }


        public void PaintNumber(Color color)
        {
            _levelNumber.color = color;
        }
    }
}

using TMPro;
using UnityEngine;

namespace UI.Towers
{
    public class TowerSegmentsCountLeftText : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _text;

        public void UpdateTextValue(int segmentCount)
        {
            _text.text = segmentCount.ToString();
        }
    }
}

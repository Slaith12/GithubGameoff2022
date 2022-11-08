using TMPro;
using UnityEngine;

namespace Utilities
{
    public class CopyTMPText : MonoBehaviour
    {
        public TextMeshProUGUI source;
        private TextMeshProUGUI mine;

        private void Start()
        {
            mine = GetComponent<TextMeshProUGUI>();
        }

        private void LateUpdate()
        {
            mine.text = source.text;
        }
    }
}
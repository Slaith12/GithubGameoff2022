using TMPro;
using UnityEngine;

namespace Utilities
{
    public class CopyTMPText : MonoBehaviour
    {
        public TextMeshProUGUI source;
        private TextMeshProUGUI _mine;

        private void Start()
        {
            _mine = GetComponent<TextMeshProUGUI>();
        }

        private void LateUpdate()
        {
            _mine.text = source.text;
        }
    }
}
using System;
using UnityEngine;

namespace Utilities
{
    public class FixedAspect : MonoBehaviour
    {
        public float aspX = 1;
        public float aspY = 1;

        private enum AspectMode { Width, Height }
        [SerializeField] private AspectMode sourcing = AspectMode.Width;

        private void Update()
        {
            Vector3 localScale;
            var rt = (RectTransform) transform;
            switch (sourcing)
            {
                case AspectMode.Height:
                    var y = rt.rect.height;
                    rt.sizeDelta = new Vector2(y, 0);
                    break;
                case AspectMode.Width:
                    var x = rt.rect.width;
                    rt.sizeDelta = new Vector2(0, x);
                    break;
                default: throw new NotImplementedException();
            }
        }
    }
}
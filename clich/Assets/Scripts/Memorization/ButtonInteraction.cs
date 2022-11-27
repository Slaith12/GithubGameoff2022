using System;
using UnityEngine;
using UnityEngine.U2D;

namespace Memorization
{
    public class ButtonInteraction : MonoBehaviour
    {
        public MemorizationController.Button buttonType;
        public KeyCode keyCode;
        
        private SpriteRenderer _mySpriteRenderer;
        private SpriteShapeRenderer _mySpriteShapeRenderer;
        private Color _original;
        private Vector3 _originalScale;
        private Vector3 TargetScale
        {
            get
            {
                return (_parent.IsMemorize, hovered, pressed) switch
                {
                    (true, _, _) => _originalScale,
                    (_, _, true) => _originalScale * 0.9f,
                    (_, true, false) => _originalScale * 1.1f,
                    _ => _originalScale
                };
            }
        }

        [HideInInspector] public bool hovered;
        [HideInInspector] public bool pressed;
        private MemorizationController _parent;

        private void Start()
        {
            _originalScale = transform.localScale;
            
            _mySpriteRenderer = GetComponent<SpriteRenderer>();
            _mySpriteShapeRenderer = GetComponent<SpriteShapeRenderer>();
            if (_mySpriteRenderer)
            {
                _original = _mySpriteRenderer.color;
            }
            else if (_mySpriteShapeRenderer)
            {
                _original = _mySpriteShapeRenderer.color;
            }
            var test = transform.parent;
            _parent = test.GetComponent<MemorizationController>();
            var i = 1;
            while (!_parent)
            {
                i++;
                test = test.parent;
                _parent = test.GetComponent<MemorizationController>();
            }
            Debug.Log("up " + i + " levels to find parent");
        }

        private void Update()
        {
            const float z = 5;
            const float z2 = 15;
            if (_mySpriteRenderer)
            {
                _mySpriteRenderer.color = Color.Lerp(_mySpriteRenderer.color, _original, Time.deltaTime * z);
            }
            else if (_mySpriteShapeRenderer)
            {
                _mySpriteShapeRenderer.color = Color.Lerp(_mySpriteShapeRenderer.color, _original, Time.deltaTime * z);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, Time.deltaTime * z2);

            if ((Input.GetMouseButtonDown(0) && hovered) || Input.GetKeyDown(keyCode))
            {
                _parent.ClickEventHandler(gameObject, this);
            }

            pressed = Input.GetMouseButton(0) && hovered;
        }

        private void OnMouseEnter()
        {
            hovered = true;
        }

        private void OnMouseExit()
        {
            hovered = false;
        }
    }
    
}
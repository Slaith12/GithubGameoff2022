using System;
using UnityEngine;
using UnityEngine.U2D;

namespace Memorization
{
    public class ButtonPulse : MonoBehaviour
    {
        private SpriteRenderer _mySpriteRenderer;
        private SpriteShapeRenderer _mySpriteShapeRenderer;
        private Color _original;
        private Vector3 _originalScale;

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
        }

        private void Update()
        {
            const float z = 5;
            if (_mySpriteRenderer)
            {
                _mySpriteRenderer.color = Color.Lerp(_mySpriteRenderer.color, _original, Time.deltaTime * z);
            }
            else if (_mySpriteShapeRenderer)
            {
                _mySpriteShapeRenderer.color = Color.Lerp(_mySpriteShapeRenderer.color, _original, Time.deltaTime * z);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, _originalScale, Time.deltaTime * z);
        }
    }
    
}
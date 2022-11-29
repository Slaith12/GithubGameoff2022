using System;
using UnityEngine;

public class CrtScroll : MonoBehaviour
{
    private TileCrt _parent;
    public float speed;
    private bool _active;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = (RectTransform)transform;
        float width = ((RectTransform)transform.parent).sizeDelta.x;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        var test = transform.parent;
        _parent = test.GetComponent<TileCrt>();
        var i = 1;
        while (!_parent)
        {
            i++;
            test = test.parent;
            _parent = test.GetComponent<TileCrt>();
        }
        //Debug.Log("up " + i + " levels to find parent");
    }

    public void Activate()
    {
        _active = true;
    }

    public void Tick(float dt)
    {
        if (!_active) return;
        transform.Translate(0, speed * dt, 0);
        var location = rectTransform.anchoredPosition;
        if (location.y <= _parent.minY)
        {
            location.y += _parent.maxY - _parent.minY;
            rectTransform.anchoredPosition = location;
        }
    }
}
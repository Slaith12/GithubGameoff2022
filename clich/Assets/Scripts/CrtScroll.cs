using System;
using UnityEngine;

public class CrtScroll : MonoBehaviour
{
    private TileCrt _parent;
    public float speed;
    private bool _active;

    private void Start()
    {
        _parent = transform.parent.GetComponent<TileCrt>();
    }

    private void Update()
    {
        if (!_active) return;
        transform.Translate(0, 1, 0);
        var location = transform.position;
        if (location.y > _parent.maxY)
        {
            Debug.Log(_parent.maxY + " " + location.y);
            transform.position = new Vector2(location.x, _parent.minY);
        }
    }

    public void Activate()
    {
        _active = true;
    }
}
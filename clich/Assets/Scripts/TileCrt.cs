using System.Collections.Generic;
using UnityEngine;

public class TileCrt : MonoBehaviour
{
    public GameObject prefab;
    public float minY;
    public float maxY;

    public float density;
    public int count;

    public GameObject container;
    
    private int _delay = 2;

    private IList<CrtScroll> _tiles = new List<CrtScroll>();
    
    private void Start()
    {
        var h = maxY-minY;
        count = (int) (density * h);
        
        var step = (maxY - minY) / count;
        Debug.Log(count);
        for (var i = 0; i < count; i++)
        {
            var y = minY + step * (i + 0.5f);
            var go = Instantiate(prefab, transform);
            go.transform.SetParent(container.transform);
            go.transform.localPosition = new Vector3(0, y, 0);
            _tiles.Add(go.GetComponent<CrtScroll>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        _delay--;
        if (_delay == 0)
        {
            foreach (var tile in _tiles)
            {
                tile.Activate();
            }
        }

        var dt = Time.deltaTime;
        foreach (var crtScroll in _tiles)
        {
            crtScroll.Tick(dt);
        }
    }
}
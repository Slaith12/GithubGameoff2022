using System.Collections.Generic;
using UnityEngine;

public class TileCrt : MonoBehaviour
{
    public GameObject prefab;
    public float minY;
    public float maxY;

    public int count;

    private IList<GameObject> _tiles = new List<GameObject>();
    
    private void Start()
    {
        var step = (maxY - minY) / count;
        Debug.Log(count);
        for (var i = 0; i < count; i++)
        {
            var y = minY + step * i;
            var go = Instantiate(prefab, transform);
            go.transform.localPosition = new Vector3(0, y, 0);
            go.GetComponent<CrtScroll>().Activate();
            _tiles.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
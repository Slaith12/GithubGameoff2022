using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;

        Collider2D col = Physics2D.OverlapPoint(mousePos);

        if (Input.GetMouseButtonDown(0) && col)
        {
            if (col.transform.gameObject.tag == "clickable")
            {
                Destroy(col.transform.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGrab : MonoBehaviour
{
    private GameObject selectedObject;

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
            if(col.transform.gameObject.tag == "grabbable")
            {
                selectedObject = col.transform.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }

        if (selectedObject && Input.GetMouseButton(0)) 
        {
            selectedObject.transform.position = new Vector2(mousePos.x, mousePos.y);
            if (selectedObject.GetComponent<Rigidbody2D>() != null)
            {
                selectedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        

    }

}

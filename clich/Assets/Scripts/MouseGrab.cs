using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGrab : MonoBehaviour
{
    public Transform mousePos;
    public GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;

        Collider2D col = Physics2D.OverlapPoint(mousePos);
        
        if (Input.GetMouseButtonDown(0) && col) 
        {
            selectedObject = col.transform.gameObject;
            
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }

        if (selectedObject && Input.GetMouseButton(0)) 
        {
            selectedObject.transform.position = new Vector2(mousePos.x, mousePos.y);
        }
        

    }

}

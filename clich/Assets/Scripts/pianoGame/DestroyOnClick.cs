using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] Rigidbody2D piano;
    new Collider2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        piano.bodyType = RigidbodyType2D.Kinematic;
        rigidbody = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (rigidbody.OverlapPoint(clickPos))
            {
                piano.bodyType = RigidbodyType2D.Dynamic;
                gameObject.SetActive(false);
            }
        }
    }
}

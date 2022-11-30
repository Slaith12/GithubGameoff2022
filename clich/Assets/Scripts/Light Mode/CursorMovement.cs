using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    private float speed;
    [SerializeField] private Rigidbody2D rb;
    private LightModeMinigame lm;

    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        speed = Random.Range(0.3f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x, y) * speed * -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFishMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    public float speed = 10f;


    private float spawnX;
    private float targetX;
    private float spawnY;
    private float targetY;

    private float dist;
    private float nextX;
    private float nextY;
    private float distX;
    private float distY;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        spawnX = transform.position.x;
        spawnY = transform.position.y;
        rb = this.GetComponent<Rigidbody2D>();

     

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction; 

    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime)); 
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BFish"))
        {
            Destroy(gameObject);
        }
        
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFishMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    public float speed = 10f;
    public float minDist = 2f;


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
    private Vector2 startPos;
    private Vector2 targetPos;
    private Vector2 movement;
    private bool moving;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        startPos = transform.position;
        targetPos = startPos;
        rb = this.GetComponent<Rigidbody2D>();
        moving = false;



    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = targetPos - (Vector2)transform.position;
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
        dist = Vector2.Distance(targetPos, transform.position);

        if (dist < 0.1f)
        {
            targetPos = startPos;
            moving = false;
        }
        if ((Vector2)transform.position == startPos && dist >= minDist)
        {
            targetPos = startPos;
            moving = false;
        }
        if ((Vector2)transform.position == startPos && dist < minDist && !moving)
        {
            targetPos = target.transform.position;
            moving = true;
        }

        
         moveCharacter(movement);
        
        
    }
    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
    
}
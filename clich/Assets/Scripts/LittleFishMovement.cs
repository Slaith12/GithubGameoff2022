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
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");


     

    }

    // Update is called once per frame
    void Update()
    {

        targetX = target.transform.position.x;
        targetY = target.transform.position.y;

        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        nextY = Mathf.MoveTowards(transform.position.y, targetY, speed * Time.deltaTime);

        Vector3 movePosition = new Vector3(nextX, nextY, transform.position.z);
        transform.position = movePosition;

        if (transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}
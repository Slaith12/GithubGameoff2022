using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Vector2 targetPoint;
    LightModeMinigame minigame => LightModeMinigame.minigame;
    private Vector2 moveVector;
    

    // Start is called before the first frame update
    void Start()
    {
        moveVector = (targetPoint - (Vector2)transform.position).normalized * speed;
        Debug.Log(moveVector);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (minigame.started)
            rb.velocity = moveVector;
        else
            rb.velocity = Vector2.zero;
    }
}

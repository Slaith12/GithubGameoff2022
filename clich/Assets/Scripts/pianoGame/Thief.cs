using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    public static int lives = 3;
    public static int score = 0;

    public static bool lost = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        lost = lives <= 0;
        if (lost)
            Debug.Log("lost");
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("piano")) 
        {
            score++;
            PianoMinigame.minigame.EndMinigame(true);
            gameObject.SetActive(false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mary")) 
        {
            PianoMinigame.minigame.EndMinigame(false);
        }
    }


}

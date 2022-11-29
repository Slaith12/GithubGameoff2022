using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawner : MonoBehaviour
{

    [SerializeField] Minigame minigame;
    [SerializeField] GameObject fan;
    private bool readyForNext = true;
    [SerializeField] BoxCollider2D fanCollider;
    private bool isColliding = true;

    private int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!minigame.started)
            return;

        if(readyForNext == true && counter < 7)
        {
            counter++;
            if(counter < 7)
            {
                Instantiate(fan, gameObject.transform);
            }
            readyForNext = false;
            
            Debug.Log(counter);
        }

        if(!isColliding && Input.GetMouseButtonUp(0))
        {
            readyForNext = true;
        }
    }

    public void setIsColliding(bool tf)
    {
        if(tf)
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    public int getCounter()
    {
        return counter;
    }
}

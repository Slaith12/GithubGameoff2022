using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawner : MonoBehaviour
{

    [SerializeField] Minigame minigame;
    [SerializeField] GameObject fan;
    private bool readyForNext = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!minigame.started)
            return;
        if(readyForNext == true)
        {
            //Instantiate(fan, )
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject g;
    void Start()
    {
        InvokeRepeating("SpawnThieves",1f,1.6f);
    }

    public void SpawnThieves() 
    {
        Instantiate(g);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnCollision : MonoBehaviour
{
    [SerializeField] Collider2D colliderToCheck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == colliderToCheck)
        {
            gameObject.SetActive(false);
        }
    }
}

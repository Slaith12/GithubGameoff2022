using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCollision : MonoBehaviour
{
    [SerializeField] private VendingController yes;

    void OnTriggerEnter2D(Collider2D collision)
    {
        yes.hitGround();
    }
}

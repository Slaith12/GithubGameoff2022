using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanCollideCheck : MonoBehaviour
{
    [SerializeField] private FanSpawner yes;

    void OnTriggerStay2D(Collider2D collision)
    {
        yes.setIsColliding(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        yes.setIsColliding(false);
    }

}

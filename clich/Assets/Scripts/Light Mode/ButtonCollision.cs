using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    [SerializeField] private LightModeMinigame lm;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "clickable")
        {
            lm.buttonClicked();
        }
    }
}

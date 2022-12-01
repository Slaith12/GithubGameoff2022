using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vendthingy : MonoBehaviour
{
    [SerializeField] private Minigame mi;

    void OnLedgeAnimationEnd()
    {
        mi.EndMinigame(true);
    }
}

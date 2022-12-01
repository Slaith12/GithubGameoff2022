using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vendthingy : MonoBehaviour
{
    [SerializeField] private Minigame mi;

    void OnLedgeAnimationEndWin()
    {
        mi.EndMinigame(true);
    }

    void OnLedgeAnimationEndEnd()
    {
        mi.EndMinigame(false);
    }
}

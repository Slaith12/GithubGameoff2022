using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [HideInInspector] public bool started = false;
    public abstract void StartMinigame(); //this is here so if we want to have the game start a bit after the transition we can do that, please use this instead of Start()

    public abstract string GetInstructionSnippet();

    protected void EndMinigame(bool isWin)
    {
        GameManager.gameManager.EndCurrentMinigame(isWin);
    }
}

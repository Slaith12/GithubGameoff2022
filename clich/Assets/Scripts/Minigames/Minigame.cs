using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [HideInInspector] public bool started = false;
    public abstract void StartMinigame();

    protected void EndMinigame()
    {
        GameManager.gameManager.EndMinigame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMinigame : Minigame
{
    [SerializeField] float maxTime = 5;
    float timer;
    [SerializeField] MouseGrab mouseGrab;

    private void Start()
    {
        mouseGrab.enabled = false;
    }

    public override void StartMinigame()
    {
        started = true;
        mouseGrab.enabled = true;
        timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);
    }

    private void Update()
    {
        if (!started)
            return;
        timer -= Time.deltaTime;
        GameManager.gameManager.SetTimerPercentage(timer / maxTime);
        if (timer <= 0)
            EndMinigame(false);
    }

    public override string GetInstructionSnippet()
    {
        return "Don't Let It Burn!";
    }
}

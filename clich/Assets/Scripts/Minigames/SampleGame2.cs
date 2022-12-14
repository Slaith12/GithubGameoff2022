using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGame2 : Minigame
{
    [SerializeField] float maxTime = 5;
    private float timer;

    public override void StartMinigame()
    {
        started = true;
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
        {
            EndMinigame(true);
        }
    }

    public override string GetInstructionSnippet()
    {
        return "Move Around";
    }
}

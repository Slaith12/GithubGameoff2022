using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PianoMinigame : Minigame
{
    // Start is called before the first frame update

    [SerializeField] float maxTime = 10;
    private Animator endingAnimator;
    private float timer;
    private int count;

    private void Awake()
    {
        
        endingAnimator = GetComponent<Animator>();
    }

    public override void StartMinigame()
    {
        started = true;
        count = 0;
        timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);
    }

    void Update()
    {
        if (!started)
            return;

        timer -= Time.deltaTime;
        GameManager.gameManager.SetTimerPercentage(timer / maxTime);
        if (timer <= 0)
        {
            started = false;
            if (count >= 5)
            {
                endingAnimator.SetTrigger("Win");
            }
            else
            {
                endingAnimator.SetTrigger("Lose");
            }
            return;
        }
    }

    public override string GetInstructionSnippet()
    {
        return "Stop the bad guys!";
    }
}

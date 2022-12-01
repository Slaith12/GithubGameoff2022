using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PianoMinigame : Minigame
{
    // Start is called before the first frame update

    [SerializeField] TMP_Text text;
    [SerializeField] float maxTime = 5;
    private Animator endingAnimator;
    private float timer;
    private int count;

    private void Awake()
    {
        text.text = "Raining pianos";
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
                text.SetText("Bad guys defeated!");
            }
            else
            {
                endingAnimator.SetTrigger("Lose");
                text.SetText("You've been robbed :(");
            }
            return;
        }

        text.SetText($"Robbers stopped: {Thief.score}");
    }

    public override string GetInstructionSnippet()
    {
        return "Stop the bad guys by dropping a piano on their head!";
    }
}

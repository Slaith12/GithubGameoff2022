using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SampleGame1 : Minigame
{
    [SerializeField] TMP_Text text;
    [SerializeField] float maxTime = 5;
    private Animator endingAnimator;
    private float timer;
    private int count;

    private void Awake()
    {
        text.text = "Minigame not started yet";
        endingAnimator = GetComponent<Animator>();
    }

    public override void StartMinigame()
    {
        started = true;
        count = 0;
        timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
            return;

        timer -= Time.deltaTime;
        GameManager.gameManager.SetTimerPercentage(timer / maxTime);
        if(timer <= 0)
        {
            started = false;
            if (count >= 5)
            {
                endingAnimator.SetTrigger("Win");
                text.SetText("Minigame-specific win animation");
            }
            else
            {
                endingAnimator.SetTrigger("Lose");
                text.SetText("Minigame-specific lose animation");
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            count++;
        text.SetText($"You pressed space {count} times since the start of the minigame!");
    }

    public override string GetInstructionSnippet()
    {
        return "This is a very long title!";
    }
}

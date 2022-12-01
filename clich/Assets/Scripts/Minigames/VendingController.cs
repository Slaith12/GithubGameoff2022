using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingController : Minigame
{
    [SerializeField] float maxTime = 15;
    private float timer;
    private bool checking = false;

    [SerializeField] private MouseGrab mg;
    [SerializeField] private FanSpawner fs;

    private bool quit = false;
    [SerializeField] private Animator endingAnimator;

    [SerializeField] GameObject vend;
    [SerializeField] GameObject mary;

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
        if(!checking)
        {
            timer -= Time.deltaTime;
            GameManager.gameManager.SetTimerPercentage(timer / maxTime);
        }
        if (timer <= 0)
        {
            StartCoroutine(Fall());
            endingAnimator.SetTrigger("win");
            EndMinigame(false);
        }
        if(fs.getCounter() == 7 && mg.getSelectedObject() == null)
        {
            StartCoroutine(Check());
            quit = false;
        }
        else
        {
            quit = true;
        }

    }

    public override string GetInstructionSnippet()
    {
        return "Stack 6 Fans";
    }

    public void hitGround()
    {
        StartCoroutine(Fall());
        endingAnimator.SetTrigger("win");
        EndMinigame(false);
    }

    IEnumerator Check()
    {
        checking = true;

        float counter = 3;
        float waitTime = 0;
        while (counter > waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter -= Time.deltaTime;
            //Wait for a frame so that Unity doesn't freeze
            //Check if we want to quit this function
            if (quit)
            {
                checking = false;
                //Quit function
                yield break;
            }
            yield return null;
        }
        endingAnimator.SetTrigger("win");
        EndMinigame(true);
    }

    IEnumerator Fall()
    {

    }
}

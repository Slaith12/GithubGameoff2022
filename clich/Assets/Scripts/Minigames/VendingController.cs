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

    [SerializeField] Rigidbody2D vendRB;

    public override void StartMinigame()
    {
        started = true;
        timer = maxTime;
        vendRB.bodyType = RigidbodyType2D.Kinematic;
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
            Lose();
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
        Lose();
    }

    void Lose()
    {
        started = false;
        endingAnimator.SetTrigger("lose");
        vendRB.bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator Check()
    {
        checking = true;

        float timer = 2;
        while (timer > 0)
        {
            //Increment Timer until counter >= waitTime
            timer -= Time.deltaTime;
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
        started = false;
        endingAnimator.SetTrigger("win");
    }
}

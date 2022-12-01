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

    [SerializeField] BoxCollider2D vend;
    [SerializeField] Rigidbody2D vend2;
    [SerializeField] GameObject mary;
    [SerializeField] BoxCollider2D ledge;

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
            started = false;
            endingAnimator.SetTrigger("lose");
            vend.enabled = true;
            ledge.enabled = true;
            vend2.gravityScale = 1;
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
        started = false;
        endingAnimator.SetTrigger("lose");
        vend.enabled = true;
        ledge.enabled = true;
        vend2.gravityScale = 1;
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
        started = false;
        endingAnimator.SetTrigger("win");
    }
}

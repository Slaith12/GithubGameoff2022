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
            EndMinigame(false);
        }
        if(fs.getCounter() == 7 && mg.getSelectedObject() == null)
        {
            StartCoroutine(Check());

        }

    }

    public override string GetInstructionSnippet()
    {
        return "Stack the Fans";
    }

    public void hitGround()
    {
        EndMinigame(false);
    }

    IEnumerator Check()
    {
        checking = true;
        yield return new WaitForSeconds(3);
        EndMinigame(true);
    }
}

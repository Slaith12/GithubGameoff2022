using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModeMinigame : Minigame
{
    [SerializeField] float maxTime = 10;
    private float timer;

    [SerializeField] private GameObject cursor;

    private GameObject newObj;
    private Coroutine spawnRoutine;

    public override void StartMinigame()
    {
        started = true;
        timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);

        spawnRoutine = StartCoroutine(spawn());
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
        return "Stop from using Light Mode!";
    }

    IEnumerator spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0.9f, 1.1f));
            int side = Random.Range(1, 4);
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            GameObject newObj;
            if(side == 1)
            {
                newObj = Instantiate(cursor, new Vector2(-4, Random.Range(-4, 4)), rot);
                newObj.transform.SetParent(gameObject.transform);
            }
            else if(side == 2)
            {
                newObj = Instantiate(cursor, new Vector2(4, Random.Range(-4, 4)), rot);
                newObj.transform.SetParent(gameObject.transform);
            }
            else
            {
                newObj = Instantiate(cursor, new Vector2(Random.Range(-4, 4), 4), rot);
                newObj.transform.SetParent(gameObject.transform);
            }
        }
    }

    public void buttonClicked()
    {
        EndMinigame(false);
    }

    public override void EndMinigame(bool isWin)
    {
        StopCoroutine(spawnRoutine);
        base.EndMinigame(isWin);
    }
}

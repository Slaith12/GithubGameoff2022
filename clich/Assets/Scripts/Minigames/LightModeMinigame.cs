using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModeMinigame : Minigame
{
    [SerializeField] float maxTime = 10;
    private float timer;

    [SerializeField] private GameObject cursor;

    private GameObject newObj;

    public override void StartMinigame()
    {
        started = true;
        timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);

        StartCoroutine(spawn());
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
            yield return new WaitForSeconds(Random.Range(0.4f, 1.0f));
            int side = (int)Random.Range(1, 5);
            Quaternion rot = Quaternion.Euler(0, 0, 0);
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
            else if(side == 3)
            {
                newObj = Instantiate(cursor, new Vector2(Random.Range(-4, 4), -4), rot);
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
}

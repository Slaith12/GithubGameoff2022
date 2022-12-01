using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModeMinigame : Minigame
{
    public static LightModeMinigame minigame { get; private set; }

    [SerializeField] float maxTime = 10;
    private float timer;

    [SerializeField] private GameObject cursor;

    private List<GameObject> cursors;
    private Coroutine spawnRoutine;
    private Animator animator;

    public override void StartMinigame()
    {
        minigame = this;
        animator = GetComponent<Animator>();
        animator.SetTrigger("Start");
    }

    public void Begin()
    {
        started = true;
        timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);
        cursors = new List<GameObject>();

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
            PlayEnding(true);
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
            int side = Random.Range(1, 4);
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            GameObject newObj;
            if(side == 1)
            {
                newObj = Instantiate(cursor, new Vector2(-5, Random.Range(-4, 4)), rot);
                newObj.transform.SetParent(gameObject.transform);
            }
            else if(side == 2)
            {
                newObj = Instantiate(cursor, new Vector2(5, Random.Range(-2, 4)), rot);
                newObj.transform.SetParent(gameObject.transform);
            }
            else
            {
                newObj = Instantiate(cursor, new Vector2(Random.Range(-2, 4), 5), rot);
                newObj.transform.SetParent(gameObject.transform);
            }
            cursors.Insert(0, newObj);
            yield return new WaitForSeconds(Random.Range(0.6f, 0.8f));
        }
    }

    IEnumerator ClearCursors()
    {
        foreach(GameObject cursor in cursors)
        {
            yield return new WaitForSeconds(0.05f);
            Destroy(cursor);
        }
    }

    public void buttonClicked()
    {
        PlayEnding(false);
    }

    public void PlayEnding(bool isWin)
    {
        started = false;
        StopCoroutine(spawnRoutine);
        StartCoroutine(ClearCursors());
        if (isWin)
            animator.SetTrigger("Win");
        else
            animator.SetTrigger("Lose");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    private Animator transitionAnimator;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text failText;
    [SerializeField] TMP_Text failLimit;
    [SerializeField] TimerManager timer;

    [SerializeField] Minigame titleScreen;
    [SerializeField] Minigame[] minigames;
    public int forceMinigame = -1;
    private Minigame currentMinigame;
    private int currentIndex;
    private bool wasWin;
    private bool active;
    private int fails;

    void Start()
    {
        gameManager = this;
        transitionAnimator = GetComponent<Animator>();
        currentIndex = -1;
        active = false;
        failText.SetText("");
        LoadMinigame(-1);
    }

    private void SetupSession()
    {
        fails = 0;
        failText.SetText("0");
        failLimit.SetText("3");
    }

    public void SetTimerPercentage(float percentage)
    {
        timer.SetBarWidth(percentage);
    }

    public void LoadMinigame(int index)
    {
        UnloadMinigame();
        GameObject newMinigame;
        if (index == -1)
        {
            newMinigame = titleScreen.gameObject;
            failText.SetText("N");
            failLimit.SetText("A");
        }
        else
            newMinigame = minigames[index].gameObject;
        GameObject minigameObject = Instantiate(newMinigame);
        currentMinigame = minigameObject.GetComponent<Minigame>();
        levelText.text = currentMinigame.GetInstructionSnippet();
        currentIndex = index;
    }

    //called by transition animator
    public void StartMinigame()
    {
        if (currentMinigame == null)
            return;
        currentMinigame.StartMinigame();
        active = true;
    }

    //called by minigame when finished
    public void EndCurrentMinigame(bool isWin)
    {
        if (!active)
            return;
        transitionAnimator.SetTrigger("End");
        //transitionAnimator.Play("End Minigame"); //the animator thinks the parameters don't exist so this is the next best thing
        wasWin = isWin;
        active = false;
        if (!isWin)
        {
            fails++;
            failText.SetText(fails.ToString());
        }
    }

    public void LoadFeedbackMessage()
    {
        if (currentIndex == -1)
            levelText.text = "";
        else if (wasWin)
            levelText.text = "Good Job!";
        else
            levelText.text = "Oh No!";
    }

    public void UnloadMinigame()
    {
        if (currentMinigame == null)
            return;
        Destroy(currentMinigame.gameObject);
        currentMinigame = null;
    }

    //Testing Function
    public void JumpToMinigame(int index)
    {
        LoadMinigame(index);
        StartMinigame();
    }

    //called by transition animator
    public void GoToNextMinigame()
    {
        if (currentIndex == -1)
            SetupSession();
        LoadMinigame(GetNewMinigameID());
        transitionAnimator.SetTrigger("Start");
        //transitionAnimator.Play("Start Minigame"); //the animator thinks the parameters don't exist so this is the next best thing
    }

    private int GetNewMinigameID()
    {
        if (fails >= 3)
            return -1;
        if (forceMinigame != -1)
            return forceMinigame;
        int newIndex;
        do
        {
            newIndex = Random.Range(0, minigames.Length);
        } while (newIndex == currentIndex && minigames.Length > 1);
        return newIndex;
    }
}

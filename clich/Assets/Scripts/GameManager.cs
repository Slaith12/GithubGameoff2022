using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    private Animator transitionAnimator;
    [SerializeField] TMP_Text levelText;

    [SerializeField] Minigame[] minigames;
    public int forceMinigame = -1;
    private Minigame currentMinigame;
    private int currentIndex;
    private bool wasWin;

    void Start()
    {
        gameManager = this;
        transitionAnimator = GetComponent<Animator>();
        currentIndex = -1;
        LoadMinigame(GetNewMinigameID());
    }

    public void LoadMinigame(int index)
    {
        UnloadMinigame();
        GameObject minigameObject = Instantiate(minigames[index].gameObject);
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
    }

    //called by minigame when finished
    public void EndCurrentMinigame(bool isWin)
    {
        //transitionAnimator.SetBool(1, true); //end
        transitionAnimator.Play("End Minigame"); //the animator thinks the parameters don't exist so this is the next best thing
        wasWin = isWin;
    }

    public void LoadFeedbackMessage()
    {
        if (wasWin)
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
        LoadMinigame(GetNewMinigameID());
        //transitionAnimator.SetBool(0, true); //start
        transitionAnimator.Play("Start Minigame"); //the animator thinks the parameters don't exist so this is the next best thing
    }

    private int GetNewMinigameID()
    {
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

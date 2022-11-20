using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    [SerializeField] Minigame[] minigames;
    public int forceMinigame = -1;
    private Minigame currentMinigame;
    private int currentIndex;

    void Start()
    {
        gameManager = this;
        currentIndex = -1;
        EndMinigame();
    }

    public void LoadMinigame(int index)
    {
        UnloadMinigame();
        GameObject minigameObject = Instantiate(minigames[index].gameObject);
        currentMinigame = minigameObject.GetComponent<Minigame>();
        currentIndex = index;
    }

    public void StartMinigame()
    {
        if (currentMinigame == null)
            return;
        currentMinigame.StartMinigame();
    }

    public void EndMinigame()
    {
        int newIndex;
        if (forceMinigame == -1)
        {
            do
            {
                newIndex = Random.Range(0, minigames.Length);
            } while (newIndex == currentIndex && minigames.Length > 1);
        }
        else
        {
            newIndex = forceMinigame;
        }
        JumpToMinigame(newIndex);
    }

    public void UnloadMinigame()
    {
        if (currentMinigame == null)
            return;
        Destroy(currentMinigame.gameObject);
        currentMinigame = null;
    }

    public void JumpToMinigame(int index)
    {
        LoadMinigame(index);
        StartMinigame();
    }
}

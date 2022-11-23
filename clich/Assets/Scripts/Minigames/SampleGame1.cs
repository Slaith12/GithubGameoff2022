using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SampleGame1 : Minigame
{
    [SerializeField] TMP_Text text;
    private int count;

    private void Awake()
    {
        text.text = "Minigame not started yet";
    }

    public override void StartMinigame()
    {
        started = true;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
            count++;
        text.SetText($"You pressed space {count} times since the start of the minigame!");
    }

    public override string GetInstructionSnippet()
    {
        return "Press Space";
    }
}
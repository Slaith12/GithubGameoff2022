using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SampleGame1 : Minigame
{
    [SerializeField] TMP_Text text;
    private int count;

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
        Debug.Log(count);
        text.SetText($"You pressed space {count} times since the start of the minigame!");
    }
}

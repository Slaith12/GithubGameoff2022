using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : Minigame
{
    public override string GetInstructionSnippet()
    {
        return "";
    }

    public override void StartMinigame()
    {
        started = true;
    }

    private void Update()
    {
        if (!started)
            return;
        if (Input.anyKeyDown)
            EndMinigame(true);
    }
}

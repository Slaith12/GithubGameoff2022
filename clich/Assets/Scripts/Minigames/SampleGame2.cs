using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGame2 : Minigame
{
    public override void StartMinigame()
    {
        started = true;
    }

    public override string GetInstructionSnippet()
    {
        return "Move Around";
    }
}

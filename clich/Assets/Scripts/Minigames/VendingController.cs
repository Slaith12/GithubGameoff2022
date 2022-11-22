using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingController : Minigame
{

    public override void StartMinigame()
    {
        started = true;
    }

    public override string GetInstructionSnippet()
    {
        return "Stack the Fans";
    }
}

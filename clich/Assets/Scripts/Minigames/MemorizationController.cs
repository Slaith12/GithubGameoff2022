using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MemorizationController : Minigame
{
    // D flat
    
    [SerializeField] private float maxTime = 5;
    private float _timer;

    private static int _beginCount;
    
    public SpriteRenderer buttonDiamond;
    public SpriteRenderer buttonSquare;
    public SpriteRenderer buttonCircle;
    public SpriteShapeRenderer buttonTriangle;
    
    private enum Button {Diamond, Square, Circle, Triangle};
    private static readonly List<Button> _buttons = new List<Button>();

    public override void StartMinigame()
    {
        started = true;
        _timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);
        _beginCount++;

        if (_beginCount % 2 == 1)
        {
            _buttons.Clear();
            InvokeRepeating(nameof(PulseAdd), 0, 0.5f);
        }
    }

    private void Pulse()
    {
        buttonDiamond.color = Color.white;
        buttonSquare.color = Color.white;
        buttonCircle.color = Color.white;
        buttonTriangle.color = Color.white;
    }

    private void PulseAdd()
    {
        Pulse();
        var toAdd = (Button) Random.Range(0, 4);
        switch (toAdd)
        {
            case Button.Diamond:
                buttonDiamond.color = Color.red;
                buttonDiamond.transform.localScale *= .8f;
                break;
            case Button.Square:
                buttonSquare.color = Color.green;
                buttonSquare.transform.localScale *= .8f;
                break;
            case Button.Circle:
                buttonCircle.color = Color.blue;
                buttonCircle.transform.localScale *= .8f;
                break;
            case Button.Triangle:
                buttonTriangle.color = Color.yellow;
                buttonTriangle.transform.localScale *= .8f;
                break;
        } 
    }

    public override void EndMinigame(bool isWin)
    {
        CancelInvoke(nameof(Pulse));
        base.EndMinigame(isWin);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
            return;

        _timer -= Time.deltaTime;
        GameManager.gameManager.SetTimerPercentage(_timer / maxTime);
        if(_timer <= 0)
        {
            started = false;
            EndMinigame(true);
        }
    }

    public override string GetInstructionSnippet()
    {
        return _beginCount % 2 == 0 ? "Recall!" : "Memorize!";
    }
}

using System;
using System.Collections.Generic;
using Memorization;
using UnityEngine;
using UnityEngine.U2D;
using Utilities;
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

    public ArrayContainer lightArray;
    
    public enum Button {Diamond, Square, Circle, Triangle};
    private static readonly List<Button> _buttons = new List<Button>();
    private static readonly List<Button> _inputs = new List<Button>();

    private void Start()
    {
        foreach (var o in lightArray.contents)
        {
            o.GetComponent<SpriteRenderer>().color = new Color(51, 51, 51);
        }
    }

    public override void StartMinigame()
    {
        started = true;
        _timer = maxTime;
        GameManager.gameManager.SetTimerPercentage(1);
        _beginCount++;

        if (_beginCount % 2 == 1)
        {
            _buttons.Clear();
            int i;
            for (i = 0; i < 6; i++)
            {
                Invoke(nameof(PulseAdd), i * 0.75f);
            }
            Invoke(nameof(FinishEarly), i * 0.75f + 1f);
        }
        else
        {
            _inputs.Clear();
        }
    }
    
    public bool IsMemorize => _beginCount % 2 == 1;

    private void Pulse()
    {
        buttonDiamond.color = Color.white;
        buttonSquare.color = Color.white;
        buttonCircle.color = Color.white;
        buttonTriangle.color = Color.white;
    }

    private void UpdateLights(int count, bool isWin = default)
    {
        for (var i = 0; i < count; i++)
        {
            lightArray.contents[i].GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (count != 6) return;
        var color = isWin ? Color.green : Color.red;
        foreach (var o in lightArray.contents)
        {
            o.GetComponent<SpriteRenderer>().color = color;
        }
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
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        _buttons.Add(toAdd);
        UpdateLights(_buttons.Count, true);
    }

    public void ClickEventHandler(GameObject origin, ButtonInteraction interaction)
    {
        if (IsMemorize) return;
        if (_inputs.Count >= 6) return;
        origin.transform.localScale *= .8f;
        switch (interaction.buttonType)
        {
            case Button.Diamond:
                buttonDiamond.color = Color.red;
                break;
            case Button.Square:
                buttonSquare.color = Color.green;
                break;
            case Button.Circle:
                buttonCircle.color = Color.blue;
                break;
            case Button.Triangle:
                buttonTriangle.color = Color.yellow;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        _inputs.Add(interaction.buttonType);
        var i = 0;
        var valid = _inputs.Count == _buttons.Count && _inputs.TrueForAll(t => t == _buttons[i++]);
        UpdateLights(_inputs.Count, valid);
        if (_inputs.Count != 6) return;
        EndMinigame(valid);
    }
    
    private void FinishEarly()
    {
        EndMinigame(true);
    }

    public override void EndMinigame(bool isWin)
    {
        base.EndMinigame(isWin);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
            return;
        if (!IsMemorize) _timer -= Time.deltaTime;
        GameManager.gameManager.SetTimerPercentage(_timer / maxTime);
        if (_timer > 0) return;
        started = false;
        EndMinigame(IsMemorize || false /* TODO */);
    }

    public override string GetInstructionSnippet()
    {
        return _beginCount % 2 == 0 ? "Memorize!" : "Recall!";
    }
}

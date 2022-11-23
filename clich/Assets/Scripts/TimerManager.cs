using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] RectTransform timerBar;

    private float barMaxSize;

    // Start is called before the first frame update
    void Start()
    {
        barMaxSize = timerBar.sizeDelta.x;
        Debug.Log(barMaxSize);
    }

    //if you want to set the timer within a minigame, do it through the GameManager
    public void SetBarWidth(float fraction)
    {
        timerBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barMaxSize * fraction);
    }
}

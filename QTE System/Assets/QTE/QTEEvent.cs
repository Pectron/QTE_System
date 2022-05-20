using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

public abstract class QTEEvent : MonoBehaviour
{ 
    protected QTEManager qTEManager;

    [Header("UI Settings")]
    [SerializeField] private Button button;
    [SerializeField] private string textButton;
    protected GameObject canvas;
    protected Button butCanvas;


    [Header("Conditions Event")]
    [SerializeField] private UseTimer timerControl;
    [SerializeField] private float timeToEnd = 3;
    [SerializeField] private TimeScaler timeScaler;
    [SerializeField] private float clicksToEnd = 3;
    private bool sucess;
    
    public QTEState qTEState;
    
    [Header("Add Events")]
    [SerializeField] private UnityEvent AddOnStart;
    [SerializeField] private UnityEvent AddOnUpdateEvent;
    [SerializeField] private UnityEvent AddOnEndSucess;
    [SerializeField] private UnityEvent AddOnEndFail;
    [SerializeField] private UnityEvent AddOnClick;

    private void Start()
    {
        qTEManager = FindObjectOfType<QTEManager>();
        qTEState = QTEState.start;
    }

    public virtual void OnStart()
    {
        CreateCanvas();

        switch(timeScaler)
        {
            case TimeScaler.slow:
                Time.timeScale = 0.5f;
                break;
            case TimeScaler.fast:
                Time.timeScale = 1.5f;
                break;
            default:
                Time.timeScale = 1f;
                break;
        }

        AddOnStart.Invoke();
    }

    public virtual void UpdateEvent()
    {
        if(timerControl == UseTimer.use)
            CondTimer();
        CondKey();

        AddOnUpdateEvent.Invoke();
    }

    public virtual void OnEnd()
    {
        Time.timeScale = 1f;

        if(sucess)
            AddOnEndSucess.Invoke();
        else
            AddOnEndFail.Invoke();
        
        Destroy(canvas);
        Destroy(this.gameObject);
    }

    public void Click()
    {
        clicksToEnd -= 1;
        AddOnClick.Invoke();
    }

    private void CreateCanvas()
    {
        canvas = new GameObject("Canvas");
        Canvas c = canvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();

        butCanvas = Instantiate(button, canvas.transform);
        butCanvas.GetComponentInChildren<TextMeshProUGUI>().text = textButton;
    }

    private void CondTimer()
    {
        timeToEnd -= Time.deltaTime;

        if(timeToEnd <= 0)
        {
            qTEState = QTEState.finished;
            sucess = false;
        }
    }

    private void CondKey()
    {
        if(clicksToEnd <= 0)
        {
            qTEState = QTEState.finished;
            sucess = true;
        }
    }
}

public enum QTEState
{
    start,
    running,
    finished
}

public enum UseTimer
{
    use,
    noUse
}

public enum TimeScaler
{
    normal,
    slow,
    fast
}
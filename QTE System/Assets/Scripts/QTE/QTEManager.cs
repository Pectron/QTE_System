using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEManager : MonoBehaviour
{   
    [HideInInspector]
    public Queue<QTEEvent> qteEventsDo = new Queue<QTEEvent>();
    private QTEEvent _currentEvent;

    private void Update()
    {
        if(_currentEvent == null)
        {
            if(qteEventsDo.Count > 0)
            {
                _currentEvent = qteEventsDo.Dequeue();
                _currentEvent = Instantiate(_currentEvent, transform);
                
            }
        }
        else
        {
            if(_currentEvent.qTEState == QTEState.start)
                StartQTE(_currentEvent);

            else if(_currentEvent.qTEState == QTEState.running)
                UpdateQTE(_currentEvent);
                
            else if(_currentEvent.qTEState == QTEState.finished)
                EndQTE(_currentEvent);
        }
        
    }

    private void StartQTE(QTEEvent qTE)
    {
        qTE.OnStart();
        qTE.qTEState = QTEState.running;
    }

    private void UpdateQTE(QTEEvent qTE)
    {
        qTE.UpdateEvent();
    }

    private void EndQTE(QTEEvent qTE)
    {
        qTE.OnEnd();
        _currentEvent = null;
    }
}

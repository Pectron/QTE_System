using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEEventKey : QTEEvent
{
    [Header("Keys")]
    [SerializeField] private KeyCode key = KeyCode.Space;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void UpdateEvent()
    {
        base.UpdateEvent();

        if(Input.GetKeyDown(key))
            Click();
    }

    public override void OnEnd()
    {
        base.OnEnd();
    }
}

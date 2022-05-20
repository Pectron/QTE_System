using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QTEEventUI : QTEEvent
{
    
    public override void OnStart()
    {
        base.OnStart();
        butCanvas.onClick.AddListener(Click);
    }

    public override void UpdateEvent()
    {
        base.UpdateEvent();
    }

    public override void OnEnd()
    {
        base.OnEnd();
    }
}

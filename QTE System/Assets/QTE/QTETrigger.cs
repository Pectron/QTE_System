using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QTETrigger : MonoBehaviour
{
    [SerializeField] private string tagActiveTrigger;
    [SerializeField] private List<QTEEvent> qteEvents;
    private QTEManager qteManager;

    private void Start()
    {
        qteManager = FindObjectOfType<QTEManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == tagActiveTrigger)
        {
            foreach(QTEEvent qte in qteEvents)
            {
                qteManager.qteEventsDo.Enqueue(qte);
            }

            this.enabled = false;
        }
    }
}

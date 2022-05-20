using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private Vector3 startPos, finalPos;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (finalPos - startPos).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void Pull()
    {
        Vector3 dir = (finalPos - startPos).normalized;
        transform.position += -dir * speed;
    }

    public void Scale()
    {
        transform.localScale += new Vector3(0.0001f, 0.0001f, 0.0001f);
    }

    public void Stop()
    {
        speed = 0;
    }
}

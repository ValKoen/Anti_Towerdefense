using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilBehavior : MonoBehaviour
{
    public GameObject target;
    public DateTime startupTime;
    public DateTime currentRuntime;
    public double lifetime;
    public float projektilGeschwindigkeit;

    // Start is called before the first frame update
    void Start()
    {
        startupTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        currentRuntime = DateTime.Now;
        TimeSpan delta = currentRuntime - startupTime;
        
        if (delta.TotalSeconds >= lifetime)
        {
            Destroy(this.gameObject);
        }

        if (target == null) return;
        
        Vector2 zielPosition = target.transform.position;

        Vector2 richtung = (zielPosition - (Vector2)transform.position).normalized;
        Vector2 geschwindigkeit = richtung * projektilGeschwindigkeit;

        transform.position += (Vector3)(geschwindigkeit * Time.deltaTime);
    }
}

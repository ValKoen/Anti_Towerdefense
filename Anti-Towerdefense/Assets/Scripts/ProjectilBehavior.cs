using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilBehavior : MonoBehaviour
{
    public GameObject target;
    public float projektilGeschwindigkeit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        
        Vector2 zielPosition = target.transform.position;

        Vector2 richtung = (zielPosition - (Vector2)transform.position).normalized;
        Vector2 geschwindigkeit = richtung * projektilGeschwindigkeit;

        transform.position += (Vector3)(geschwindigkeit * Time.deltaTime);
    }
}

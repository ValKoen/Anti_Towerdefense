using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    public int health;

    public UnityEvent healthUpdate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Projektil")) 
        {
            var dd = other.gameObject.GetComponent<DamageDealer>();
            health -= dd.Damage;

            Destroy(other.gameObject);

            healthUpdate.Invoke();
        }
    }
}

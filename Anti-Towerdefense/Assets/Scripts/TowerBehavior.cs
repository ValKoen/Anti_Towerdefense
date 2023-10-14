using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public GameObject Prefab;
    private HealthHandler healthHandler;
    public GameObject[] units;

    // Schießen
    public float range = 0;
    public GameObject closest = null;
    public DateTime startupTime;
    public DateTime currentRuntime;
    public float fireRate = 0; 
    public bool boom = false;
    
    // Start is called before the first frame update
    void Start()
    {
        healthHandler = GetComponent<HealthHandler>();
        healthHandler.healthUpdate.AddListener(onHealthupdate);

        startupTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        currentRuntime = DateTime.Now;
        TimeSpan delta = currentRuntime - startupTime;

        if (delta.TotalSeconds >= fireRate)
        {
            units = GameObject.FindGameObjectsWithTag("Unti");
            StartCoroutine(FireCoroutine());
            startupTime = DateTime.Now;
        }
    }

    IEnumerator FireCoroutine()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        float curDistance = Mathf.Infinity;
        
        foreach (GameObject go in units)
        {
            Vector3 diff = go.transform.position - position;
            curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        
        if (distance < range)
        {
            boom = true;
        }
        else 
        {
            boom = false;
            yield return null;
        }

        if (boom == true)
        {
            Debug.Log("Fire");
            GameObject go = Instantiate(Prefab, transform);
            ProjectilBehavior projectil = go.GetComponent<ProjectilBehavior>();
            projectil.target = closest;
            yield return null;
        }
    }

    void onHealthupdate() 
    {
        if (healthHandler.health <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}

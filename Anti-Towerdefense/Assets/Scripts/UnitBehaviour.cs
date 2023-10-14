using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking.Types;

public class UnitBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] Enemys;
    public GameObject[] Units;
    public GameObject Prefab;
    private HealthHandler healthHandler;

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
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;

        healthHandler = GetComponent<HealthHandler>();
        healthHandler.healthUpdate.AddListener(onHealthupdate);

        Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        startupTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        currentRuntime = DateTime.Now;
        TimeSpan delta = currentRuntime - startupTime;

        if (delta.TotalSeconds >= fireRate)
        {
            Enemys = GameObject.FindGameObjectsWithTag("Enemy");
            StartCoroutine(FireCoroutine());
            startupTime = DateTime.Now;
        }
    }

    IEnumerator FireCoroutine()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        float curDistance = Mathf.Infinity;

        foreach (GameObject go in Enemys)
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
            Debug.Log("Fire Unit");
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

    public void updatePosition (Vector3 Position) 
    {
        agent.destination = Position;
    }
}

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

    private HealthHandler healthHandler;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;

        healthHandler = GetComponent<HealthHandler>();
        healthHandler.healthUpdate.AddListener(onHealthupdate);

        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
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

   public void FindClosestEnemy()
    {
        GameObject closest = null;
        float curDistance = Mathf.Infinity;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

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
    }
}

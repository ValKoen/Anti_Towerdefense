using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public GameObject[] Enemys;

    public float range = 0;
    public GameObject[] Units;
    public GameObject Prefab;
    private HealthHandler healthHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        healthHandler = GetComponent<HealthHandler>();
        healthHandler.healthUpdate.AddListener(onHealthupdate);


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

    public void FindClosestUnit()
    {
        Units = GameObject.FindGameObjectsWithTag("Units");

        GameObject closest = null;
        float curDistance = Mathf.Infinity;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in Units)
        {
            Vector3 diff = go.transform.position - position;
            curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        if (curDistance <= range)
        {
            Instantiate(Prefab, transform);
        }
    }
}

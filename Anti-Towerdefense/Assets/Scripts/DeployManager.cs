using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DeployManager : MonoBehaviour
{
    public float deployCooldown = 2;
    public Transform unitGrid;
    public Transform spawnPoint;
    public List<GameObject> Units;
    private List<GameObject> units = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Units = units;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeploy() 
    {
        StartCoroutine(DeployCoroutine());
    }

    public List<GameObject> UnitList()
    {
        return Units;
    }

    IEnumerator DeployCoroutine() 
    {
        int childCount = unitGrid.childCount;
        for(int i=0; i< childCount; i++)
        {
            UnitData unitData = unitGrid.GetChild(0).GetComponent<UnitData>();
            GameObject go = Instantiate(unitData.myPrefab, spawnPoint);
            Units.Add(go);
            Destroy(unitGrid.GetChild(0).gameObject);
            yield return new WaitForSeconds(deployCooldown);
        }
    }
}

public class UpdateUnitList : MonoBehaviour
{
    public UnityEvent UpdateUnits;
    public List<GameObject> Units
    {
        get { return Units; }
        set
        {
            Units = value;
            UpdateUnits.Invoke();
        }
    }
}


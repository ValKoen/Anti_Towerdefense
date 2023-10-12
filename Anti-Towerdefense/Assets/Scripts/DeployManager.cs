using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployManager : MonoBehaviour
{
    public float deployCooldown = 2;
    public Transform unitGrid;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeploy() 
    {
        StartCoroutine(DeployCoroutine());
    }

    IEnumerator DeployCoroutine() 
    {
        int childCount = unitGrid.childCount;
        for(int i=0; i< childCount; i++)
        {
            UnitData unitData = unitGrid.GetChild(0).GetComponent<UnitData>();
            Instantiate(unitData.myPrefab, spawnPoint);
            Destroy(unitGrid.GetChild(0).gameObject);
            yield return new WaitForSeconds(deployCooldown);
        }
    }
}

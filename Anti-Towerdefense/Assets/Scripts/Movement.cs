using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);

            GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
            foreach (GameObject Unit in units)
            {
                var unitBehaviour = Unit.GetComponent<UnitBehaviour>();
                unitBehaviour.updatePosition(mousePos);
            }
        }
    }
}

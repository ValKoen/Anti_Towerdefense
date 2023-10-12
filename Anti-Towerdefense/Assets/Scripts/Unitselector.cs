using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitselector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject timelineElement;
    public Transform gridTransform;

    // OnClick
    public void OnClick() {
        Instantiate(timelineElement, gridTransform);
    }
}

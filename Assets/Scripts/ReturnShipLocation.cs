using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnShipLocation : MonoBehaviour {

    [HideInInspector]
    public string GridLocation;

    void Start()
    {
        GridLocation = gameObject.name;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Ship")
        {
            Debug.Log("You have entered " + GridLocation);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Ship")
        {
            Debug.Log("You have exited " + GridLocation);
        }
    }
}

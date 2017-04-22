using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnShipLocation : MonoBehaviour {

    public string GridLocation;

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

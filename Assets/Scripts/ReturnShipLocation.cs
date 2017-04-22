using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnShipLocation : MonoBehaviour {

    [HideInInspector]
    public string GridLocation;
    ShipInformation shipInformation;

    void Start()
    {
        GridLocation = gameObject.name;
        shipInformation = FindObjectOfType<ShipInformation>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Ship")
        {
            Debug.Log("You have entered " + GridLocation);
            shipInformation.SetGridLocation(GridLocation);
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

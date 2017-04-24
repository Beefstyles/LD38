using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip : MonoBehaviour {

    public Transform TeleportLocation;
    private Vector3 TransportLocation;
    ShipMovement shipMovement;
    
    void Start()
    {
        shipMovement = FindObjectOfType<ShipMovement>();
    }
	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Ship")
        {
            TransportLocation = new Vector3(TeleportLocation.position.x, shipMovement.ShipAltitude, TeleportLocation.position.z);
            Debug.Log("Moving ship");
            shipMovement.TransportShip(TransportLocation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotation : MonoBehaviour {

    ShipMovement shipMovement;
	void Start ()
    {
        shipMovement = FindObjectOfType<ShipMovement>();
    }
	
	void Update ()
    {
        transform.Rotate(Vector3.up, shipMovement.RotationSpeed);
    }
}

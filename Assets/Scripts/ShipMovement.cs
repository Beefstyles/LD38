using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float Speed;
    public float MaxSpeed;
    public float RotationSpeed;
    public float MaxRotationSpeed;
    public float ShipAltitude;

    

	void Start()
    {
        ShipAltitude = transform.position.y;
    }

	void Update ()
    {
        transform.Translate(Vector3.forward * Speed);
        transform.Rotate(Vector3.up, RotationSpeed);
	}

    public void TransportShip(Vector3 TransportLocation)
    {
        transform.position = TransportLocation;
    }
}

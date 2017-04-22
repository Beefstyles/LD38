using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float Speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.right * Speed);
	}
}

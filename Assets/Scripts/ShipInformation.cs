using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInformation : MonoBehaviour {

    public string GridLocation;
    public float HeliumRemaining, HeliumMax;

	void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void SetGridLocation(string gridLocation)
    {
        GridLocation = gridLocation;
    }
}

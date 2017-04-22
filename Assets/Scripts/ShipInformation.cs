using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInformation : MonoBehaviour {

    [HideInInspector]
    public string GridLocation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGridLocation(string gridLocation)
    {
        GridLocation = gridLocation;
    }
}

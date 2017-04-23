﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpGridControl : MonoBehaviour {

    public LightUpGridItem[] LightUpGrids;
    public Dictionary<string, LightUpGridItem> LightUpGridDictionary;
    private LightUpGridItem currentGridRef;
	// Use this for initialization
	void Start ()
    {
        LightUpGrids = GetComponentsInChildren<LightUpGridItem>();

        foreach (var lg in LightUpGrids)
        {
            LightUpGridDictionary.Add(lg.name, lg);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateGridPosition(string currentGridPosition, bool TurnOn)
    {
        LightUpGridItem lgi;
        if(LightUpGridDictionary.TryGetValue(currentGridPosition,out lgi))
        {
            lgi.TurnOnOffLight(TurnOn);
        }
    }
}

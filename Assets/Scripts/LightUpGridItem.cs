using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpGridItem : MonoBehaviour {

    public Material LightOn, LightOff;

    private Renderer LightRenderer;

    void Start()
    {
        LightRenderer = GetComponent<MeshRenderer>();
    }

    public void TurnOnOffLight(bool turnOn)
    {
        if (turnOn)
        {
            LightRenderer.material = LightOn;
        }
        else
        {
            LightRenderer.material = LightOff;
        }
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}

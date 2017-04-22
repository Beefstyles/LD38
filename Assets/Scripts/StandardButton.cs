using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardButton : MonoBehaviour {

    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    private bool buttonOn;
    private MeshRenderer gameObjMesh;
    public bool GoForward;
    private float buttonOffTimer;
    private float buttonOffTimerSet = 0.2F;


	void Start ()
    {
        gameObjMesh = GetComponent<MeshRenderer>();
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
        ButtonPressed = false;
		
	}

	void Update ()
    {
        if (ButtonPressed)
        {
            ButtonPressed = false;
            buttonOn = true;
            gameObjMesh.material = ButtonOnMat;
            buttonOffTimer = buttonOffTimerSet;
        }
        else
        {
            if(buttonOffTimer >= 0)
            {
                buttonOffTimer -= Time.deltaTime;
            }
            if(buttonOffTimer <= 0)
            {
                TurnButtonOff();
            }
        }

	}


    void TurnButtonOff()
    {
        if (buttonOn)
        {
            buttonOn = false;
            gameObjMesh.material = ButtonOffMat;
            ButtonPressed = false;
        }
    }

 
}

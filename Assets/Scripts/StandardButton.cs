using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonAction
{
    Velocity, Rotation, StopVelocity, StopRotation
};
public class StandardButton : MonoBehaviour {

    public ButtonAction buttonAction;
    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    private bool buttonOn;
    private MeshRenderer gameObjMesh;
    public bool GoForward;
    private float buttonOffTimer;
    private float buttonOffTimerSet = 0.2F;
    private float speedChangeIncrement = 0.005F;
    private float speedChangeStopIncrement = 0.01F;
    ShipMovement shipMovement;


	void Start ()
    {
        gameObjMesh = GetComponent<MeshRenderer>();
        shipMovement = FindObjectOfType<ShipMovement>();
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
            switch (buttonAction)
            {
                case (ButtonAction.Velocity):
                    ChangeVelocity(true);
                    break;
                case (ButtonAction.StopVelocity):
                    ChangeVelocity(false);
                    break;
            }

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

    void ChangeVelocity(bool moveShip)
    {
        if (buttonOn)
        {
            if (moveShip)
            {
                if (shipMovement.Speed <= shipMovement.MaxSpeed)
                {
                    if (GoForward)
                    {
                        shipMovement.Speed += speedChangeIncrement;
                    }
                    else
                    {
                        shipMovement.Speed -= speedChangeIncrement;
                    }
                }
            }
            else
            {
                if (shipMovement.Speed < 0.1F && shipMovement.Speed > -0.1F)
                {
                    shipMovement.Speed = 0F;
                }
                if (shipMovement.Speed > 0F)
                {
                    shipMovement.Speed -= speedChangeStopIncrement;
                }
                else if (shipMovement.Speed < 0F)
                {
                    shipMovement.Speed += speedChangeStopIncrement;
                }
                
                
            }
            
            
        }
        
    }

 
}

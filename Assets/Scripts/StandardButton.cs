using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonAction
{
    Velocity, Rotation, StopVelocity, StopRotation,SelectBotType, SpawnBot, BuyObject
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
    private float rotationChangeIncrement = 0.0005F;
    private float rotationChangeStopIncrement = 0.001F;
    private float speedChangeStopIncrement = 0.01F;
    ShipMovement shipMovement;
    public BotType botType;
    public bool IsToggle;
    public GameObject[] OtherButtons;
    BotSelector botSelector;
    BotHandler botHandler;


    void Start ()
    {
        gameObjMesh = GetComponent<MeshRenderer>();
        shipMovement = FindObjectOfType<ShipMovement>();
        botSelector = FindObjectOfType<BotSelector>();
        botHandler = FindObjectOfType<BotHandler>();
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
        ButtonPressed = false;
	}

	void Update ()
    {
        if (!IsToggle)
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
                    case (ButtonAction.Rotation):
                        ChangeRotation(true);
                        break;
                    case (ButtonAction.StopRotation):
                        ChangeRotation(false);
                        break; 
                }

            }
            else
            {
                if (buttonOffTimer >= 0)
                {
                    buttonOffTimer -= Time.deltaTime;
                }
                if (buttonOffTimer <= 0)
                {
                    TurnButtonOff();
                }
            }
        }
        

	}


    public void TurnButtonOff()
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
                if (Mathf.Abs(shipMovement.Speed) <= Mathf.Abs(shipMovement.MaxSpeed))
                {
                    if (GoForward)
                    {
                        shipMovement.Speed += speedChangeIncrement;
                    }
                    else
                    {
                        shipMovement.Speed -= speedChangeIncrement;
                    }
                    shipMovement.ReduceHeliumSupply("MoveShip");
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

    void ChangeRotation(bool rotateShip)
    {
        if (buttonOn)
        {
            if (rotateShip)
            {
                if (Mathf.Abs(shipMovement.RotationSpeed) <= Mathf.Abs(shipMovement.MaxRotationSpeed))
                {
                    if (GoForward)
                    {
                        shipMovement.RotationSpeed += rotationChangeIncrement;
                    }
                    else
                    {
                        shipMovement.RotationSpeed -= rotationChangeIncrement;
                    }
                    shipMovement.ReduceHeliumSupply("RotateShip");
                }
            }
            else
            {
                if (Mathf.Abs(shipMovement.RotationSpeed) < 0.005F)
                {
                    shipMovement.RotationSpeed = 0F;
                }
                if (shipMovement.RotationSpeed > 0F)
                {
                    shipMovement.RotationSpeed -= rotationChangeStopIncrement;
                }
                else if (shipMovement.Speed < 0F)
                {
                    shipMovement.RotationSpeed += rotationChangeStopIncrement;
                }


            }
        }
    }


}

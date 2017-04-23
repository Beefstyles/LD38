using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSelectorButtons : MonoBehaviour {

    public ButtonAction buttonAction;
    private MeshRenderer gameObjMesh;
    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    public BotType botType;
    public bool IsToggle;
    public GameObject[] OtherButtons;
    BotSelector botSelector;
    BotHandler botHandler;
    ShipMovement shipMovement;
    private bool buttonOn;
    private bool spawnSuccessful;
    private float buttonOffTimer;
    private float buttonOffTimerSet = 0.2F;
    public BotSelectorButtons SpawnBotButton;

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
	
	void Update () {

        if (IsToggle)
        {
            if (ButtonPressed)
            {
                ButtonPressed = false;
                buttonOn = true;
                gameObjMesh.material = ButtonOnMat;
                switch (buttonAction)
                {
                    case (ButtonAction.SelectBotType):
                        botSelector.bt = botType;
                        foreach (var btn in OtherButtons)
                        {
                            btn.GetComponent<BotSelectorButtons>().TurnButtonOff();
                        }
                        break;
                }
            }
        }

        else
        {
            if (ButtonPressed)
            {
                ButtonPressed = false;
                buttonOn = true;
                gameObjMesh.material = ButtonOnMat;
                buttonOffTimer = buttonOffTimerSet;
                switch (buttonAction)
                {
                    case (ButtonAction.SpawnBot):
                        botHandler.SpawnBot(botSelector.bt);
                        spawnSuccessful = botHandler.SpawnSuccessful;
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
}

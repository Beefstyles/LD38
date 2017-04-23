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

        if (ButtonPressed)
            Debug.Log("Tggle");
        ButtonPressed = false;
        buttonOn = true;
        gameObjMesh.material = ButtonOnMat;
        switch (buttonAction)
        {
            case (ButtonAction.SelectBotType):
                botSelector.bt = botType;
                foreach (var btn in OtherButtons)
                {
                    btn.GetComponent<StandardButton>().TurnButtonOff();
                }
                break;
            case (ButtonAction.SpawnBot):
                botHandler.SpawnBot(botType);
                break;
        }
    }
}

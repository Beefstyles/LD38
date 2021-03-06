﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuyingOptions
{
    H3Unit, NewMiningBot, NewArchBot, NewExplorBot
};
public class BuyingButton : MonoBehaviour {

    public ButtonAction buttonAction;
    public BuyingOptions buyingOption;
    private MeshRenderer gameObjMesh;
    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    private bool buttonOn;
    private float buttonOffTimer;
    private float buttonOffTimerSet = 0.2F;
    public BotSelectorButtons SpawnBotButton;
    EquipmentUpgradeHandler equipUpgradeHandler;

    void Start()
    {
        gameObjMesh = GetComponent<MeshRenderer>();
        equipUpgradeHandler = FindObjectOfType<EquipmentUpgradeHandler>();
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
        ButtonPressed = false;
    }

    void Update()
    {
            if (ButtonPressed)
            {
                ButtonPressed = false;
                buttonOn = true;
                gameObjMesh.material = ButtonOnMat;
                buttonOffTimer = buttonOffTimerSet;
                equipUpgradeHandler.ReceiveBuyingButton(buyingOption);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGameButtonHandler : MonoBehaviour {

    private MeshRenderer gameObjMesh;
    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    private bool buttonOn;
    private float buttonOffTimer;
    private float buttonOffTimerSet = 0.2F;
    ArtifactHandler artifactHandler;
    OverallGameHandler overallGameHandler;

    void Start()
    {
        gameObjMesh = GetComponent<MeshRenderer>();
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
        ButtonPressed = false;
        artifactHandler = FindObjectOfType<ArtifactHandler>();
        overallGameHandler = FindObjectOfType<OverallGameHandler>();
    }

    void Update()
    {
            if (ButtonPressed)
            {
                ButtonPressed = false;
                buttonOn = true;
                gameObjMesh.material = ButtonOnMat;
                buttonOffTimer = buttonOffTimerSet;
            if (artifactHandler.AllArtifactsFound && !overallGameHandler.GameOver)
            {
                overallGameHandler.GameOver = true;
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

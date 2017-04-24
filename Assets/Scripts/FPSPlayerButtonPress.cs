using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FPSPlayerButtonPress : MonoBehaviour {

    private RaycastHit hit;
    private Camera fpsCamera;
    StandardButton sb;
    BotSelectorButtons BotSelectorButton;
    BuyingButton BuyingOptionButton;
    public Sprite CursorNonClickable, CursorClickable;
    public Image Cursor;
    OverallGameHandler overallGameHandler;
    EndOfGameButtonHandler endGameButton;

    void Start()
    {
        fpsCamera = GetComponentInChildren<Camera>();
        overallGameHandler = FindObjectOfType<OverallGameHandler>();
    }
	void Update ()
    {
        if (!overallGameHandler.GameOver)
        {
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 100F))
            {
                if (hit.transform.gameObject.tag == "Clickable")
                {
                    sb = hit.transform.gameObject.GetComponent<StandardButton>();
                    BotSelectorButton = hit.transform.GetComponent<BotSelectorButtons>();
                    BuyingOptionButton = hit.transform.gameObject.GetComponent<BuyingButton>();
                    if (Input.GetButton("Fire1"))
                    {
                        if (sb != null)
                        {
                            sb.GoForward = true;
                            sb.ButtonPressed = true;
                            //Cursor.sprite = CursorClickable;
                        }
                    }
                    if (Input.GetButton("Fire2"))
                    {
                        if (sb != null)
                        {
                            sb.GoForward = false;
                            sb.ButtonPressed = true;
                            //Cursor.sprite = CursorClickable;
                        }
                    }

                    if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                    {
                        if (BotSelectorButton != null)
                        {
                            BotSelectorButton.ButtonPressed = true;
                        }
                        if (BuyingOptionButton != null)
                        {
                            BuyingOptionButton.ButtonPressed = true;
                        }
                        if(endGameButton != null)
                        {
                            endGameButton.ButtonPressed = true;
                        }
                    }
                }
            }
        }
        
    }
}

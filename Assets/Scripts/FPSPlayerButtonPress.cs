using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FPSPlayerButtonPress : MonoBehaviour {

    private RaycastHit hit;
    private Camera fpsCamera;
    StandardButton sb;
    public Sprite CursorNonClickable, CursorClickable;
    public Image Cursor;

    void Start()
    {
        fpsCamera = GetComponentInChildren<Camera>();
    }
	void Update ()
    {
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 100F))
        {
            if (hit.transform.gameObject.tag == "Clickable")
            {
                sb = hit.transform.gameObject.GetComponent<StandardButton>();
                if (Input.GetButton("Fire1"))
                {
                    sb.GoForward = true;
                    sb.ButtonPressed = true;
                    //Cursor.sprite = CursorClickable;
                }
                if (Input.GetButton("Fire2"))
                {
                    sb.GoForward = false;
                    sb.ButtonPressed = true;
                    //Cursor.sprite = CursorClickable;
                }
            }
        }
    }
}

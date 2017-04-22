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
            if (Input.GetButton("Fire1") && hit.transform.gameObject.tag=="Clickable")
            {
                sb = hit.transform.gameObject.GetComponent<StandardButton>();
                sb.ButtonPressed = true;
                //Cursor.sprite = CursorClickable;
            }
        }
        else
        {
            Debug.Log("Not clickable");
            //Cursor.sprite = CursorNonClickable;
        }
        
    }
}

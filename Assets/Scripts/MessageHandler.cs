using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageHandler : MonoBehaviour {

    public TextMeshPro Message1, Message2, Message3, Message4, Message5, Message6, Message7, Message8;
    private AudioSource MessageReceived;

    public int CurrentMessageNumber = 1;

    void Start()
    {
        MessageReceived = GetComponent<AudioSource>();
    }
	public void ReceiveMessage(string message)
    {
        switch (CurrentMessageNumber)
        {
            case (1):
                Message1.text = CurrentMessageNumber + ": " + message;
                break;
            case (2):
                Message2.text = CurrentMessageNumber + ": " + message;
                break;
            case (3):
                Message3.text = CurrentMessageNumber + ": " + message;
                break;
            case (4):
                Message4.text = CurrentMessageNumber + ": " + message;
                break;
            case (5):
                Message5.text = CurrentMessageNumber + ": " + message;
                break;
            case (6):
                Message6.text = CurrentMessageNumber + ": " + message;
                break;
            case (7):
                Message7.text = CurrentMessageNumber + ": " + message;
                break;
            case (8):
                CurrentMessageNumber = 0;
                Message8.text = CurrentMessageNumber + ": " + message;
                break;
        }
        MessageReceived.Play();
        CurrentMessageNumber++;
    }
}

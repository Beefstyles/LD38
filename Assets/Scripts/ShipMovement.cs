using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float Speed;
    public float MaxSpeed;
    public float RotationSpeed;
    public float MaxRotationSpeed;
    public float ShipAltitude;
    ShipInformation shipInfo;
    public float CostOfVelocty, CostOfRotation;

    void Start()
    {
        ShipAltitude = transform.position.y;
        shipInfo = FindObjectOfType<ShipInformation>();
    }

    void Update()
    {
        if (shipInfo.HeliumRemaining > 0)
        {
            transform.Translate(Vector3.forward * Speed);
            transform.Rotate(Vector3.up, RotationSpeed);
        }
        else
        {
            Speed = 0;
            RotationSpeed = 0;
        }

    }

    public void TransportShip(Vector3 TransportLocation)
    {
        transform.position = TransportLocation;
    }

    public void ReduceHeliumSupply(string actionType)
    {
        switch (actionType)
        {
            case ("MoveShip"):
                shipInfo.HeliumRemaining -= CostOfVelocty * Speed;
                break;
            case ("RotateShip"):
                shipInfo.HeliumRemaining -= CostOfRotation * RotationSpeed;
                break;
        }
    }
}

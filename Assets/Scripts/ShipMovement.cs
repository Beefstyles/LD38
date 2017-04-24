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
    ResourceInformation resourceInfo;
    public float CostOfVelocty, CostOfRotation;

    void Start()
    {
        ShipAltitude = transform.position.y;
        resourceInfo = FindObjectOfType<ResourceInformation>();
        shipInfo = FindObjectOfType<ShipInformation>();
    }

    void Update()
    {
        if (resourceInfo.HeliumRemaining > 0)
        {
            transform.Translate(Vector3.forward * Speed);
            transform.Rotate(Vector3.up, RotationSpeed);
            resourceInfo.HeliumRemaining -= CostOfVelocty * Speed;
            resourceInfo.HeliumRemaining -= CostOfRotation * RotationSpeed;
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
                resourceInfo.HeliumRemaining -= CostOfVelocty * Speed;
                break;
            case ("RotateShip"):
                resourceInfo.HeliumRemaining -= CostOfRotation * RotationSpeed;
                break;
        }
    }
}

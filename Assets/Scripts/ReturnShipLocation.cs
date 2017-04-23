using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnShipLocation : MonoBehaviour {

    [HideInInspector]
    public string GridLocation;
    ShipInformation shipInformation;
    LightUpGridControl lgControl;
    public float ChanceOfIron, ChanceOfGold, ChanceOfPlatinum, ChanceOfCarbon, ChanceOfHelium3, ChanceOfArtifact;
    ResourceInformation resourceInfo;
    private Dictionary<string,float> resourceDictChance = new Dictionary<string,float>();

    void Start()
    {
        GridLocation = gameObject.name;
        lgControl = FindObjectOfType<LightUpGridControl>();
        shipInformation = FindObjectOfType<ShipInformation>();
        resourceDictChance.Add("Iron", ChanceOfIron);
        resourceDictChance.Add("Gold", ChanceOfGold);
        resourceDictChance.Add("Platinum", ChanceOfPlatinum);
        resourceDictChance.Add("Carbon", ChanceOfCarbon);
        resourceDictChance.Add("Helium3", ChanceOfHelium3);
        resourceDictChance.Add("Artifact", ChanceOfArtifact);
        resourceInfo = FindObjectOfType<ResourceInformation>();
        resourceInfo.GridRefChanceOfReturn.Add(GridLocation, resourceDictChance);
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Ship")
        {
            Debug.Log("You have entered " + GridLocation);
            shipInformation.SetGridLocation(GridLocation);
            lgControl.UpdateGridPosition(GridLocation, true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Ship")
        {
            //Debug.Log("You have exited " + GridLocation);
            lgControl.UpdateGridPosition(GridLocation, false);
        }
    }

}

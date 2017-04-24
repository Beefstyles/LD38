using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactHandler : MonoBehaviour {

    public bool Artifact1Found, Artifact2Found, Artifact3Found, Artifact4Found;
    ResourceInformation resourceInfo;

	void Start ()
    {
        resourceInfo = FindObjectOfType<ResourceInformation>();
    }
	
    public bool CheckArtifact(string BotLocation)
    {
        switch (BotLocation)
        {
            case ("B5"):
                if (!Artifact1Found)
                {
                    Artifact1Found = true;
                    resourceInfo.NumberArtifacts++;
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            case ("C2"):
                if (!Artifact2Found)
                {
                    Artifact2Found = true;
                    resourceInfo.NumberArtifacts++;
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            case ("E2"):
                if (!Artifact3Found)
                {
                    Artifact3Found = true;
                    resourceInfo.NumberArtifacts++;
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            case ("F6"):
                if (!Artifact4Found)
                {
                    Artifact4Found = true;
                    resourceInfo.NumberArtifacts++;
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            default:
                return false;
                break;

        }
    }

	void Update ()
    {
		
	}
}

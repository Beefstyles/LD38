using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArtifactNumber
{
    One,Two,Three,Four
};
public class Artifact : MonoBehaviour {

    public GameObject ArtifactModel;
    private bool modelVisible;
    ArtifactNumber artifactNumber;
    ArtifactHandler artifactHandlder;
    
	void Start ()
    {
        ArtifactModel.SetActive(false);
        modelVisible = false;
        artifactHandlder = GetComponentInChildren<ArtifactHandler>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!modelVisible)
        {
            switch (artifactNumber)
            {
                case ArtifactNumber.One:
                    if (artifactHandlder.Artifact1Found)
                    {

                        ArtifactModel.SetActive(true);
                        modelVisible = true;
                    }
                    break;
                case ArtifactNumber.Two:
                    if (artifactHandlder.Artifact2Found)
                    {
                        ArtifactModel.SetActive(true);
                    }
                    break;
                case ArtifactNumber.Three:
                    break;
                case ArtifactNumber.Four:
                    break;
                default:
                    break;
            }
        }	
	}
}

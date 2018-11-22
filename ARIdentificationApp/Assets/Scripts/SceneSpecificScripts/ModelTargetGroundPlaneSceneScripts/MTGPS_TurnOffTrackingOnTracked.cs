/* -----------------------------------------------------------------------
	Date: 22.11.2018
	Comment: Copied from the TurnOffTrackingOnTracked.cs from sample scene
            Specific script for ModelTargetGroundPlaneScene
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class MTGPS_TurnOffTrackingOnTracked : DefaultTrackableEventHandler
{
    public Text Debug;
    public GameObject virtualModel;
    public GameObject newParent;
    public GameObject WarningToggle;
    public GameObject ModelTarget;
	private bool firsttime = true;

    
    protected override void OnTrackingLost()
    {
        //TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        Debug.text += " MTGPS ModelTarget Tracking lost ";
    }

    //Stop tracking if the object was tracked
    protected override void OnTrackingFound() {
        Debug.text = " MTGPS ModelTarget Tracking found ";
        //TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();

        

		if(firsttime){
			//WarningToggle.GetComponent<Toggle>().isOn = true;
			firsttime = false;

            //Place GroundPlane at the point where VirtualModelAppeared
            newParent.transform.position = ModelTarget.transform.position;
            newParent.transform.eulerAngles = ModelTarget.transform.eulerAngles;


            Debug.text = " MTGPS set at: "+ newParent.transform.position.x+ ", " + newParent.transform.position.y + ", " + newParent.transform.position.z + ", ";
            //Move Virtual Model to new Parent
            virtualModel.transform.parent = newParent.transform;
        }
    }
}

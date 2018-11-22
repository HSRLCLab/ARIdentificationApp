/* -----------------------------------------------------------------------
	Date: 22.11.2018
	Comment: Copied from the TurnOffTrackingOnTracked.cs from sample scene
            Specific script for Proof Scene
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Proof_TurnOffTrackingOnTracked : DefaultTrackableEventHandler
{
    public Text Debug;
    public GameObject virtualModel;
    public GameObject ModelTarget;



    protected override void OnTrackingFound()
    {
        

        Debug.text = "Tracking found";
        /*
        //Disable Tracking makes that the Target is lost
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        objectTracker.Stop();*/
    }


    protected override void OnTrackingLost()
    {
        
        Debug.text += "Tracking lost";
    }
}

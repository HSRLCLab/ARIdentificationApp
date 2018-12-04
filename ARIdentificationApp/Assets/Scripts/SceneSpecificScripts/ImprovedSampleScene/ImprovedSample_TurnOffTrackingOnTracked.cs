using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ImprovedSample_TurnOffTrackingOnTracked : DefaultTrackableEventHandler
{
    public Text Debug;
    public GameObject virtualModel;
	public GameObject WarningToggle;
    //public GameObject newParent;
	private bool firsttime = true;

    /*
    void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        Debug.text = " ModelTarget trackerStopped " + previousStatus;
    }
    *//*
    protected override void OnTrackingLost()
    {
        //TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        Debug.text += " ModelTarget Tracking lost ";
    }*/

    //Stop tracking if the object was tracked
    protected override void OnTrackingFound() {
        Debug.text = " ModelTarget Tracking found ";
        //TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();

        //virtualModel.transform.parent = newParent.transform;
        /*
         //Disable Tracker leads to always searching for an object
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        //obsolete:
        //objectTracker.TargetFinder.Stop();
        objectTracker.GetTargetFinder<TargetFinder>().Stop();
        */
        
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();

        if (firsttime){
			WarningToggle.GetComponent<Toggle>().isOn = true;
			firsttime = false;
            /*
            //Move to new Parent, which is placed as the Modeltarget
            newParent.transform.position = transform.position;
            newParent.transform.eulerAngles = transform.eulerAngles;
            virtualModel.transform.parent = newParent.transform;
            */
        }
    }
}

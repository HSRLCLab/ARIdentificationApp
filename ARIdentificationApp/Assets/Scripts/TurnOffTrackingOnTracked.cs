using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class TurnOffTrackingOnTracked : DefaultTrackableEventHandler
{
    public Text Debug;
    public GameObject virtualModel;
	public GameObject WarningToggle;
	private bool firsttime = true;

    /*
    void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        Debug.text = " ModelTarget trackerStopped " + previousStatus;
    }
    */
    protected override void OnTrackingLost()
    {
        //TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        Debug.text += " ModelTarget Tracking lost ";
    }

    //Stop tracking if the object was tracked
    protected override void OnTrackingFound() {
        Debug.text = " ModelTarget Tracking found ";
        //TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();

        //virtualModel.transform.parent = newParent.transform;
		if(firsttime){
			WarningToggle.GetComponent<Toggle>().isOn = true;
			firsttime = false;

        }
    }
}

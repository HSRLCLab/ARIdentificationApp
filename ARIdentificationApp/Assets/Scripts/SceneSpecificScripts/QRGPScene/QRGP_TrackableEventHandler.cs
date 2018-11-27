using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class QRGP_TrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
      
    }


}

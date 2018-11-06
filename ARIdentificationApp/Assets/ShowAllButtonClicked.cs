using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ShowAllButtonClicked : MonoBehaviour {

    public Text Debugtext;

	// Use this for initialization
	void Start () {
        Debugtext.text = " Hellow ";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTracking() {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start(); //Requires "using Vuforia"
        Debugtext.text = " ShowAll: Tracker started ";

    }
}

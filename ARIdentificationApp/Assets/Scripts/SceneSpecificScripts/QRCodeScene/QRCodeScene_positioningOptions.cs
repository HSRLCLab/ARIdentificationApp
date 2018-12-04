/* -----------------------------------------------------------------------
	Date: 04.12.2018
	Comment: Position the virtual model manually. Copied from positionngOptions.cs.
            positionOptions.cs is still needed, as only the changed function is added here.
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRCodeScene_positioningOptions : MonoBehaviour {
	public GameObject VirtualModel;
	public GameObject ModelTarget;

    private Vector3 initialPosition;
    private Vector3 initialAngle;
    private Vector3 initialPosDiff;
    private Vector3 initialAngleDiff;
	// Use this for initialization
	void Start () {
        initialPosDiff = VirtualModel.transform.position - ModelTarget.transform.position;
        initialAngleDiff = VirtualModel.transform.eulerAngles - ModelTarget.transform.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Reset(){
        //Reset the VirtualModel to it's initial position, or wherever the ImageTarget currently is
        VirtualModel.transform.eulerAngles = ModelTarget.transform.eulerAngles + initialAngleDiff;
        VirtualModel.transform.position = ModelTarget.transform.position + initialPosDiff;
        
    }
}

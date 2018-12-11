/* -----------------------------------------------------------------------
	Date: 06.12.2018
	Comment: Position the virtual model manually. Copied from positioningOptions.cs.
            and the reset functionality from QRCodeScene_positioningOptions.cs 
            of the ARIdentificationApp.
    Last Updated: 11.12.2018 - removed all debuggingtexts, and cleanup of code
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class positioningOptions : MonoBehaviour {
	public GameObject VirtualModel;
	public GameObject ModelTarget;
	
	private Vector3 initialPosition;
    private Vector3 initialAngle;
    private Vector3 initialPosDiff;
    private Vector3 initialAngleDiff;

    // Use this for initialization
    void Start()
    {
        //store the initial difference between Virtual Model and ImageTarget - needed in Reset()
        initialPosDiff = VirtualModel.transform.position - ModelTarget.transform.position;
        initialAngleDiff = VirtualModel.transform.eulerAngles - ModelTarget.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveUp(){
		// Move the object upward in world space 1 unit/second.
		VirtualModel.transform.Translate(0, Time.deltaTime, 0, Space.World);
    }
	
	public void MoveDown(){
		// Move the object downwards in world space 1 unit/second.
		VirtualModel.transform.Translate(0, -Time.deltaTime, 0, Space.World);
	}
	
	public void MoveLeft(){
		// Move the object left in world space 1 unit/second.
		VirtualModel.transform.Translate(-Time.deltaTime, 0, 0, Space.World);
	}
	
	public void MoveRight(){
		// Move the object right in world space 1 unit/second.
		VirtualModel.transform.Translate(Time.deltaTime, 0, 0, Space.World);
	}
	
	public void MoveBack(){
		// Move the object away from viewer in world space 1 unit/second.
		VirtualModel.transform.Translate(0, 0, Time.deltaTime, Space.World);
	}
	
	public void MoveForward(){
		// Move the object towards viewer in world space 1 unit/second.
		VirtualModel.transform.Translate(0, 0, -Time.deltaTime, Space.World);
	}
	
	public void TurnLeftY(){
		// Rotate the object around the global Y axis at 10 degree per second
		VirtualModel.transform.Rotate(0, -Time.deltaTime*10, 0, Space.World);
	}
	
	public void TurnRightY(){
		// Rotate the object around the global Y axis at 10 degree per second counterclockwise
		VirtualModel.transform.Rotate(0, Time.deltaTime*10, 0, Space.World);
	}
	
	public void TurnLeftX(){
		// Rotate the object around the global X axis at 10 degree per second
		VirtualModel.transform.Rotate(-Time.deltaTime*10, 0, 0, Space.World);
	}
	
	public void TurnRightX(){
		// Rotate the object around the global X axis at 10 degree per second counterclockwise
		VirtualModel.transform.Rotate(Time.deltaTime*10, 0, 0, Space.World);
	}
	
	public void TurnLeftZ(){
		// Rotate the object around the global Z axis at 10 degree per second
		VirtualModel.transform.Rotate(0, 0, Time.deltaTime*10, Space.World);
	}
	
	public void TurnRightZ(){
		// Rotate the object around the global Z axis at 10 degree per second counterclockwise
		VirtualModel.transform.Rotate(0, 0, -Time.deltaTime*10, Space.World);
	}

    public void Reset()
    {
        //Reset the VirtualModel the ImageTarget's position and the initial difference between VirtualModel and ImageTarget
        VirtualModel.transform.eulerAngles = ModelTarget.transform.eulerAngles + initialAngleDiff;
        VirtualModel.transform.position = ModelTarget.transform.position + initialPosDiff;

    }
}

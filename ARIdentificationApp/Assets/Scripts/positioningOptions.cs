using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class positioningOptions : MonoBehaviour {
	public GameObject VirtualModel;
	
	//private float moveSpeed = 0.01f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void MoveUp(){
		// Move the object upward in world space 1 unit/second.
		VirtualModel.transform.Translate(0, Time.deltaTime, 0, Space.World);
		
	}
	public void MoveDown(){
		// Move the object upward in world space 1 unit/second.
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
	public void TurnLeft(){
		// Rotate the object around the global Y axis at 10 degree per second
		VirtualModel.transform.Rotate( 0, Time.deltaTime*10, 0, Space.World);
		
	}
	public void TurnRight(){
		// Rotate the object around the global Y axis at 10 degree per second counterclockwise
		VirtualModel.transform.Rotate( 0, -Time.deltaTime*10, 0, Space.World);
		
	}
}

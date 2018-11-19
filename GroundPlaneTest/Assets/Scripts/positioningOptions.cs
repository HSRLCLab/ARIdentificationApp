/* -----------------------------------------------------------------------
	Date: 19.11.2018
	Comment: Imported from ARIdentificationApp and changed to take Position from initial and not Parameter.
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class positioningOptions : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler
{
	public GameObject VirtualModel;
	//public GameObject ModelTarget;
	
	private Vector3 initialPosition;
    private Vector3 initialAngles;

    private bool pressed;
    private string nameOfButton;
    // Use this for initialization
    void Start () {

        initialPosition = VirtualModel.transform.position;
        initialAngles = VirtualModel.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("positioningOptions Update with " + nameOfButton + " pressed " + pressed);
        if (pressed) { 
            switch (nameOfButton)
            {
                case "TurnLeftX_Button":
                    TurnLeftX();
                    break;
                case "TurnRightX_Button":
                    TurnRightX();
                    break;
                case "TurnLeftY_Button":
                    TurnLeftY();
                    break;
                case "TurnRightY_Button":
                    TurnRightY();
                    break;
                case "TurnLeftZ_Button":
                    TurnLeftZ();
                    break;
                case "TurnRightZ_Button":
                    TurnRightZ();
                    break;
                case "Up_Button":
                    MoveUp();
                    break;
                case "Down_Button":
                    MoveDown();
                    break;
                case "Left_Button":
                    MoveLeft();
                    break;
                case "Right_Button":
                    MoveRight();
                    break;
                case "Back_Button":
                    MoveBack();
                    break;
                case "Front_Button":
                    MoveForward();
                    break;
                default:
                    Debug.Log("None of the above " + nameOfButton);
                    break;

            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        nameOfButton = eventData.pointerPress.name;
        Debug.Log("OnPointerDown " + eventData.pointerPress.name);
        Debug.Log("OnPointerDown " + eventData.pointerPress);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        nameOfButton = "";
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
	
	public void Reset(){
        //Reset the VirtualModel to it's initial position --> different to the function in ARIdentificationApp (19.11.2018)
        VirtualModel.transform.eulerAngles = initialAngles;
        VirtualModel.transform.position = initialPosition;
    }
}

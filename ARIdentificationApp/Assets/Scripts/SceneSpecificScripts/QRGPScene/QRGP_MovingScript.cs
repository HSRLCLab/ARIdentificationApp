/* -----------------------------------------------------------------------
	Date: 29.11.2018
	Comment: Move the virtual model arount if the positioning buttons were clicked.
            copy of positioningOptions.cs which does not work in this scene.
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRGP_MovingScript : MonoBehaviour {
    public GameObject ModelTarget;
    // Use this for initialization
    void Start () {
        Debug.Log("Test for positioning");
        Debug.Log("Position Imagetarget " + ModelTarget.transform.position);
        Debug.Log("Position Virtual Model " + transform.position);
        Debug.Log("Angle Imagetarget " + ModelTarget.transform.eulerAngles);
        Debug.Log("Angle Virtual Model " + transform.eulerAngles);
        Debug.Log("Position Differenece " + (ModelTarget.transform.position-transform.position));
        Debug.Log("Angle Difference " + (ModelTarget.transform.eulerAngles- transform.eulerAngles));
        Debug.Log("Position Vector distance " + Vector3.Distance(ModelTarget.transform.position, transform.position));
        
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(0, Time.deltaTime, 0, Space.World);
        
    }

    public void MoveUp()
    {
        // Move the object upward in world space 1 unit/second.

        //transform.Translate(0, Time.deltaTime, 0, Space.World);
        transform.Translate(0, Time.deltaTime, 0);
    }

    public void MoveDown()
    {
        // Move the object upward in world space 1 unit/second.
        transform.Translate(0, -Time.deltaTime, 0, Space.World);
    }

    public void MoveLeft()
    {
        // Move the object left in world space 1 unit/second.
        transform.Translate(-Time.deltaTime, 0, 0, Space.World);
    }

    public void MoveRight()
    {
        // Move the object right in world space 1 unit/second.
        transform.Translate(Time.deltaTime, 0, 0, Space.World);
    }

    public void MoveBack()
    {
        // Move the object away from viewer in world space 1 unit/second.
        transform.Translate(0, 0, Time.deltaTime, Space.World);
    }

    public void MoveForward()
    {
        // Move the object towards viewer in world space 1 unit/second.
        transform.Translate(0, 0, -Time.deltaTime, Space.World);
    }

    public void TurnLeftY()
    {
        // Rotate the object around the global Y axis at 10 degree per second
        transform.Rotate(0, -Time.deltaTime * 10, 0, Space.World);
    }

    public void TurnRightY()
    {
        // Rotate the object around the global Y axis at 10 degree per second counterclockwise
        transform.Rotate(0, Time.deltaTime * 10, 0, Space.World);
    }

    public void TurnLeftX()
    {
        // Rotate the object around the global X axis at 10 degree per second
        transform.Rotate(-Time.deltaTime * 10, 0, 0, Space.World);
    }

    public void TurnRightX()
    {
        // Rotate the object around the global X axis at 10 degree per second counterclockwise
        transform.Rotate(Time.deltaTime * 10, 0, 0, Space.World);
    }

    public void TurnLeftZ()
    {
        // Rotate the object around the global Z axis at 10 degree per second
        transform.Rotate(0, 0, Time.deltaTime * 10, Space.World);
    }

    public void TurnRightZ()
    {
        // Rotate the object around the global Z axis at 10 degree per second counterclockwise
        transform.Rotate(0, 0, -Time.deltaTime * 10, Space.World);
    }

    public void Reset()
    {
        //Reset the VirtualModel to it's initial position, or wherever the ModelTarget currently is
       // transform.eulerAngles = ModelTarget.transform.eulerAngles;
        //transform.position = ModelTarget.transform.position;

        transform.position = new Vector3(ModelTarget.transform.position.x - 0.1f, ModelTarget.transform.position.y + 0.1f, ModelTarget.transform.position.z);
        transform.eulerAngles = new Vector3(ModelTarget.transform.eulerAngles.x, ModelTarget.transform.eulerAngles.y + 90f, ModelTarget.transform.eulerAngles.z);
    }

}

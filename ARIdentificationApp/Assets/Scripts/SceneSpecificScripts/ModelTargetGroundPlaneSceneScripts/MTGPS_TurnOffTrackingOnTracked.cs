/* -----------------------------------------------------------------------
	Date: 22.11.2018
	Comment: Copied from the TurnOffTrackingOnTracked.cs from sample scene
            Specific script for ModelTargetGroundPlaneScene
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class MTGPS_TurnOffTrackingOnTracked : DefaultTrackableEventHandler
{
    public Text Debugtext;
    public GameObject WarningToggle;
    public GameObject WarningPanel;
    public GameObject ModelTarget;
    public GameObject GroundStage;
    public GameObject ModelGroundStage;
    public GameObject PlaneFinder;
    public GameObject ReadyCube;
    private bool firsttime = true;
    private int counter = 0;
    
    protected override void OnTrackingLost()
    {
        //TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        Debugtext.text += " MTGPS ModelTarget Tracking lost ";
    }
    /*
    //Stop tracking if the object was tracked
    protected override void OnTrackingFound() {
        Debugtext.text = " MTGPS ModelTarget Tracking found ";
        
        //only reposition it once
        if (firsttime)
        {
            //Get the Plane Finder
            PlaneFinderBehaviour myBehaviour = PlaneFinder.GetComponent<PlaneFinderBehaviour>();
            Debugtext.text = "Mybehaviour " + counter++ + " "+ myBehaviour.PlaneIndicator.GetComponent<MeshRenderer>().enabled;

            //Don't start tracking if Plane Finder isn't ready yet
            if (!myBehaviour.PlaneIndicator.GetComponent<MeshRenderer>().enabled)
            {
                Debugtext.text += " Not ready yet!! ";
                //Disable tracker again (otherwise the 3D guide will be hidden)
                ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                objectTracker.Stop();
                objectTracker.Start();
            }
            else {
                Debugtext.text += "Ready GroundModel " + ModelGroundStage.activeSelf;

                //Place the Virtual Model on the GroundStage where the ModelTarget was found if it isn't shown already
                if (!ModelGroundStage.GetComponentInChildren<MeshRenderer>().enabled)
                {
                    //Try to programmatically place the virtual model by triggering the PlaneFinder
                    Vector2 moreOrLessWhereModelTargetIs = new Vector2(ModelTarget.transform.position.x, ModelTarget.transform.position.y);
                    myBehaviour.PerformHitTest(moreOrLessWhereModelTargetIs);
                    if (WarningToggle.GetComponent<Toggle>())
                    {
                        WarningPanel.SetActive(true);
                    }

                }
                else {
                    ModelGroundStage.transform.position = ModelTarget.transform.position;
                }
                Debugtext.text += " MTGPS Move Model from " + ModelGroundStage.transform.position + " to " + ModelTarget.transform.position;
            
                
                ModelGroundStage.transform.eulerAngles = ModelTarget.transform.eulerAngles;
                //Test if model can be placed on the ground
                ModelGroundStage.transform.position = new Vector3(GroundStage.transform.position.x, ModelGroundStage.transform.position.y, ModelGroundStage.transform.position.z);
                firsttime = false;
            }

        }
    }*/

    //Stop tracking if the object was tracked
    protected override void OnTrackingFound()
    {
        Debugtext.text = " MTGPS ModelTarget Tracking found ";

        //only reposition it once
        if (firsttime)
        {
            //Get the Plane Finder
            PlaneFinderBehaviour myBehaviour = PlaneFinder.GetComponent<PlaneFinderBehaviour>();
            Debugtext.text = "Firsttime Let's place it! " + counter++ + " " + myBehaviour.PlaneIndicator.GetComponent<MeshRenderer>().enabled;


            Debugtext.text += "Ready GroundModel " + ModelGroundStage.activeSelf;
            //Tests Content Positioning behaviour
            //ContentPositioningBehaviour myContentBehaviour = PlaneFinder.GetComponent<ContentPositioningBehaviour>();
            //myContentBehaviour.PositionContentAtPlaneAnchor()


            //Try to programmatically place the virtual model by triggering the PlaneFinder
            Vector2 moreOrLessWhereModelTargetIs = new Vector2(ModelTarget.transform.position.x, ModelTarget.transform.position.y);
            myBehaviour.PerformHitTest(moreOrLessWhereModelTargetIs);
            
            
            //ModelGroundStage.transform.position = ModelTarget.transform.position;
            ModelGroundStage.transform.eulerAngles = ModelTarget.transform.eulerAngles;
            //Test if model can be placed on the ground
            ModelGroundStage.transform.position = new Vector3(GroundStage.transform.position.x, ModelGroundStage.transform.position.y, ModelGroundStage.transform.position.z);
            firsttime = false;


        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class QRGP_TrackableEventHandler : DefaultTrackableEventHandler
{
    private bool firsttime = true;
    public GameObject PlaneFinder;
    private int counter = 0;
    public GameObject imageTarget;
    public GameObject ModelGroundStage;
    public Text Debugtext;
    public GameObject virtualModel;

    /*
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
      
    }
    */

    //Reset variable firsttime, so the virtual model gets placed a second time (needed if the user first recognized the imagetarget befor the plane finder was ready)
    public void RestartTracking() {
        firsttime = true;
    }
    protected override void OnTrackingLost()
    {
        Debugtext.text = " QRGPS ModelTarget Tracking lost ";
        

    }
    //Stop tracking if the object was tracked
    protected override void OnTrackingFound()
    {
        Debugtext.text = " QRGPS ModelTarget Tracking found ";

        //only reposition it once
        if (firsttime)
        {
            //Get the Plane Finder
            PlaneFinderBehaviour myBehaviour = PlaneFinder.GetComponent<PlaneFinderBehaviour>();
            Debugtext.text = "Firsttime Let's place it! " + counter++ + " " + myBehaviour.PlaneIndicator.GetComponent<MeshRenderer>().enabled;


            //Debugtext.text += "Ready GroundModel " + ModelGroundStage.activeSelf;

            
            //Try to programmatically place the virtual model by triggering the PlaneFinder
            Vector2 moreOrLessWhereModelTargetIs = new Vector2(imageTarget.transform.position.x, imageTarget.transform.position.y);
            myBehaviour.PerformHitTest(moreOrLessWhereModelTargetIs);

            //virtualModel.transform.eulerAngles = new Vector3(imageTarget.transform.eulerAngles.x, imageTarget.transform.eulerAngles.y, 90f);
            //virtualModel.transform.eulerAngles = new Vector3(imageTarget.transform.eulerAngles.x, imageTarget.transform.eulerAngles.y - 90f, 90f);
            //virtualModel.transform.eulerAngles = new Vector3(imageTarget.transform.eulerAngles.x, imageTarget.transform.eulerAngles.y + 90f, 90f);



            Debugtext.text += "HitPlace " + moreOrLessWhereModelTargetIs;
            //ModelGroundStage.transform.position = ModelTarget.transform.position;
            //ModelGroundStage.transform.eulerAngles = imageTarget.transform.eulerAngles;

            /*
            //Test if model can be placed on the ground
            ModelGroundStage.transform.position = new Vector3(ModelGroundStage.transform.position.x, ModelGroundStage.transform.position.y, ModelGroundStage.transform.position.z);
            
            Vector2 moreOrLessWhereModelTargetIs = new Vector2(virtualModel.transform.position.x, virtualModel.transform.position.y);
            myBehaviour.PerformHitTest(moreOrLessWhereModelTargetIs);*/

            //place vitual model on the ground
            //virtualModel.transform.position = new Vector3(ModelGroundStage.transform.position.x, virtualModel.transform.position.y, virtualModel.transform.position.z);
            //and angle it like the groundplane
            //virtualModel.transform.eulerAngles = new Vector3(ModelGroundStage.transform.eulerAngles.x, ModelGroundStage.transform.eulerAngles.y, ModelGroundStage.transform.eulerAngles.z); //no change


            //Test based on Debug values in playmode: (place like imageTarget but with differences added) 
            /*Position Differenece (-0.1, 0.1, 0.0)
            Angle Difference(0.0, -90.0, 0.0)
            */
            /*
            virtualModel.transform.eulerAngles = new Vector3(imageTarget.transform.eulerAngles.x, imageTarget.transform.eulerAngles.y + 90f, imageTarget.transform.eulerAngles.z); //does no harm or change
            virtualModel.transform.position = new Vector3(imageTarget.transform.position.x-0.1f, imageTarget.transform.position.y+0.1f, imageTarget.transform.position.z);
            */
            //second try manually add (and place on the ground):
            //virtualModel.transform.position = new Vector3(imageTarget.transform.position.x+1.41f, imageTarget.transform.position.y - 0.5400001f, imageTarget.transform.position.z - 1.08f); // appears on the ground/floor
            //virtualModel.transform.position = new Vector3(ModelGroundStage.transform.position.x, imageTarget.transform.position.y - 0.5400001f, imageTarget.transform.position.z - 1.08f); // appears at: dunno

            /*
            //manually position the virtualModel
            virtualModel.transform.position = new Vector3(1.41f, -0.5400001f, -1.08f);
            virtualModel.transform.eulerAngles = new Vector3(0f, 0f, 90.00001f);
            //virtualModel.transform.localScale = new Vector3(18.90.59f, 18.90.59f, 18.90.59f);
            */
            /*
            //Test 04.12.2018
            virtualModel.transform.eulerAngles = imageTarget.transform.eulerAngles - new Vector3(0f, 0f, 90.00001f); //doesn't appear anymore
            virtualModel.transform.position = imageTarget.transform.position - new Vector3(1.41f, -0.5400001f, -1.08f);
            */
            /*
            //Test2 04.12.2018
            virtualModel.transform.eulerAngles = imageTarget.transform.eulerAngles + new Vector3(0.0f, -90.0f, 0.0f); //about 45 degrees away from real model
            virtualModel.transform.position = imageTarget.transform.position + new Vector3(-0.1f, 0.1f, 0.0f);
            */
            //Test 06.12.2018
            virtualModel.transform.eulerAngles = imageTarget.transform.eulerAngles + new Vector3(0.0f, -90.0f, 0.0f); //not on the ground, to far in the back, not correct angle
            virtualModel.transform.position = imageTarget.transform.position + new Vector3(-0.1f, 0.1f, 0.0f);

            firsttime = false;
            Debugtext.text += "PlacePlace " + virtualModel.transform.position;
            //ModelTargetBehaviour.GuideViewDisplayMode guideViewDisplayMode = GuideView3DBehaviour;
        }
    }


}

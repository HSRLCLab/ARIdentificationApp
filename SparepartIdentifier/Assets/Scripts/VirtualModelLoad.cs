/* -----------------------------------------------------------------------
	Date: 06.12.2018
	Comment: Functions on the VirtualModel itself like paint and show/hide it. 
            Copied from VirtualModelLoad.cs of the ARIdentificationApp.
    Last Updated: 11.12.2018 - removed all debuggingtexts, and cleanup of code
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualModelLoad : MonoBehaviour
{
    public GameObject virtualModel;
    public Material cyan;
    public Material blue;
    public Material magenta;
    public Material greyMaterial;
    public Material testmaterial;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start called");
        //paintVirtualModel();


    }

    // Update is called once per frame
    void Update()
    {

    }

    //Paint the virtual model (called from buttonclick)
    public void PaintVirtualModel()
    {
        //Go through all children and set a material if they have a mesh collider
        foreach (MeshRenderer component in virtualModel.GetComponentsInChildren<MeshRenderer>(true))
        {
            if (component.gameObject.GetComponent<MeshCollider>() == null) {
                component.gameObject.AddComponent<MeshCollider>();
            }
            
            var parent = component.transform.parent.gameObject;
            Material mymaterial;

            mymaterial = testmaterial;

            // Get color based on riskofFailure (only of the parts which have a "stuecklisten eintrag")
            if (parent.GetComponent<ItemComponent>().item != null) { 
                string failurerisk = parent.GetComponent<ItemComponent>().item.riskOfFailure;
                switch (failurerisk) {
                    case "blue":
                        mymaterial = blue;
                        break;
                    case "magenta":
                        mymaterial = magenta;
                        break;
                    case "cyan":
                        mymaterial = cyan;
                        break;
                    default:
                        mymaterial = component.material;
                        break;
                }
            }

            component.material = mymaterial;

        }

        //update the previous values as the have changed in the meantime
        virtualModel.GetComponentInParent<ComponentInfo>().updatePreviousValues(false);
    }

    //Hide and shows the virtual model
    public void HideVirtualModel(Toggle callingButton)
    {
        //Go through all children wîth mesh collider and disable or enable the mesh collider (make it invisible but still interactable)
        foreach (MeshRenderer component in virtualModel.GetComponentsInChildren<MeshRenderer>(true))
        {
            component.enabled = callingButton.isOn;
        }
        //update the previous values as they have changed in the meantime
        virtualModel.GetComponent<ComponentInfo>().updatePreviousValues(true);
    }
    
    //Set all components of the virtual model active again
    public void ShowVirtualModelAndAllChildren() {
        //Components with MeshCollider can be clicked and set inactive. GetComponentsInChildren must be true, to return the inactive gameobjects
        foreach (MeshCollider component in virtualModel.GetComponentsInChildren<MeshCollider>(true))
        {
            //Set Components active again, if they were set inactive trough the component hide button
            component.gameObject.SetActive(true);
            //The Mesh Renderer will be enabled in the HideVirtualModel which is called after this function
        }
       
    }
    
}
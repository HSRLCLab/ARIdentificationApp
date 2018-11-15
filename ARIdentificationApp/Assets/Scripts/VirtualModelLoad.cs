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
            //Debug.Log("Found a child " + component.gameObject.name);
            Debug.Log("Found a child with meshrenderer: " + component.gameObject.name);
            component.gameObject.AddComponent<MeshCollider>();
            Debug.Log("Found childs parent " + component.transform.parent.gameObject.name);
            var parent = component.transform.parent.gameObject.name;
            Material mymaterial;
            int numericparent = int.Parse(parent);
            if (numericparent % 3 == 0)
            {
                mymaterial = cyan;
            }
            else if (numericparent % 3 == 1)
            {
                mymaterial = magenta;
            }
            else
            {
                mymaterial = blue;
            }

            component.material = mymaterial;
        }
    }

    //Hide and shows the virtual model
    public void HideVirtualModel(Toggle callingButton)
    {
        //Go through all children wîth mesh collider and disable or enable the mesh collider (make it invisible but still interactable)
        foreach (MeshRenderer component in virtualModel.GetComponentsInChildren<MeshRenderer>())
        {
            component.enabled = callingButton.isOn;
        }
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
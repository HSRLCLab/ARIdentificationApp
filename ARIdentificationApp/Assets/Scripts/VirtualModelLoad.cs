using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualModelLoad : MonoBehaviour {
    public GameObject virtualModel;
    public Material cyan;
    public Material blue;
    public Material magenta;
	// Use this for initialization
	void Start () {
        Debug.Log("Start called");
        //paintVirtualModel();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Paint the virtual model (called from buttonclick)
    public void PaintVirtualModel() {

        //On load go through all children and set a material and a mesh collider
        foreach (MeshRenderer component in virtualModel.GetComponentsInChildren<MeshRenderer>())
        {
            //Debug.Log("Found a child " + component.gameObject.name);
            Debug.Log("Found a child with meshrenderer" + component.gameObject.name);
            component.gameObject.AddComponent<MeshCollider>();
            component.material = blue;
        }
    }
}

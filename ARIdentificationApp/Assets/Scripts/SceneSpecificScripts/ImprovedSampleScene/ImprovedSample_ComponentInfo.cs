﻿/* -----------------------------------------------------------------------
	Date: 30.11.2018
	Comment: Append the Stücklisteninformation to each Component.
            And show preview if a component/part was clicked and virtual model is hidden.
			Copied from ComponentInfo.
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImprovedSample_ComponentInfo : MonoBehaviour {
	public GameObject VirtualModellFirstChild; //In this example the gameObject called "12"
	public Material selectedMaterial;
    public GameObject ItemValues; //The object which contains the textboxes where the information of the clicked component shall be shown
    public Text Debuggtext;
    public GameObject Preview; //The Root of the 3D Guide which was provided by the Model Target Generator

    private int counter = 0;
    private GameObject child;
    private GameObject currentlySelected;
    private Material previousmaterial = null;
    private bool previousenabled = true;
    private GameObject currentPreview;
    // Use this for initialization
    void Start () {

        //Add an item to each component
        foreach (Component childMeshFilter in VirtualModellFirstChild.GetComponentsInChildren<MeshFilter>())
        {

            //Add MeshCollider if it doesn't have one yet
            child = childMeshFilter.gameObject;
            if (child.GetComponent<MeshCollider>() == null)
            {
                child.AddComponent<MeshCollider>();
                //AddMeshCollider collider = child.AddComponent<AddMeshCollider>();
                
                //collider.update1();
            }



            //Get the direct parent to add the item with the Stücklisteninformation there (if not already done so)
            GameObject itemGameObject = child.transform.parent.gameObject;
            if (itemGameObject.GetComponent<ItemComponent>() == null) { 
                //Set newly created item as child of the component, but first add ItemComponent (doesn't work otherwise)
                var ic = itemGameObject.AddComponent<ItemComponent>();
                //Add some information to the components that shall be clickable
                
                ic.item = ManualMapping(itemGameObject.name);
                
            }
            counter++;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform currentHit;
        //Clickevents on component
        if (Input.GetMouseButtonDown(0))
        {
            Debuggtext.text = "Mousedown ";
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debuggtext.text += "Hit " + hit.transform.name;

                currentHit = hit.transform;

                //Show components information (name, number description
                foreach (Text infotext in ItemValues.GetComponentsInChildren<Text>())
                {
                    if (infotext.name == "ItemValue1_Text")
                    {
                        infotext.text = currentHit.name;
                    }

                    Item currentItem = currentHit.GetComponentInParent<ItemComponent>().item;

                    if (currentItem != null)
                    {

                        if (infotext.name == "ItemValue2_Text")
                        {
                            infotext.text = currentItem.number;
                        }
                        else if (infotext.name == "ItemValue3_Text")
                        {
                            infotext.text = currentItem.description;
                        }
                    }
                    else
                    {
                        defaultComponentInfo();
                    }
                }

                //reset the previously selected component (only makes sense if previously another component was selected)
                if (previousmaterial != null && currentlySelected != null) {
                    // Change material of self and all siblings
                    foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>())
                    {
                        siblingAndSelf.material = previousmaterial;
                        //hide again if it was hidden before
                        siblingAndSelf.enabled = previousenabled;
                    }
                }

                //store the selected object in a global variable
                currentlySelected = currentHit.gameObject;
                previousmaterial = currentlySelected.GetComponentInChildren<MeshRenderer>().material;
                previousenabled = currentlySelected.GetComponentInChildren<MeshRenderer>().enabled;

                //Change material of self and all siblings
                /*
                foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>())
                {
                    siblingAndSelf.material = selectedMaterial;
                    siblingAndSelf.enabled = true; //show component even if it was previously not shown

                }
                */
                //Show the preview of this component ------- Improved SampleScene specific
                currentPreview = GameObject.Find(Preview.name + "/" + VirtualModellFirstChild.name + "/"+ currentlySelected.transform.parent.name);
                //Debug.Log("Current Preview " + currentPreview.name + " searched for " + Preview.name + "/" + currentlySelected.name);
                Debug.Log("Current Preview " +  " searched for " + Preview.name + "/" + VirtualModellFirstChild.name + "/" + currentlySelected.transform.parent.name);
                Debug.Log("Current Preview " + currentPreview.name);
                foreach (MeshRenderer preview in currentPreview.transform.parent.GetComponentsInChildren<MeshRenderer>(true))
                {
                    preview.enabled = true; //show component even if it was previously not shown
                    //preview.material = selectedMaterial;
                }
            }
            else
            {
                //reset previously selected
                if (currentlySelected != null)
                {
                    foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>())
                    {
                        siblingAndSelf.material = previousmaterial;
                        //hide again if it was hidden before
                        siblingAndSelf.enabled = previousenabled;
                    }
                }
                
                //Set the components menue to the default values
                defaultComponentInfo();
            }

        }
		
	}

    //Hide the currently selected component
    public void HideComponent()
    {
        Debuggtext.text += "CurrentlySelected to hide " + currentlySelected.name; 
        //Totally disable component to click component behind
        if (currentlySelected != null) {
            if (currentlySelected.activeInHierarchy)
            {
                //Disable currentlySelected and all its siblings (in case it still persists of multiple parts)
                foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>()) { 
                    siblingAndSelf.gameObject.SetActive(false);
                }
            }
            //Allow showing if component is still selected
            else {
                //Enable currentlySelected and all its siblings (in case it still persists of multiple parts)
                foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>())
                {
                    siblingAndSelf.gameObject.SetActive(true);
                }
            }
        }
    }

    void defaultComponentInfo() {
        //Set the components menue to the default values
        foreach (Text infotext in ItemValues.GetComponentsInChildren<Text>())
        {
            if (infotext.name == "ItemValue1_Text")
            {
                infotext.text = "Item Title";
            }
            else if (infotext.name == "ItemValue2_Text")
            {
                infotext.text = "Legoroboter";
            }
            else if (infotext.name == "ItemValue3_Text")
            {
                infotext.text = "Legoroboter";
            }
        }
    }

    //Special case if Show_All or Paint button was clicked
    public void updatePreviousValues(bool showall)
    {
        //previousmaterial = currentlySelected.GetComponentInChildren<MeshRenderer>().material;
        Debug.Log("Updateprevious called " + showall);

        //if all compnoents are shown, don't hide them
        if (showall)
        {
            previousenabled = true;
        }
        //if paint button was clicked, the material has changed
        else {
            Debug.Log("Previous " + previousmaterial);
            previousmaterial = currentlySelected.GetComponentInChildren<MeshRenderer>().material;
            Debug.Log("NewPrevious " + previousmaterial);
        }
    }

    //Import wasn't properly done, so there needs to be done some manual mapping
    Item ManualMapping(string name){
        /*
		0: Rechter Arm
		1: Linker Arm
		2: Armhalter
		3: Greifeinheit
		4: Grundhalter
		5: Greifer (hat „Solid“ als Child)
		6: Deckel Backpack
		7: ServoGrundhalter
		8: Greifer (hat „Solid“ als Child)
		9: Backpack
		10: GreiferServo
		11: ArmServo

        //Default initialisation
        Item item = new Item()
            {
                number = "Number: " + counter + ";",
                description = "Description of "
                 sparePartCode = grid[i][2],
                 servicePart = grid[i][3],
                 riskOfFailure = grid[i][4],
                 price = grid[i][5],
                 availability = grid[i][6],
                 materialnr = grid [i][7]
            };


		*/

        Item currentItem  = new Item();
		
		switch(name){
		case "5":
		case "8":
			currentItem.number = "45590-4198367";
			currentItem.description = "Greifer";
            currentItem.riskOfFailure = "blue";
            break;
		case "7":
			currentItem.number = "CAD-30008002";
			currentItem.description = "ServoGrundhalter";
            currentItem.riskOfFailure = "blue";
            break;
		case "10":
			currentItem.number = "CAD-30008004";
			currentItem.description = "GreiferServo";
            currentItem.riskOfFailure = "cyan";
            break;
		case "11":
			currentItem.number = "CAD-30008002";
			currentItem.description = "ArmServo";
            currentItem.riskOfFailure = "magenta";
            break;
        case "Akku":
            currentItem.number = "Keine CAD nummmer";
            currentItem.description = "Akku";
            currentItem.riskOfFailure = "magenta";
            break;
        default:
			currentItem = null;
            break;
		}
		
		return currentItem;
		
	}
}

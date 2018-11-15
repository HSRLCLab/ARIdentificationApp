/* -----------------------------------------------------------------------
	Date: 13.11.2018
	Comment: Append the Stücklisteninformation to each Component.
			Some parts copied from DemoStart.cs and Stueckliste.cs 
			from Pickerzelle_V1.5_3 of BA from Simon Hersche 2017.
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentInfo : MonoBehaviour {
	public GameObject VirtualModellFirstChild; //In this example the gameObject called "12"
	public Material selectedMaterial;
    public GameObject ItemValues; //The object which contains the textboxes where the information of the clicked component shall be shown
    public Text Debuggtext;

    private int counter = 0;
    private GameObject child;
    private GameObject currentlySelected;
    private Material previousmaterial = null;
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
				//child.AddComponent<InputBehavior>();
				//collider.update1();
			}

                
			
			//Get the direct parent to add the item with the Stücklisteninformation there
			GameObject itemGameObject = child.transform.parent.gameObject;

            

            //Set newly created item as child of the component, but first add ItemComponent (doesn't work otherwise)
            var ic = itemGameObject.AddComponent<ItemComponent>();
            //Add some information to the components that shall be clickable
            ic.item = ManualMapping(itemGameObject.name);

            counter++;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform currentHit;
        //Clickevents on component
        if (Input.GetMouseButtonDown(0))
        {
            Debuggtext.text += "Mousedown ";
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debuggtext.text += "Hit " + hit.transform.name;


                //Change material
                //hit.transform.GetComponentInChildren<MeshRenderer>().material = greyMaterial;
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
                        //currentlySelected.GetComponentInChildren<MeshRenderer>().material = previousmaterial;
                    }
                }
                //store the selected object in a global variable
                currentlySelected = currentHit.gameObject;
                previousmaterial = currentlySelected.GetComponentInChildren<MeshRenderer>().material;
                //Change material of self and all siblings
                foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>())
                {
                    siblingAndSelf.material = selectedMaterial;
                    //currentlySelected.GetComponentInChildren<MeshRenderer>().material = selectedMaterial;
                }
            }
            else
            {
                //TODO: If the disable button was clicked, the component shall not be unselected

                //reset previously selected
                if (currentlySelected != null)
                {
                    foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>())
                    {
                        siblingAndSelf.material = previousmaterial;
                        //currentlySelected.GetComponentInChildren<MeshRenderer>().material = previousmaterial;
                    }
                }
                /*
                currentlySelected = null;
                previousmaterial = null;
                */
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
                //currentlySelected.SetActive(false);
                //Disable currentlySelected and all its siblings (in case it still persists of multiple parts)
                foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>()) { 
                    siblingAndSelf.gameObject.SetActive(false);
                }
            }
            //Allow showing if component is still selected
            else {
                //currentlySelected.SetActive(true);
                //Enable currentlySelected and all its siblings (in case it still persists of multiple parts)
                foreach (MeshRenderer siblingAndSelf in currentlySelected.transform.parent.GetComponentsInChildren<MeshRenderer>())
                {
                    siblingAndSelf.gameObject.SetActive(true);
                }
                //currentlySelected.transform.parent.GetComponentInChildren<MeshRenderer>().gameObject.SetActive(true);
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
			break;
		case "7":
			currentItem.number = "CAD-30008002";
			currentItem.description = "ServoGrundhalter";
			break;
		case "10":
			currentItem.number = "CAD-30008004";
			currentItem.description = "GreiferServo";
			break;
		case "11":
			currentItem.number = "CAD-30008002";
			currentItem.description = "ArmServo";
			break;
        default:
			currentItem = null;
            break;
		}
		
		return currentItem;
		
	}
}

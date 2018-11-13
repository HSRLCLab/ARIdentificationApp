using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentInfo : MonoBehaviour {
	public GameObject VirtualModellFirstChild;
	
	private int counter = 0;
	// Use this for initialization
	void Start () {
		//Add an item to each component
		foreach (Transform component in VirtualModellFirstChild.GetComponentsInChildren<Transform>())
        {
			//Only get the first level children
			if(component.parent == VirtualModellFirstChild){
				Item item = new Item(){
                    number = "Number: " + counter + ";",
                    description = "Description of "
                   /* sparePartCode = grid[i][2],
                    servicePart = grid[i][3],
                    riskOfFailure = grid[i][4],
                    price = grid[i][5],
                    availability = grid[i][6],
                    materialnr = grid [i][7]*/
                };
				//component.gameObject.add(item.number, item);
				//Set newly created item as child of the component
				item.parent = component.gameObject;
				counter++;
			}
		}
		//Add some information to the components that shall be clickable
		ManualMapping();
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		//Clickevents on component
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == myComponent.name)
                {

		
		*/
	}
	
	//Import wasn't properly done, so there needs to be done some manual mapping
	void ManualMapping(){
		/*
		: Rechter Arm
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

		*/
		
	}
}

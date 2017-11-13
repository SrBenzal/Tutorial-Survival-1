using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	// Variables
	public bool inventoryEnabled;
	public GameObject inventory;
	public GameObject itemDatabase;
	public GameObject slotHolder;

	private Transform[] slot;
	private bool pickedupItem;
	private int maxInventory;

	//Functions

	public void Start(){
		GetAllSlots ();
	}

	public void Update(){
		//Inventory Enable & Disable
		if (Input.GetKeyDown(KeyCode.I)) {
			inventoryEnabled=!inventoryEnabled;
		}
		if (inventoryEnabled) {
			inventory.SetActive (true);
		} else {
			inventory.SetActive (false);
		}
	}


	public void OnTriggerEnter(Collider other){
		if (other.tag=="Item") {
			//print ("Item triggered");
			AddItem(other.gameObject);
		}
	}

	public void AddItem(GameObject item){
		if (item.GetComponent<ItemPickup>().craftMaterial == false) {
			GameObject rootItem;
			rootItem = item.GetComponent<ItemPickup> ().rootItem;

			for (int i = 0; i < maxInventory; i++) {
				if (slot[i].GetComponent<Slot>().empty ==true && item.GetComponent<ItemPickup>().pickedUp == false) {
					slot [i].GetComponent<Slot> ().item = rootItem;
					item.GetComponent<ItemPickup> ().pickedUp = true;
					Destroy (item);
				}
			}

		} else {
			for (int i = 0; i < maxInventory; i++) {
				if (slot[i].GetComponent<Slot>().empty ==true && item.GetComponent<ItemPickup>().pickedUp == false) {
					slot [i].GetComponent<Slot> ().item = item;
					item.GetComponent<ItemPickup> ().pickedUp = true;
					item.transform.parent = itemDatabase.transform;
				
					item.GetComponent<MeshRenderer> ().enabled = false;
					Destroy(item.GetComponent<Rigidbody>());
				}
			}
		}
	}

	public void GetAllSlots(){
		maxInventory = slotHolder.transform.childCount;

		slot = new Transform[maxInventory];
		for (int i = 0; i < maxInventory; i++) {
			slot [i] = slotHolder.transform.GetChild (i);
			//print (slot [i].name);
		}
	}
}

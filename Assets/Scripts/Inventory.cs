using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	// Variables
	public bool inventoryEnabled;
	public GameObject inventory;
	public GameObject itemDatabase;
	public GameObject slotHolder;
	public Text rockCountText, woodCountText;

	private Transform[] slot;
	private bool pickedupItem;
	private int maxInventory;
	private int rockCount = 0, woodCount = 0;
	private bool isItemTriggered=false;
	private GameObject itemTriggered;
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
		if (isItemTriggered && Input.GetKeyDown(KeyCode.E)) {
            GetComponent<CameraManager>().onSelection = true;
            GetComponent<CameraManager>().chooseMoveiment();
            print (itemTriggered.name);
			AddItem (itemTriggered);
		}
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag=="Item") {
			isItemTriggered=true;
			itemTriggered = other.gameObject;
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.tag=="Item") {
			isItemTriggered=false;
			itemTriggered = null;
		}
	}


	public void AddItem(GameObject item){
		if (item.GetComponent<ItemPickup>().craftMaterial == false) {
			print ("test");
			GameObject rootItem;
			rootItem = item.GetComponent<ItemPickup> ().rootItem;
			print (rootItem.name);
			for (int i = 0; i < maxInventory; i++) {
				if (slot[i].GetComponent<Slot>().empty ==true && item.GetComponent<ItemPickup>().pickedUp == false) {
					slot [i].GetComponent<Slot> ().item = rootItem;
					item.GetComponent<ItemPickup> ().pickedUp = true;
					Destroy (item);
				}
			}

		} else {/*
			for (int i = 0; i < maxInventory; i++) {
				if (slot[i].GetComponent<Slot>().empty ==true && item.GetComponent<ItemPickup>().pickedUp == false) {
					slot [i].GetComponent<Slot> ().item = item;
					item.GetComponent<ItemPickup> ().pickedUp = true;
					item.transform.parent = itemDatabase.transform;
				
					item.GetComponent<MeshRenderer> ().enabled = false;
					Destroy(item.GetComponent<Rigidbody>());
				}
			}*/
			switch (item.GetComponent<Item>().type) {
			default:
				break;
			case Item.Type.Rock:
				rockCount += 1;
				break;
			case Item.Type.Wood:
				woodCount += 1;
				break;
			}
			UpdateCount ();
			Destroy (item);
		}
		itemTriggered=null;
		isItemTriggered = false;

	}

	public void UpdateCount(){
		rockCountText.text = rockCount.ToString();
		woodCountText.text = woodCount.ToString();
	}

	public void GetAllSlots(){
		maxInventory = slotHolder.transform.childCount;

		slot = new Transform[maxInventory];
		for (int i = 0; i < maxInventory; i++) {
			slot [i] = slotHolder.transform.GetChild (i);
			//print (slot [i].name);
		}
	}

	public int getRocks(){
		return rockCount;
	}
    //added
    public GameObject getItemTriggered() { 
        if (isItemTriggered)
                return itemTriggered;
        return null;
    }

	public int getWood(){
		return woodCount;
	}

	public void setRocks(int rocks){
		rockCount = rocks;
	}

	public void setWood(int wood){
		woodCount = wood;
	}
}

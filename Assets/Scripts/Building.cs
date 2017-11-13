using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	//Variables
	public int rockNeeded,woodNeeded;
	public GameObject campfire;

	private int rockCount, woodCount;
	//private Vector3 buildPosition = this.transform.position + new Vector3(0,0,5);
	//Functions
	public void Start () {
		rockCount = this.GetComponent<Inventory> ().getRocks ();
		woodCount = this.GetComponent<Inventory> ().getWood ();
	}

	public void Update(){
		if (Input.GetKeyDown(KeyCode.C)) {
			updateCount ();
			buildCampfire ();
		}
	}

	public void buildCampfire(){
		bool enoughRocks = false, enoughWood = false;
		if (rockCount < rockNeeded) {
			print("You need " + (rockNeeded - rockCount).ToString() + " rocks to build the campfire.");
		} else {
			enoughRocks = true;
		}
		if (woodCount < woodNeeded) {
			print ("You need " + (woodNeeded - woodCount).ToString() + " wood to build the campfire.");
		} else {
			enoughWood = true;
		}
		if (enoughWood&&enoughRocks) {
			this.GetComponent<Inventory> ().setRocks (rockCount - rockNeeded);
			this.GetComponent<Inventory> ().setWood (woodCount - woodNeeded);
			this.GetComponent<Inventory> ().UpdateCount ();
			updateCount ();
			print ("Time to spawn a campfire");
			Instantiate (campfire,new Vector3(this.transform.position.x, 0.5f, this.transform.position.z) + transform.forward * 5,Quaternion.identity);
		}
	}

	void updateCount(){
		rockCount = this.GetComponent<Inventory> ().getRocks ();
		woodCount = this.GetComponent<Inventory> ().getWood ();
	}
}

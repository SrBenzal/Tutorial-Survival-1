using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Variables
	public float maxHunger, maxThirst, maxHealth;
	private float hunger, thirst, health;

	public float hungerIncrease, thirstIncrease;
	private bool triggeringTree = false;
	private GameObject tree;
	public static bool weaponEquiped;
	//Functions

	void Start(){
		health = maxHealth;

	}

	void Update(){

		//thirst and hunger
		HungerAndThirst();
		if (health<=0) {
			Die ();
		}

		//Triggering with tree and chopping it
		if (triggeringTree==true && weaponEquiped) {
			//Attacking the tree
			if(Input.GetMouseButtonDown(0)){
				if (tree) {
					tree.GetComponent<Tree> ().currentHealth -= 25;
				}
			}
			//print ("Triggering with tree");
		}
		//print(hunger + " " + thirst);
	}

	public void HungerAndThirst(){

		hunger += hungerIncrease * Time.deltaTime;
		thirst += thirstIncrease * Time.deltaTime;

		if (hunger>maxHunger) {
			Die ();
		}

		if (thirst>maxThirst) {
			Die ();
		}
	}

	public void Die(){
		print ("Player is DEAD");
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag == "Tree") {
			triggeringTree = true;
			tree = other.gameObject;
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.tag == "Tree") {
			triggeringTree = false;
			tree = null;
		}
	}
}

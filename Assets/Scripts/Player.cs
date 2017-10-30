using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Variables
	public float maxHunger, maxThirst, maxHealth;
	private float hunger, thirst, health;

	public float hungerIncrease, thirstIncrease;


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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	//Variables

	public int treeHealth;
	public int currentHealth;

	public int amountOfItems;
	public GameObject[] itemTable;
	private bool itemsDropped;
	//Functions

	// Use this for initialization
	void Start () {
		currentHealth = treeHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth<=0) {
			for (int i = 0; i < amountOfItems; i++) {
				Instantiate (itemTable [i].transform,this.transform.position,Quaternion.identity);
				if (i==(amountOfItems-1)) {
					itemsDropped = true;
				}
			}
		}
		if (itemsDropped==true) {
			Destroy (this.gameObject);
		}
	}
}

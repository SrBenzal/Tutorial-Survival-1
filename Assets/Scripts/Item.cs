using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


	//Variables
	public Texture itemTexture;
	public bool craftMaterial;

	//Functions
	void Start () {
		
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.F) && !craftMaterial) {
			this.gameObject.SetActive(false);
			Player.weaponEquiped = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


	//Variables
	public Texture itemTexture;
	public bool craftMaterial;
	//Functions

	public enum Type{
		Rock,
		Wood
	};

	public Type type;

	void Start () {
		switch (this.tag) {
		default:
			break;

		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.F) && !craftMaterial) {
			this.gameObject.SetActive(false);
			Player.weaponEquiped = false;
		}
	}
}

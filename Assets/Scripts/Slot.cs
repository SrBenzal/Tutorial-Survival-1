using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {

	//Variables

	public bool empty;
	public Texture slotTexture;
	public Texture itemTexture;
	public GameObject item;

	private GameObject player;
	//Functions

	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	void Update () {
		//To change texture in inventory
		if (item) {
			itemTexture = item.GetComponent<Item> ().itemTexture;
			this.GetComponent<RawImage> ().texture = itemTexture;
			empty = false;
		} else {
			this.GetComponent<RawImage> ().texture = slotTexture;
			empty = true;
		}
	}

	public void OnPointerDown(PointerEventData eventData){
		if (item) {
			//print (item.name);
			item.SetActive(true);
			Player.weaponEquiped = true;
		}
	}

	public void OnPointerEnter(PointerEventData eventData){
		
	}
}

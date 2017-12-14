using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour {
 
    public GameObject item;
    public GameObject player; 
    private Vector3 offset;
    private Direccion move;
    public bool onSelection;

    public enum Direccion
    {
        Izquierda,
        Derecha,
        Arriba
    }

	// Use this for initialization
	void Start ()
    {
        offset = transform.position;
        onSelection = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
       item = GetComponent<Inventory>().getItemTriggered();
       chooseMoveiment(); 
	}

    IEnumerator MoveCamera()
    {   
        yield return null;
    }

    public void chooseMoveiment()
    {
        if (onSelection)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                move = Direccion.Arriba;
                onSelection = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                move = Direccion.Derecha;
                onSelection = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                move = Direccion.Izquierda;
                onSelection = false;
            }
        }
    }
    
}

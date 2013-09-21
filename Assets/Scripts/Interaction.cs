using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class Interaction : MonoBehaviour {
	
	// Information sur la collision
	RaycastHit hitinfo;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)
			&& Physics.Raycast(this.camera.ScreenPointToRay(Input.mousePosition), out hitinfo)) {
			InteracDoor door = hitinfo.collider.gameObject.GetComponent<InteracDoor>() as InteracDoor;
			if (door != null)
				door.toggleDoor();
		}
	}
}

using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	
	public InteracDoor linkedDoor;
	
	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player")
			linkedDoor.toggleDoor();
	}
	
	void OnTriggerExit(Collider coll) {
		if (coll.tag == "Player")
			linkedDoor.toggleDoor();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

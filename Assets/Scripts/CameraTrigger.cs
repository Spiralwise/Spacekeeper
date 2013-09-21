using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {
	
	public CameraManager camMan;
	public Camera linkedCamera;
	
	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player")
			camMan.changeCamera(linkedCamera);
	}
}

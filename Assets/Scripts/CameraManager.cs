using UnityEngine;
using System.Collections;

/**
 * Camera Manager is used to manage several camera in the scene.
 * A camera is enabled when the player encounters its associated trigger.
 */
public class CameraManager : MonoBehaviour {
	
	public Camera activeCamera;
	
	// Use this for initialization
	void Start () {
		activeCamera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void changeCamera(Camera newCamera) {
		Debug.Log("Change camera (" + newCamera + ")");
		//activeCamera.tag = "Untagged";
		activeCamera.enabled = false;
		activeCamera = newCamera;
		//activeCamera.tag = "MainCamera";
		activeCamera.enabled = true;
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(AudioSource))]

public class InteracDoor : MonoBehaviour {
	
	private string myState;
	
	void Start() {
		myState = "closed";
	}
	
	public void setState(string state) {
		//Debug.Log("Door state:" + state);
		myState = state;
	}
	
	public string getState() {
		return myState;
	}
	
	public void toggleDoor() {
		if (myState.Equals("opened")) {
			this.audio.Play();
			this.gameObject.animation.Play("DoorClose");
		}
		if (myState.Equals("closed")) {
			this.audio.Play();
			this.gameObject.animation.Play("DoorAnim");
		}
	}
}

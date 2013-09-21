using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(BoxCollider))]
public class DoorBehavior : MonoBehaviour {
	public enum DoorState
	{
		Open,
		Closed,
		Closing,
		Opening
	};
	
	public DoorState state_=DoorState.Closed;
	
	void Start () {
		state_=DoorState.Closed;
	}
	
	void Update(){
	}
	
	public void SetOpen(){
		state_=DoorState.Open;
	}

	public void SetClosed(){
		state_=DoorState.Closed;
		
	}

	void OnMouseDown(){
		switch(state_){
			case DoorState.Closed:
				state_=DoorState.Opening;
				animation.Play("door-open");
				return;
			case DoorState.Open:
				animation.Play("door-close");
				return;
			default:
				return;
		}		
	}
}

using UnityEngine;
using System.Collections;

public class SeqFinal_Animation : MonoBehaviour {
	
	public InteracDoor door;
	public Light light;
	public Light turretEyeLight;
	public AudioClip boom, hello;
	
	// Use this for initialization
	void Start () {
		light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void openDoor() {
		door.toggleDoor();
	}
	
	void switchLight() {
		light.animation.Play ("LightSlowOn");
		light.enabled = true;
		audio.PlayOneShot(hello);
		
		GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>() as GameManager;
		manager.setTerminated();
	}
	
	void openTheEye() {
		audio.PlayOneShot(boom);
		turretEyeLight.animation.Play("idont8u");
	}
}

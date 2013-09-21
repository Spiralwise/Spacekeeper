using UnityEngine;
using System.Collections;

public class SeqFinal : MonoBehaviour {
	
	public CameraManager cameraManager;
	public Camera animatedCamera;
	public AudioClip extroMusic;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider coll) {
		InteracChar player = GameObject.FindGameObjectWithTag("Player").GetComponent<InteracChar>();
		if (player!=null) {
			player.pause();
			player.audio.Stop();
			player.audio.PlayOneShot(extroMusic);
		}
		cameraManager.changeCamera(animatedCamera);
		animatedCamera.animation.Play();
	}
}

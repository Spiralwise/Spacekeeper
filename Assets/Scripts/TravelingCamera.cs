using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class TravelingCamera : MonoBehaviour {
	
	public GameObject target;
	private GameObject source;
	
	public float playerDistance;
	private float distance;
	
	public bool lookat;
	
	private static GameObject player;
		
	// Use this for initialization
	void Start () {
		source = new GameObject(this.name + "_source");
		source.transform.position = this.gameObject.transform.position;
		source.transform.rotation = this.gameObject.transform.rotation;
		distance = Vector3.Distance( source.transform.position, target.transform.position );
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float t, d;
		Plane cameraPlane = new Plane(source.transform.forward, player.transform.position);
		
		if ( cameraPlane.Raycast( new Ray(source.transform.position, source.transform.forward), out d ) ) {
			t = (d - playerDistance) /distance;
			if (t < 0.0f) t = 0.0f;
			else if (t > 1.0f) t = 1.0f;
			this.transform.position = source.transform.position *(1.0f-t) + target.transform.position *t;
		}
		if (lookat)
			this.camera.transform.LookAt(player.transform, Vector3.up);
	}
}

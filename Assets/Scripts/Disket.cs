using UnityEngine;
using System.Collections;

public class Disket : MonoBehaviour {
	
	
	private float speed = 50.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate( new Vector3(0.0f, 1.0f, 0.0f), Time.deltaTime *speed );
	}
	
	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player") {
			InteracChar player = coll.GetComponent<InteracChar>() as InteracChar;
			player.playGetKeySound();
			GameManager.diskets--;
			Destroy(this.gameObject);
		}
	}
}

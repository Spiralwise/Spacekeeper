using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]

public class InteracChar : MonoBehaviour {
	
	private CharacterController cc;
	public float speed    = 160.0f;
	public float rotSpeed = 80.0f;
	public float interactiveDistance = 1.0f;
	public float interactiveCone = 1.0f;
	public AudioClip[] stepSounds;
	public AudioClip getKeySound;
	private Vector3 interactiveHeight = new Vector3(0.0f,1.0f,0.0f);
	
	private RaycastHit hitinfo;
	private InteracObject interactiveObject;
	private bool canPlay, isMoving, isRunning;
	
	//private bool bMoving;
	
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		interactiveObject = null;
		canPlay = true;
		isMoving = false;
		isRunning = false;
			
		animation.Play("soldierIdleRelaxed");
	}
	
	// Update is called once per frame
	void Update () {
		if (canPlay) {
			// Interaction with props
				// Interactive object found
			//if ( Physics.Raycast( new Ray(cc.transform.position +interactiveHeight, cc.transform.forward), out hitinfo, interactiveDistance ) ) {
			if ( Physics.SphereCast( new Ray(cc.transform.position +interactiveHeight, cc.transform.forward), interactiveCone, out hitinfo, interactiveDistance ) ) {
				InteracObject newObject = hitinfo.collider.gameObject.GetComponent<InteracObject>() as InteracObject;
				if (newObject != interactiveObject && interactiveObject != null)
					interactiveObject.setSelected(false);
				else if (newObject != null)
					newObject.setSelected(true);
				interactiveObject = newObject;
			}
				// Interactive object not found
			else if (interactiveObject != null) {
				interactiveObject.setSelected(false);
				interactiveObject = null;
			}
			
			if (Input.GetKeyDown(KeyCode.Space)
				&& interactiveObject != null)
				interactiveObject.toggle();
			
			
			
			// Animation
				// Running
			if (Input.GetKeyDown(KeyCode.LeftShift)) {
				isRunning = true;
				if (isMoving)
					animation.CrossFade("soldierRun");
			}
			else if (Input.GetKeyUp(KeyCode.LeftShift)) {
				isRunning = false;
				if (isMoving)
					animation.CrossFade("soldierWalk");
			}
				// Moving
			if (Input.GetKeyDown(KeyCode.Z)) {
				if (isRunning)
					animation.CrossFade("soldierRun");
				else
					animation.CrossFade("soldierWalk");
				isMoving = true;
			}
			else if (Input.GetKeyUp(KeyCode.Z)) {
				isMoving = false;
				animation.CrossFade("soldierIdleRelaxed");
			}
			
			// Input
			if (Input.GetKey(KeyCode.Z)) {
				if (isRunning)
					cc.SimpleMove(transform.forward * speed*2 * Time.deltaTime);
				else
					cc.SimpleMove(transform.forward * speed * Time.deltaTime); // Time.deltaTime permet de passer en temps relative et non en temps processeur.
			}
			else if (Input.GetKey(KeyCode.S))
				cc.SimpleMove(transform.forward * (-speed) * Time.deltaTime); // transform.forward = prend le repère monde de l'objet concerné
			if (Input.GetKey (KeyCode.Q))
				transform.Rotate(Vector3.up * (-rotSpeed) * Time.deltaTime); // Rotate se fait dans le sens horaire.
			else if (Input.GetKey (KeyCode.D))
				transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
		}
	}
	
	public void play() {
		canPlay = true;
	}
	
	public void pause() {
		animation.CrossFade("soldierIdleRelaxed");
		canPlay = false;
	}
	
	public bool isPaused() {
		return !canPlay;
	}
	
	public void playStepSound() {
		int id = Mathf.FloorToInt( Random.value *stepSounds.Length );
		audio.PlayOneShot(stepSounds[id], 0.2f);
	}
	
	public void playGetKeySound() {
		audio.PlayOneShot(getKeySound, 0.2f);
	}
}

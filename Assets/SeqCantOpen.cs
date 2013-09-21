using UnityEngine;
using System.Collections;

/**
 * Note : Pas eu le temps d'en faire une classe à part, plus propre.
 **/
public class SeqCantOpen : MonoBehaviour {
	
	public float timeBeforeCanTriggerAgain;
	public string messageToDisplay;
	public float timeToDisplay;
	
	private GameManager manager;
	private float remainingTime;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>() as GameManager;
		remainingTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (remainingTime > 0.0f)
			remainingTime -= Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider coll) {
		if (remainingTime <= 0.0f
			&& !manager.gameFinished()) {
			remainingTime = timeBeforeCanTriggerAgain;
			manager.displayMessage(messageToDisplay, timeToDisplay);
		}
	}
}

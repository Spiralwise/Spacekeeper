using UnityEngine;
using System.Collections;

public class InteracObject : MonoBehaviour {
	
	public Behaviour [] target;
	public InteracDoor door;
	public ParticleSystem linkedParticleSystem;
	public Texture selectionIcon;
	
	private Shader regularShader, selectedShader;
	
	private bool isSelected;
	
	// Use this for initialization
	void Start () {
		regularShader = Shader.Find("Diffuse");
		selectedShader = Shader.Find("FX/Flare");
		this.isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setSelected(bool s) {
		if (s) this.renderer.material.shader = selectedShader;
		else this.renderer.material.shader = regularShader;
		this.isSelected = s;
	}
	
	public void toggle() {
		if (this.GetComponent<AudioSource>() != null)
			this.audio.Play();
		foreach (Behaviour t in target)
			t.enabled = !t.enabled;
		if (door != null)
			door.toggleDoor();
		if (linkedParticleSystem != null) {
			if (linkedParticleSystem.isPlaying)
				linkedParticleSystem.Stop();
			else
				linkedParticleSystem.Play();
		}
	}
	
	void OnGUI() {
		if (this.isSelected) {
			Vector3 screenPosition = Camera.current.WorldToScreenPoint(this.transform.position); // TODO Génère un NullPointerException mais je ne sais pas trop pourquoi encore.
			GUI.DrawTexture( new Rect(screenPosition.x -64, Screen.height - screenPosition.y -64, 128, 128), selectionIcon );
		}
	}
}

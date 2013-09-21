using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static int diskets;
	public InteracDoor exitDoor;
	public Light exitLight;
	public GUISkin skin;
	public string briefing; 
	public GUIText message;
	public Texture2D controls, floppyIcon;
	
	private InteracChar player;
	private bool start_game, end_game, terminated;
	private int diskets_total;
	private float display_time;
	
	// Use this for initialization
	void Start () {
		GameObject[] disketList = GameObject.FindGameObjectsWithTag("Disket");
		diskets 		= disketList.Length;
		diskets_total 	= diskets;
		player 			= GameObject.FindGameObjectWithTag("Player").GetComponent<InteracChar>() as InteracChar;
		start_game 		= true;
		end_game 		= false;
		terminated 		= false;
	}
	
	// Update is called once per frame
	void Update () {
		// Affichage d'un message popup
		if (display_time > 0.0f) {
			display_time -= Time.deltaTime;
			if (display_time < 0.0f) clearMessage();
		}
		// Comptage des clefs (disquettes) récupérées
		if (diskets == 0
			&& end_game == false) {
			displayMessage("Le secteur A est accessible.", 4.0f);
			end_game = true;
			exitDoor.toggleDoor();
			exitLight.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
		}
	}
	
	/* Gestion du GUI */
	void OnGUI() {
		Rect allScreen = new Rect(0, 0, Screen.width, Screen.height);
		if (start_game) {
			player.pause();
			/*GUILayout.BeginArea(allScreen);
				GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUI.Box(new Rect(100,100,100,100), "Mission 1");
					GUILayout.BeginVertical(skin.FindStyle("intro"));
						GUILayout.FlexibleSpace();
						GUILayout.Label("Ramassez toutes les disquettes.");
						if (GUILayout.Button("START")) {
							start_game = false;
							player.play();
						}
						GUILayout.FlexibleSpace();
					GUILayout.EndVertical();
					GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			GUILayout.EndArea();*/
			Rect winRect = new Rect(Mathf.RoundToInt( (Screen.width-300) /2 ), 
									100, 
									300, 
									420);
			GUI.Window(0, winRect, DoMyWindow, "Evacuation de la base", skin.GetStyle("window") );
		}
		else if (terminated) {
			Rect winRect = new Rect(Mathf.RoundToInt( (Screen.width-200) /2 ), 
									100, 
									200, 
									320);
			GUI.Window(0, winRect, DoMyTerminatedWindow, "ERROR://Cake_is_a_lie", skin.GetStyle("window") );
		}
		else if (!player.isPaused()) {
			/*GUI.Label(allScreen, diskets.ToString(), skin.FindStyle("unilol"));
			GUI.Label(allScreen, floppyIcon, skin.FindStyle("unicon"));*/
			GUILayout.BeginArea(allScreen);
				GUILayout.FlexibleSpace();
				//GUILayout.BeginHorizontal("box");
				GUILayout.BeginHorizontal(skin.FindStyle("margin"));
					GUILayout.FlexibleSpace();
					GUILayout.Label((diskets_total-diskets).ToString() + "/" + diskets_total.ToString(), skin.FindStyle("unilol"));
					GUILayout.Label(floppyIcon, skin.FindStyle("unilol"));
				GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
	}

	void DoMyWindow(int winID) {
		GUIStyle winStyle = skin.FindStyle("intro");
		GUILayout.BeginVertical(winStyle);
			GUILayout.Label(briefing, winStyle);
			GUILayout.Label (controls, winStyle);
			//GUILayout.FlexibleSpace();
			if ( GUILayout.Button("START", skin.GetStyle("Button")) ) {
				start_game = false;
				player.play();
			}
		GUILayout.EndVertical();
	}
	
	void DoMyTerminatedWindow(int winID) {
		GUIStyle winStyle = skin.FindStyle("intro");
		GUILayout.BeginVertical(winStyle);
			GUILayout.Label("Depuis le dabut, le gateau etait un mensonge...", winStyle);
			GUILayout.FlexibleSpace();
			if ( GUILayout.Button("Fin", skin.GetStyle("Button")) ) {
				Application.Quit();
			}
		GUILayout.EndVertical();
	}
	
	/* Gestion des messages popup */
	public void displayMessage(string msg, float time) {
		display_time = time;
		message.text = msg;
		message.enabled = true;
	}
	
	private void clearMessage() {
		message.enabled = false;
	}
	
	public bool gameFinished() {
		return end_game;
	}
	
	public void setTerminated() {
		terminated = true;
	}
}
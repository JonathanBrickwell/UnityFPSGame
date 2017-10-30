using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float speed = 10.0f;
	private bool hasKey = false;
	public string message;
	private bool display = false;
	GUIStyle style = new GUIStyle();
	public GameObject doors;
	public GameObject key;
	// Use this for initialization
	void Start () {

		Cursor.lockState = CursorLockMode.Locked;

		style.fontSize = 40;
		style.normal.textColor = Color.red;
		style.alignment = TextAnchor.UpperCenter;

	}
	
	// Update is called once per frame
	void Update () {

		AudioSource audio = GetComponent<AudioSource> ();

		float micanje = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		micanje *= Time.deltaTime;
		straffe *= Time.deltaTime;

		if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 && !audio.isPlaying ) {
			
				audio.Play ();
		
		}

		if (Input.GetKeyDown ("escape")) {
		
			Cursor.lockState = CursorLockMode.None;

		}

		transform.Translate (straffe, 0, micanje);
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag("key")) {
			hasKey = true;
			message = "You found the key.";
			display = true;
		}
		if (other.CompareTag("doors") && hasKey==true) {
			Destroy (doors);
		}
		if (other.CompareTag("doors") && hasKey==false){
			display = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("key")) {
			Destroy (key);
			message = "";
		}
		display = false;
	}

	void OnGUI(){
		if (display == true) {
			GUI.Box (new Rect (Screen.width / 4, Screen.height / 6, Screen.width / 2, Screen.height / 2), message, style);
		}
	}
}

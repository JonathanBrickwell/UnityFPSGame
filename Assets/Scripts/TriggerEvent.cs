using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour {
	public GameObject enemy;
	public Transform enemyPos;
	public Transform enemyPos2;
	public string message;
	private bool display = false;
	GUIStyle style = new GUIStyle();

	void Start () {
		style.fontSize = 40;
		style.normal.textColor = Color.red;
		style.alignment = TextAnchor.UpperCenter;
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")){
			InvokeRepeating ("EnemySpawner", 0.5f, 40f);
			display = true;
		}
	}

	void OnTriggerExit(Collider other){
		display = false;
	}

	void EnemySpawner (){
		Instantiate (enemy, enemyPos.position, enemyPos.rotation);
		Instantiate (enemy, enemyPos2.position, enemyPos2.rotation);
	}

	void OnGUI(){
		if (display == true) {
			GUI.Box (new Rect (Screen.width / 4, Screen.height / 6, Screen.width / 2, Screen.height / 2), message, style);
		}
	}
}

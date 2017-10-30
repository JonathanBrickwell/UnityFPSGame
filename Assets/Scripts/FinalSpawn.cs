using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSpawn : MonoBehaviour {
	public GameObject enemy;
	public Transform enemyPos;
	public Transform enemyPos2;
	public Transform enemyPos3;
	public Transform enemyPos4;
	public Transform enemyPos5;
	public Transform enemyPos6;
	public Transform enemyPos7;
	public Transform enemyPos8;
	public GameObject trigger;
	public string message;
	private bool display = false;
	GUIStyle style = new GUIStyle();

	public GameObject doors;
	public Transform doorsPos;

	void Start () {
		style.fontSize = 40;
		style.normal.textColor = Color.red;
		style.alignment = TextAnchor.UpperCenter;
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")){
			Instantiate (doors, doorsPos.position, doorsPos.rotation);
			Invoke ("EnemySpawner", 1f);
			display = true;
		}
	}

	void OnTriggerExit(Collider other){
		display = false;
		Destroy (trigger);
	}

	void EnemySpawner (){
		Instantiate (enemy, enemyPos.position, enemyPos.rotation);
		Instantiate (enemy, enemyPos2.position, enemyPos2.rotation);
		Instantiate (enemy, enemyPos3.position, enemyPos3.rotation);
		Instantiate (enemy, enemyPos4.position, enemyPos4.rotation);
		Instantiate (enemy, enemyPos5.position, enemyPos5.rotation);
		Instantiate (enemy, enemyPos6.position, enemyPos6.rotation);
		Instantiate (enemy, enemyPos7.position, enemyPos7.rotation);
		Instantiate (enemy, enemyPos8.position, enemyPos8.rotation);
		Instantiate (enemy, enemyPos.position, enemyPos.rotation);
		Instantiate (enemy, enemyPos3.position, enemyPos3.rotation);
		Instantiate (enemy, enemyPos5.position, enemyPos5.rotation);
	}

	void OnGUI(){
		if (display == true) {
			GUI.Box (new Rect (Screen.width / 4, Screen.height / 6, Screen.width / 2, Screen.height / 2), message, style);
		}
	}


}
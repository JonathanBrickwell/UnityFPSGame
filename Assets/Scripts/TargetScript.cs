using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public float health = 50f;

	public void TakeDamage(float amount)
	{
		health -= amount;

		if (health <= 0) {
		
			Die ();

		}
	}

	void Die()
	{
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}

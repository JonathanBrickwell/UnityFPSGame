using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	//public AudioClip audio;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);

	bool isDead;
	bool damaged;

	void Awake()
	{
		currentHealth = startingHealth;
	}

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		if (damaged) {
		
			damageImage.color = flashColor;
		} 
		else {
		
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;


		if (currentHealth <= 0 && !isDead) {

			Death ();
		}
	}

	void Death()
	{
		isDead = true;
		SceneManager.LoadScene ("Ending");
	}
}

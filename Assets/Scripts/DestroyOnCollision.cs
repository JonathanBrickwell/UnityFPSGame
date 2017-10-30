using UnityEngine.SceneManagement;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	GameObject player;
	bool playerRange;
	float timer;

	PlayerHealthScript playerHealth;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealthScript> ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject == player) {
		
			playerRange = true;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject == player) {
		
			playerRange = false;
		}
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerRange) {
		
			Attack ();
		}

		if (playerHealth.currentHealth <= 0) {
		
			SceneManager.LoadScene ("Ending");
		}
	}

	void Attack()
	{
		timer = 0f;

		if (playerHealth.currentHealth > 0) {
		
			playerHealth.TakeDamage (attackDamage);
		}
	}

}

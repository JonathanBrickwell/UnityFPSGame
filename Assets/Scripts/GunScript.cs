using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public float impactForce = 50f;
	public float fireRate = 15f;
	public float nextTimeToFire = 0f;
	public ParticleSystem particle;
	public GameObject hitEffect;

	public Camera fpsCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Fire1") && Time.time >= nextTimeToFire) {
		
			AudioSource shoot = GetComponent<AudioSource> ();
			nextTimeToFire = Time.time + 1f / fireRate;
			particle.Play ();
			shoot.Play ();
			Shoot ();
		
		}
		
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
		
			//Debug.Log (hit.transform.name);

			TargetScript traget = hit.transform.GetComponent<TargetScript>();

			if (traget != null) {
			
				traget.TakeDamage (damage);
			}


			if (hit.rigidbody != null) {
			
				hit.rigidbody.AddForce (-hit.normal * impactForce);

			}

			GameObject impact = Instantiate (hitEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impact, 1f); 
		}

	}
}

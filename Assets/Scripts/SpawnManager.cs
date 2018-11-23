using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public static bool spawning = true;

	public float delay;
	public float delayMultiplier;
	public float height;
	public GameObject dropletsPrefab;
	public Transform dropletsParent;
	public GameObject particlesPrefab;


	private Vector3 dropletsPos;
	private float offset = 0.35f;
	private GameObject particles;

	void FixedUpdate () {
		if (!spawning) {
			spawning = true;
			StartCoroutine ("Spawn");
		}
	}

	IEnumerator Spawn(){
		Instantiate (dropletsPrefab, RandomizePos(), Quaternion.identity, dropletsParent);
		yield return new WaitForSeconds (delay);
		delay *= delayMultiplier;
		spawning = false;
	}


	Vector3 RandomizePos(){
		Vector3 pos = Random.insideUnitCircle * 0.4f;
		pos.z = pos.y;
		pos.y = height;
		if (pos.x > 0)
			pos.x += offset;
		else
			pos.x -= offset;
		if (pos.z > 0)
			pos.z += offset;
		else
			pos.z -= offset;
		return pos;
	}

	public void ParticleSplash(string color, Vector3 pos){
		particles = Instantiate (particlesPrefab, pos, Quaternion.identity);
		particles.tag = color;

		if (particles.tag == "Red") {
			particles.GetComponent<ParticleSystemRenderer> ().material.SetColor ("_Color", Color.red);
		} else if (particles.tag == "Yellow") {
			particles.GetComponent<ParticleSystemRenderer> ().material.SetColor ("_Color", Color.yellow);
		} else {
			particles.GetComponent<ParticleSystemRenderer> ().material.SetColor ("_Color", Color.blue);
		}
		StartCoroutine ("DestroyParticle");
	}

	IEnumerator DestroyParticle(){
		yield return new WaitForSeconds (1);
		DestroyObject(particles);
	}
}

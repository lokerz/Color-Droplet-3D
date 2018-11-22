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

	private Vector3 dropletsPos;
	private float offset = 0.35f;


	void FixedUpdate () {
		if (!spawning) {
			spawning = true;
			StartCoroutine ("Spawn");
		}
	}

	IEnumerator Spawn(){
		Debug.Log (delay);
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
}

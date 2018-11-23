using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {
	private StageManager stageManager;
	private SpawnManager spawnManager;
	private SoundManager soundManager;

	void Start(){
		stageManager = GameObject.Find ("Manager").GetComponent<StageManager> ();
		spawnManager = GameObject.Find ("Manager").GetComponent<SpawnManager> ();
		soundManager = GameObject.Find ("Manager").GetComponent<SoundManager> ();
	}

	void OnTriggerEnter(Collider other){
		soundManager.Play ();
		if (other.tag == gameObject.tag)
			stageManager.AddScore ();
		else {
			stageManager.WrongColor ();
			stageManager.Vibrate ();
		}
		
		spawnManager.ParticleSplash (other.tag.ToString (), other.transform.position);

		Destroy (other.gameObject);


	}
}

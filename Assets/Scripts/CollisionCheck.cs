using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {
	public StageManager stageManager;

	void Start(){
		stageManager = GameObject.Find ("Manager").GetComponent<StageManager> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == gameObject.tag)
			stageManager.AddScore ();
		else {
			stageManager.WrongColor();
		}

		Destroy (other.gameObject);
	}
}

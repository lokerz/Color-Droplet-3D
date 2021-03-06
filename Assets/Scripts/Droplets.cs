using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplets : MonoBehaviour {
	public float speed;

	private int index;

	void Start () {
		
		index = Random.Range (0, 3);

		if (index == 0) {
			gameObject.tag = "Red";
			GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.red);
		}
		else if (index == 1) {
			gameObject.tag = "Yellow";
			GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.yellow);
		}
		else{
			gameObject.tag = "Blue";
			GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.blue);
		}
	}

}

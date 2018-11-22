using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {
	public GameObject ringsPrefab;
	public Transform ringsParent;
	public GameObject[] rings;

	private Vector3 ringsPos;
	private Quaternion ringsRot;

	void Start () {
		ringsRot = Quaternion.identity;
		rings = new GameObject[9];
		for (int i = 0; i < 9; i++) { 
			rings [i] = Instantiate (ringsPrefab, ringsParent.transform.position, ringsRot, ringsParent);
			ringsRot *= Quaternion.Euler (0, 40, 0);

			if (i%3 == 0) {
				rings[i].tag = "Red";
				rings[i].GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.red);
			} else if (i%3 == 1) {
				rings[i].tag = "Yellow";
				rings[i].GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.yellow);
			} else {
				rings[i].tag = "Blue";
				rings[i].GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.blue);
			}
		}
	}
		
}

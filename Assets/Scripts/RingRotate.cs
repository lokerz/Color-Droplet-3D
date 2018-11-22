using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotate : MonoBehaviour {
	public float rotationSpeed = 1;
	public Camera cam;

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	//#if UNITY_EDITOR
	void OnMouseDown(){
		Debug.Log ("called");
		rb.angularVelocity = Vector3.zero;
	}

	void OnMouseDrag(){
		float Rotation = Input.GetAxis ("Mouse X") * rotationSpeed;
		//transform.RotateAround (Vector3.down, Rotation);
		rb.AddTorque (transform.up * -Rotation);
	}
	//#endif

	//#if UNITY_ANDROID

	//#endif

}

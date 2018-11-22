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
		
	void OnMouseDown(){
		
		rb.angularVelocity = Vector3.zero;
	}

	void OnMouseDrag(){
		float Rotation = Input.GetAxis ("Mouse X") * rotationSpeed;

		rb.AddTorque (transform.up * -Rotation);
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolt_controller : MonoBehaviour {
	public float speed;


	// Use this for initialization
	void Start () {
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (0, 0, speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

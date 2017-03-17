using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public int xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;

	public Boundary boundary;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rb.velocity = new Vector3 (moveHorizontal*speed, 0.0f, moveVertical*speed);

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
			
		rb.rotation = Quaternion.Euler (new Vector3 (0, 0, -moveHorizontal*20));
	}

}

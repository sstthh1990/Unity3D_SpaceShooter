using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary{
	// comment from other branch
	public int xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;

	public Boundary boundary;
	public Transform shotSpwan;
	public GameObject shot;
	public float fire_rate = 0.5f;


	private Rigidbody rb;
	private float last_fire_time = 0.0f;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time - last_fire_time > fire_rate) 
		{
			Instantiate(shot, shotSpwan.position, shotSpwan.rotation);
			last_fire_time = Time.time;
		}
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

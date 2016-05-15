using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;

	private float nextFire;
	public float fireRate;

	//what is the difference between update and fixed update?
	void Update() {
		if(Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

	}


	void FixedUpdate() {
		//horizontal and vertical are axes that are preset in input manager
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Rigidbody rb = this.GetComponent<Rigidbody>();

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		float x = Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax);
		float y = 0.0f;
		float z = Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax);
		rb.position = new Vector3(x,y,z);

		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

	}
}

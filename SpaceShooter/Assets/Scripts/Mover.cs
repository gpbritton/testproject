using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	//executed on first frame object is instantiated
	void Start() {
		this.GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}

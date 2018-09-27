using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour {
	public int speed = 0;

	// Use this for initialization
	void Start () {
		Debug.Log ("roll start");
		Vector2 vec = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick); 
		Debug.Log (vec);

	}
	
	// Update is called once per frame
	void Update () {
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");


		/*
		Vector2 vec = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick); 



		Debug.Log (vec);
		*/

		Vector3 position = transform.position;
		position.x += moveH * speed * Time.deltaTime;
		position.z += moveV * speed * Time.deltaTime;
		transform.position = position;
	}
}

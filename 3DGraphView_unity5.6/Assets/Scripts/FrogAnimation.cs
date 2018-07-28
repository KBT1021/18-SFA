using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimation : MonoBehaviour {
	Animator frogAnimator;
	// Use this for initialization
	void Start () {
		frogAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	
	void Update () {
		
		transform.localPosition = new Vector3(0,0,0);
		transform.localRotation = new Quaternion(0,0,0,0);
		//if (Input.GetButtonDown ("Fire1")) {frogAnimator.SetTrigger ("Eat");}
	}
	
	public void OnClick () {

		frogAnimator.SetTrigger ("Eat");
	}
}

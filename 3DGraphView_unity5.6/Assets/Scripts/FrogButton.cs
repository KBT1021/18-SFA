using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogButton : MonoBehaviour {

	private GameObject graphBox;
	private GameObject objectBox;

	void Start () {
		graphBox = GameObject.Find("GraphBox");
		objectBox = GameObject.Find("ObjectBox");
	}
	
	// Update is called once per frame
	void OnClick () {

		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphButton : MonoBehaviour {

	Button thisButton;
    GameObject inputField;
    FunctionGenerator functionGenerator;
    GameObject functionButtons;
	// Use this for initialization
	void Start () {
		inputField = GameObject.Find("Canvas/InputField");
		functionGenerator =  GameObject.Find("Canvas/FunctionGenerator").GetComponent<FunctionGenerator>();
		functionButtons = GameObject.Find("Canvas/FunctionButtons");
		functionButtons.SetActive(false);
	}
	
	// Update is called once per frame
	public void OnClick () {
		functionButtons.SetActive(true);
		inputField.SetActive(false);

		
	}
}

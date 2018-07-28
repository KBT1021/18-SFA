using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphSelectButton : MonoBehaviour {

    GameObject inputField;
    GameObject enterButton;
    FunctionGenerator functionGenerator;
    GameObject functionButtons;
	// Use this for initialization
	void Start () {
		inputField = GameObject.Find("Canvas/InputField");
		enterButton = GameObject.Find("Canvas/EnterButton");
		functionGenerator =  GameObject.Find("Canvas/FunctionGenerator").GetComponent<FunctionGenerator>();
		functionButtons = GameObject.Find("Canvas/FunctionButtons");
		functionButtons.SetActive(false);
	}
	
	// Update is called once per frame
	public void OnClick () {

		functionButtons.SetActive(true);
		inputField.SetActive(false);
		enterButton.SetActive(false);
		
	}
}

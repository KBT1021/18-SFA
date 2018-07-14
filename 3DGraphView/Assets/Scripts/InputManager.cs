using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {
    InputField inputField;

    public Text text;

	// Use this for initialization
	void Start () {
        inputField = GetComponent<InputField>();
        InitInputField();
	}

    public void InputSaver(){
        string inputString = inputField.text;
        inputString = inputField.text;
        text.text = inputString;
        Debug.Log(inputString);
        InitInputField();
    }

	

    void InitInputField(){
        inputField.text = "";
        inputField.ActivateInputField();
    }
}

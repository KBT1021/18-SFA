using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {
    InputField inputField;

	// Use this for initialization
	void Start () {
        inputField = GetComponent<InputField>();
        InitInputField();
	}

    public void InputLogger(){
        string inputValue = inputField.text;
        Debug.Log(inputValue);
        InitInputField();
    }
	
    void InitInputField(){
        inputField.text = "";
        inputField.ActivateInputField();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManager : MonoBehaviour {
    InputField inputField;

    public Text text;
    public GameObject target;

	// Use this for initialization
	void Start () {
        inputField = GetComponent<InputField>();
        InitInputField();
	}

    public void InputSaver(){
        //入力をStringとしてtext.textに出力
        string inputString = inputField.text;
        inputString = inputField.text;
        text.text = inputString;
        //
        float f;
        if (float.TryParse(text.text, out f)){
            Instantiate(target, new Vector3(f, f, f), Quaternion.identity);
        }
        Debug.Log(inputString);
        InitInputField();
    }

	

    void InitInputField(){
        inputField.text = "";
        inputField.ActivateInputField();
    }
}

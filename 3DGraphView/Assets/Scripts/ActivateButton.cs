using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateButton : MonoBehaviour {
    Button thisButton;
    GameObject inputField;

	// Use this for initialization
	void Start () {
        thisButton = GetComponent<Button>();
        inputField = GameObject.Find("Canvas/InputField");
	}

    public void OnClick(){
        thisButton.image.color = Color.gray;
        InputManager inputManager = inputField.GetComponent<InputManager>();
        if (thisButton.name == "PointButton") { InputManager.whichActiveButton = 1; }
        else if (thisButton.name == "LineButton") { InputManager.whichActiveButton = 2; }
        else if (thisButton.name == "CubeCutButton") { InputManager.whichActiveButton = 3; }
    }
}

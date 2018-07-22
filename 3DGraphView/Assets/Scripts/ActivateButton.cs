using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateButton : MonoBehaviour {
    Button thisButton;
    GameObject inputField;
    GameObject placeHolder;

	// Use this for initialization
	void Start () {
        thisButton = GetComponent<Button>();
        inputField = GameObject.Find("Canvas/InputField");
        placeHolder = GameObject.Find("Canvas/InputField/Placeholder");
	}

    public void OnClick(){
        InputManager inputManager = inputField.GetComponent<InputManager>();
            
        if (thisButton.name == "PointButton") 
        { 
            InputManager.whichActiveButton = 1;
            placeHolder.GetComponent<Text>().text = "Input Point Posision : (1,2,3)";
           // thisButton.image.color = Color.gray;
        }
        else if (thisButton.name == "LineButton") 
        {
            InputManager.whichActiveButton = 2; 
            placeHolder.GetComponent<Text>().text = "Input Line Position : (1,2,3), (4,5,6)";
            //thisButton.image.color = Color.gray;
        }
        else if (thisButton.name == "CubeCutButton") 
        { 
            InputManager.whichActiveButton = 3;
            placeHolder.GetComponent<Text>().text = "Draw some graph : Enter the number 0 - 4";
            //thisButton.image.color = Color.gray;
        }
    }

}

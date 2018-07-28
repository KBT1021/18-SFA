using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateButton : MonoBehaviour {
    Button thisButton;
    GameObject inputField;
    GameObject enterButton;
    GameObject placeHolder;
    public GameObject functionButtons;
    FunctionGenerator functionGenerator;


	// Use this for initialization
	void Start () {
        thisButton = GetComponent<Button>();
        inputField = GameObject.Find("Canvas/InputField");
        enterButton = GameObject.Find("Canvas/EnterButton");
        placeHolder = GameObject.Find("Canvas/InputField/Placeholder");
        functionGenerator =  GameObject.Find("Canvas/FunctionGenerator").GetComponent<FunctionGenerator>();
        //functionButtons = GameObject.Find("Canvas/FunctionButtons");
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
        
        if (thisButton.name == "GraphSelectButton") {
            functionButtons.SetActive(true);
            inputField.SetActive(false);
            enterButton.SetActive(false);
        }
        else{
            functionButtons.SetActive(false);
            inputField.SetActive(true);
            enterButton.SetActive(true);
        }
    }

}

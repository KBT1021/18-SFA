using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionButton : MonoBehaviour {

	private Button thisButton;
	private FunctionGenerator functionGenerator;
	private int method = 3;

	// Use this for initialization
	void Start () {
		thisButton = GetComponent<Button>();
		functionGenerator =  GameObject.Find("Canvas/FunctionGenerator").GetComponent<FunctionGenerator>();
		
	}
	
	// Update is called once per frame
	public void OnClick () {
		if (thisButton.name == "Function1")  {  method = 1;   }
		else if (thisButton.name == "Function2")  {  method = 2;   }
		else if (thisButton.name == "Function3")  {  method = 3;   }
		else if (thisButton.name == "Function4")  {  method = 4;   }
		functionGenerator.method = method;
		functionGenerator.Generate();
		
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CameraChange : MonoBehaviour {

	private GameObject Cameras;
	private GameObject MainCam;
	private GameObject Canvas;
	private GameObject CanvasHolo;
	private GameObject HoloButton;
	private GameObject Square;


	public void Start(){
		Cameras = GameObject.Find("Cameras");
		MainCam = GameObject.Find("Main Camera");
		Canvas = GameObject.Find("Canvas");
		CanvasHolo = GameObject.Find("CanvasHolo");
		HoloButton = GameObject.Find("HoloButton");
		Square = GameObject.Find("Square");
		Cameras.SetActive(false);
		Square.SetActive(false);
		//CanvasHolo.SetActive(false);
	}

	public void OnClick() {

		if(MainCam.activeSelf){
			MainCam.SetActive (false);
			Cameras.SetActive (true);	
			Square.SetActive(true);		
			Canvas.SetActive(false);
			this.gameObject.GetComponentInChildren<Text>().text = "Back";
			//CanvasHolo.SetActive(true);
		}
		else{
			MainCam.SetActive (true);
			Cameras.SetActive (false);
			Square.SetActive(false);
			Canvas.SetActive(true);
			this.gameObject.GetComponentInChildren<Text>().text = "3D<size=32>\nView\n</size>";
			//CanvasHolo.SetActive(false);
		}
    
  }
}

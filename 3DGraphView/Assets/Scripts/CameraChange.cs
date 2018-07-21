using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class CameraChange : MonoBehaviour {

	private GameObject Cameras;
	private GameObject MainCam;
	private GameObject Canvas;
	private GameObject CanvasHolo;


	public void Start(){
		Cameras = GameObject.Find("Cameras");
		MainCam = GameObject.Find("Main Camera");
		Canvas = GameObject.Find("Canvas");
		CanvasHolo = GameObject.Find("CanvasHolo");
		Cameras.SetActive(false);
		//CanvasHolo.SetActive(false);
	}

	public void OnClick() {

		if(MainCam.activeSelf){
			MainCam.SetActive (false);
			Cameras.SetActive (true);			
			Canvas.SetActive(false);
			//CanvasHolo.SetActive(true);
		}
		else{
			MainCam.SetActive (true);
			Cameras.SetActive (false);
			Canvas.SetActive(true);
			//CanvasHolo.SetActive(false);
		}
    
  }
}

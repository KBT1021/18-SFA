using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public void OnClick() {

		if(SceneManager.GetActiveScene().name == "MainScene"){
			SceneManager.LoadScene ("FrogGhost");
		}
		else{
			SceneManager.LoadScene ("MainScene");

		}
    
  }
}

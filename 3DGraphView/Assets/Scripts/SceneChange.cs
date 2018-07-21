using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public void OnClick() {

		if(SceneManager.GetActiveScene().name == "SampleScene"){
			SceneManager.LoadScene ("FrogGhost");
		}
		else{
			SceneManager.LoadScene ("SampleScene");

		}
    
  }
}

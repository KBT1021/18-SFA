using UnityEngine;
using System.Collections;



// Fキーで表皮が透けて骨になるよ！Gで戻るよ！



public class FadeSkin : MonoBehaviour {

	Color alpha = new Color(0, 0, 0, 0);
	Color normal = new Color(1, 1, 1, 1);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)) {
			GetComponent<Renderer>().material.color = alpha;
		}
		if(Input.GetKeyDown(KeyCode.G)) {
			GetComponent<Renderer>().material.color = normal;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoint : MonoBehaviour {

    GameObject objectBox;
    GameObject graphBox;

    private void Start()
    {
        objectBox = GameObject.Find("ObjectBox");
        graphBox = GameObject.Find("GraphBox");
    }

    public void OnClick()
    { 
        foreach (Transform n in objectBox.transform)
        {
            Destroy(n.gameObject);
        }
        foreach (Transform n in graphBox.transform)
        {
            Destroy(n.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionGenerator : MonoBehaviour {

    GameObject graphBox;
    GameObject instObj;
    //yがなぜか上向きなので y = f(x, z)という形で生成
    //ここを自由にいじってグラフの生成範囲を決める。
    int xDiv = 200, zDiv = 200;
    float xini = -20f, xfin = 20f, zini = -20f, zfin = 20f;
    //methodで読み込む関数を変える。
    public int method = 3;

    float Math0 (float x, float z){
        float y = -(x * x + z * z)/(float)10.0;
        return y;
    }

    float Math1 (float x, float z){
        float y = (x * x - z * z)/(float)10.0;
        return y;
    }


    float Math2 (float x, float z){
        float y = x*z/(float)10.0;
        return y;
    }

    float Math3(float x, float z){
        float y = Mathf.Cos(Mathf.Sqrt(x*x + z*z));
        return y;
    }
    float Math4(float x, float z){
        float y = 10.0f*Mathf.Exp(-(x*x + z*z)/(float)10.0);
        return y;
    }

    void Start()
    {
        graphBox = GameObject.Find("GraphBox");
    }


    public void ObjDestroy(){
        foreach(Transform n in graphBox.transform)
        {
            Destroy(n.gameObject);    
        }
    }

    public void Generate(){
        GameObject particle = Resources.Load("Prefabs/ParticlePrefabs", typeof(GameObject)) as GameObject; 
        float dx = (xfin - xini) / (float)xDiv, dz = (zfin - zini) / (float)zDiv;
        float x = xini;
        float y = 0;
        for (int i = 0; i < xDiv; i++)
        {
            float z = zini;
            for (int j = 0; j < zDiv; j++)
            {
                if (method == 0) { y = Math0(x, z); }
                else if (method == 1) { y = Math1(x, z); }
                else if (method == 2) { y = Math2(x, z); }
                else if (method == 3) { y = Math3(x, z); }
                else if (method == 4) { y = Math4(x, z); }
                else { y = 0; }
                instObj = Instantiate(particle, new Vector3(x, y, z), Quaternion.identity);
                instObj.transform.parent = graphBox.transform;
                z = z + dz;
            }
            x = x + dx;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

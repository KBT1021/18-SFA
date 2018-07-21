using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Test : MonoBehaviour
{
    //divisionX, divisionY：切るメッシュ数（縦横）
    //method : これで生成する関数を変更しよう。
    public int method = 0;
    public int divisionX = 200;
    public int divisionY = 200;
    public float sizeX = 5f;
    public float sizeY = 5f;
    //Meshはあとで生成するAssets
    public string saveAsAnAssetInPath = "Assets/ObjMesh.asset";
    Mesh mesh;
    
    Vector3 FuncGenerator(float x, float y)
    {
        //関数を変更してみる。
        float z = 0;
        return new Vector3(x, y, z);
    }

    Mesh CreateMesh()
    {
        int countX = divisionX + 1;
        int countY = divisionY + 1;
        var vertices = new Vector3[countX * countY];//頂点を配列で定義
        var uv = new Vector2[countX * countY];//uv平面に移す時の入れ物
        int k = 0;
        //
        for (int i = 0; i <= divisionY; i++)
        {
            for (int j = 0; j <= divisionX; j++)
            {
                float u = (float)j / divisionX;
                float v = (float)i / divisionY;
                //(x,y) : uvを0.5ずつずらして，size倍した値
                float x = (u - .5f) * sizeX;
                float y = (v - .5f) * sizeY;
                //各(x,y)における頂点のz座標を関数から求めてverticiesに入れる
                vertices[k] = FuncGenerator(x, y);
                uv[k++].Set(u, v);
            }
        }

        //trianglesはmesh属性のうちメッシュを埋める「面」の方向を決めている。順番は変えない方が良さそう。
        //https://sleepygamersmemo.blogspot.com/2017/04/unity-mesh-square.html
        var triangles = new int[6 * divisionX * divisionY];//三角形の各頂点の入れ物
        int l = 0, kTL = 0, kTR = 1, kBL = countX, kBR = countX + 1;
        for (int i = 0; i < divisionY; i++)
        {
            for (int j = 0; j < divisionX; j++)
            {
                triangles[l++] = kTL;
                triangles[l++] = kBL++;
                triangles[l++] = kBR;
                triangles[l++] = kTR++;
                triangles[l++] = kTL++;
                triangles[l++] = kBR++;
            }
            kTL++; kTR++; kBL++; kBR++;
        }
        
        if(mesh != null)
            mesh.Clear();
        mesh.name = "ObjMesh";
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;//triangle属性を与えないとobjectが消える。

        return mesh;
    }

    void Start()
    {
        mesh = new Mesh();
        mesh = CreateMesh();
         //起動時にMeshをAssetに保存する
        if (saveAsAnAssetInPath != "")
        {
            AssetDatabase.CreateAsset(mesh, saveAsAnAssetInPath);
            AssetDatabase.SaveAssets();
        }

        //MeshFilter :メッシュ情報保持担当，そこに切るべきmeshを入れる
        var filter = GetComponent<MeshFilter>();
        if (filter == null) filter = gameObject.AddComponent<MeshFilter>();
        filter.sharedMesh = mesh;

        //MeshRenderer : メッシュ描画担当，
        var renderer = GetComponent<MeshRenderer>();
        if (renderer == null)
        {
            renderer = gameObject.AddComponent<MeshRenderer>();
        }
        if (renderer.material == null)
        {
            renderer.material = Resources.Load("Materials/GraphMaterial", typeof(Material)) as Material;
            //renderer.material = Resources.Load("Default-Material", typeof(Material)) as Material;
        }
        //ここが照明についての設定，変更可能。
        CreateLight("Key Light", 60f, 100f, 1f, 1f, 1f);
        CreateLight("Fill Light", 30f, -100f, 1f, .8f, .6f);
        
    }
    private void Update()
    {
        mesh = CreateMesh();
    }


    // ここから削除可 ：ここが照明の詳細を決めている。
    void CreateLight(string name, float rx, float ry, float r, float g, float b)
    {
        var obj = new GameObject();
        obj.name = name;
        var light = obj.AddComponent<Light>();
        var euler = new Vector3(rx, ry, 0f);
        var pos = transform.position + FuncGenerator(0f, 0f);
        light.type = LightType.Directional;
        light.transform.localRotation = Quaternion.Euler(euler);
        light.transform.position = pos + Quaternion.Euler(-euler) * Vector3.forward * 10f;
        light.color = new Color(r, g, b);
        light.intensity = 1f;
        light.bounceIntensity = 0f;
        light.shadows = LightShadows.Soft;
    }
    // ここまで削除可 

}
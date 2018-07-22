using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class InputManager : MonoBehaviour
{
    InputField inputField;

    //inputText:入力されたテキスト，pointTarget:点のPrefabs，lineTarget：直線のPrefabs
    GameObject pointTarget;
    GameObject lineTarget;
    GameObject rendererTarget;
    Material lineMaterial;
    Text inputText;
    GameObject pointButton;
    GameObject lineButton;
    GameObject cubeCutButton;
    Button enterButton;
    FunctionGenerator functionGenerator;
    //whichActiveButton:どのボタンがアクティブか。0: no, 1:point, 2: line, 3: cubecut
    public static int whichActiveButton = 0;
    //pointTarge：後で点の色とか編集したくなりそう：これは後で実装

    // Use this for initialization
    void Start()
    {
        inputField = GameObject.Find("Canvas/InputField").GetComponent<InputField>();
        InitInputField();
        pointTarget = Resources.Load("Prefabs/PointPrefabs", typeof(GameObject)) as GameObject;
        lineTarget = Resources.Load("Prefabs/PointPrefabs", typeof(GameObject)) as GameObject;
        rendererTarget = Resources.Load("Prefabs/LineRendererPrefabs", typeof(GameObject)) as GameObject;
        lineMaterial = Resources.Load("Materials/LineMaterial", typeof(Material)) as Material;
        inputText = GameObject.Find("Canvas/InputField/Text").GetComponent<Text>();
        pointButton = GameObject.Find("Canvas/ModeSelectButtons/PointButton");
        lineButton = GameObject.Find("Canvas/ModeSelButtons/LineButton");
        cubeCutButton = GameObject.Find("Canvas/ModeSelButtons/CubeCutButton");
        enterButton = GameObject.Find("Canvas/EnterButton").GetComponent<Button>();
        functionGenerator =  GameObject.Find("Canvas/FunctionGenerator").GetComponent<FunctionGenerator>();
    }


    //InputSaver():EnterKeyを押した時に入力されたテキストの処理を行う。
    //whichActiveButtonによって処理を変える。
    public void InputSaver()
    {
        //とりあえずグラフのやつはEnterのたびに消去。
        functionGenerator.ObjDestroy();  
        //入力をStringとしてinputText.textに出力
        string inputString = inputField.text;
        inputString = inputField.text;
        inputText.text = inputString;

        //3D点の表示
        if (Is3DPoint(inputText.text) && whichActiveButton == 1)
        {
            long posX, posY, posZ;
            string[] strPos = new string[3];
            long[] longPos = new long[3];
            //fx, fy, fzの取得
            MatchCollection tempText = Regex.Matches(inputText.text, "-?[0-9]+");
            for (int i = 0; i < 3; i++)
            {
                strPos[i] = tempText[i].Groups[0].Value;
                longPos[i] = long.Parse(strPos[i]);
            }
            posX = longPos[0]; posY = longPos[1]; posZ = longPos[2];

            //posx, posy, poszをもとに表示
            Instantiate(pointTarget, new Vector3(posX, posY, posZ), Quaternion.identity);
            foreach (Match c in tempText)
            {
                Debug.Log(c.Value);
            }
        }
        //直線の表示
        if (Is3DLine(inputText.text) && whichActiveButton == 2)
        {
            string[] strPos = new string[6];
            long[] longPos = new long[6];
            long[] pos1 = new long[3], pos2 = new long[3];
            //fx, fy, fzの取得
            MatchCollection tempText = Regex.Matches(inputText.text, "-?[0-9]+");
            for (int i = 0; i < 6; i++)
            {
                strPos[i] = tempText[i].Groups[0].Value;
                longPos[i] = long.Parse(strPos[i]);
            }
            pos1[0] = longPos[0]; pos1[1] = longPos[1]; pos1[2] = longPos[2];
            pos2[0] = longPos[3]; pos2[1] = longPos[4]; pos2[2] = longPos[5];
            //LineRendererを用い描画
            GameObject rendObj = Instantiate(rendererTarget) as GameObject;
            LineRenderer renderer = rendObj.GetComponent<LineRenderer>();
            renderer.SetWidth(0.1f, 0.1f);
            renderer.SetVertexCount(2);
            renderer.SetPosition(0, new Vector3(pos1[0], pos1[1], pos1[2]));
            renderer.SetPosition(1, new Vector3(pos2[0], pos2[1], pos2[2]));

        }

        if (IsNumber04(inputText.text) && whichActiveButton == 3)
        {
            string strNum;
            int intNum;
            //入れられた数字の取得
            MatchCollection tempText = Regex.Matches(inputText.text, "[0-4]");
            strNum = tempText[0].Groups[0].Value;
            intNum = int.Parse(strNum);
            functionGenerator.method = intNum;
            functionGenerator.Generate();                  
        }
        InitInputField();
    }

    //入力画面の初期化:何か出力が出た時だけにしよう。
    void InitInputField()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }

    //Is3DPoint():3D点座標を示すかの判定，"-**, -**, -**"の形ならOK
    bool Is3DPoint(string text)
    {
        bool result;
        //空白も許容したい。\sがなぜか入らないのでよくわからない。部分一致で検索しているから，完全一致に変更せよ。
        result = Regex.IsMatch(text, Regex.Escape("(")+"-?[0-9]+,-?[0-9]+,-?[0-9]+"+Regex.Escape(")"));
        return result;
    }

    //IsLine():直線の式を示すかの判定，
    bool Is3DLine(string text)
    {
        bool result;
        result = Regex.IsMatch(text, Regex.Escape("(")+"-?[0-9]+,-?[0-9]+,-?[0-9]+"+Regex.Escape("),(")+"-?[0-9]+,-?[0-9]+,-?[0-9]+"+Regex.Escape(")"));
        return result;
    }
    bool IsNumber04(string text)
    {
        bool result;
        result = Regex.IsMatch(text, "[0-4]");
        return result;
    }
}

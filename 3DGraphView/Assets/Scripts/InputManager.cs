using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class InputManager : MonoBehaviour
{
    InputField inputField;

    public Text text;
    public GameObject pointTarget;
    //pointTarge：後で点の色とか編集したくなりそう：これは後で実装

    // Use this for initialization
    void Start()
    {
        inputField = GetComponent<InputField>();
        InitInputField();
    }

    public void InputSaver()
    {
        //入力をStringとしてtext.textに出力
        string inputString = inputField.text;
        inputString = inputField.text;
        text.text = inputString;


        //出力が点(a,b,c)なら点を出力，直線の式(y = a*x + b)なら直線を出力

        //3D点の表示
        if (Is3DPoint(text.text))
        {
            long posX, posY, posZ;
            string[] strPos = new string[3];
            long[] longPos = new long[3];
            //fx, fy, fzの取得
            MatchCollection tempText = Regex.Matches(text.text, "-?[0-9]+");
            for (int i = 0; i < 3; i++){
                strPos[i] = tempText[i].Groups[0].Value;
                longPos[i] = long.Parse(strPos[i]);
            }
            posX = longPos[0];posY = longPos[1];posZ = longPos[2];

            //posx, posy, poszをもとに表示
            Instantiate(pointTarget, new Vector3(posX, posY, posZ), Quaternion.identity);
            foreach(Match c  in tempText){
                Debug.Log(c.Value);
            }
        }
        //直線の表示
        if (IsLine())
        {

        }
        InitInputField();
    }


    void InitInputField()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }

    //Is3DPoint():3D点座標を示すかの判定，"-**, -**, -**"の形ならOK
    bool Is3DPoint(string text)
    {
        bool result;
        //空白も許容したい,()と+xも許容するべし。
        result = Regex.IsMatch(text, "-?[0-9]+,-?[0-9]+,-?[0-9]+" );
        return result;
    }

    //IsLine():直線の式を示すかの判定，
    bool IsLine()
    {
        return false;
    }
}

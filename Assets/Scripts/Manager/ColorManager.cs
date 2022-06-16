using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : SingletonMonoBehaviour<ColorManager>
{
    public Vector4 FirstPlayerColor => _firstPlayerColor;
    public Vector4 SecondPlayerColor => _secondPlayerColor;

    static Vector4 _firstPlayerColor = new Vector4(255f,112f,0f,255f);
    static Vector4 _secondPlayerColor = new Vector4();

    public void ChangeColor(Color color)
    {
        switch (color)
        {
            case Color.First:
                _firstPlayerColor = new Vector4(Random.Range(0,128), Random.Range(0, 128), Random.Range(0, 128), 255);
                break;
            case Color.Second:
                _secondPlayerColor = new Vector4(Random.Range(0, 128), Random.Range(0, 128), Random.Range(0, 128), 255);
                break;
        }
    }
}
public enum Color
{ 
    First,
    Second
}

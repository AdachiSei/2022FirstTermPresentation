using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{
    [SerializeField]
    [Header("メインカメラ")]
    Camera _mainCamera;

    [SerializeField]
    [Header("高い位置にあるカメラ")]
    Camera _highCamera;

    [SerializeField]
    [Header("プレイヤー1の横にあるカメラ")]
    Camera _firstSideCamera;

    [SerializeField]
    [Header("プレイヤー2の横にあるカメラ")]
    Camera _secondSideCamera;

    /// <summary>カメラを変える</summary>
    /// <param name="_camera">表示したい画面のカメラ</param>
    public void ChangeCamera(CameraType cameraType)
    {
        switch (cameraType)
        {
            case CameraType.Main:
                _mainCamera.depth = 1;
                _highCamera.depth = 0;
                _firstSideCamera.depth = 0;
                _secondSideCamera.depth = 0;
                break;
            case CameraType.High:
                _mainCamera.depth = 0;
                _highCamera.depth = 1;
                _firstSideCamera.depth = 0;
                _secondSideCamera.depth = 0;
                break;
            case CameraType.Side:
                _mainCamera.depth = 0;
                _highCamera.depth = 0;
                _firstSideCamera.depth = 1;
                _secondSideCamera.depth = 1;
                break;
        }
    }
}
public enum CameraType
{ 
    Main,
    High,
    Side
}


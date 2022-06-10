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
    [Header("横にあるカメラ")]
    Camera _sideCamera;

    /// <summary>カメラを変える</summary>
    /// <param name="_camera">表示したい画面のカメラ</param>
    public void ChangeCamera(CameraType cameraType)
    {
        switch (cameraType)
        {
            case CameraType.Main:
                _mainCamera.depth = 1;
                _highCamera.depth = 0;
                _sideCamera.depth = 0;
                break;
            case CameraType.High:
                _mainCamera.depth = 0;
                _highCamera.depth = 1;
                _sideCamera.depth = 0;
                break;
            case CameraType.Side:
                _mainCamera.depth = 0;
                _highCamera.depth = 0;
                _sideCamera.depth = 1;
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


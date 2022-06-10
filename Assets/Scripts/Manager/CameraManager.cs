using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{
    [SerializeField]
    [Header("���C���J����")]
    Camera _mainCamera;

    [SerializeField]
    [Header("�����ʒu�ɂ���J����")]
    Camera _highCamera;

    [SerializeField]
    [Header("���ɂ���J����")]
    Camera _sideCamera;

    /// <summary>�J������ς���</summary>
    /// <param name="_camera">�\����������ʂ̃J����</param>
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


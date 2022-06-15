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
    [Header("�v���C���[1�̉��ɂ���J����")]
    Camera _firstSideCamera;

    [SerializeField]
    [Header("�v���C���[2�̉��ɂ���J����")]
    Camera _secondSideCamera;

    /// <summary>�J������ς���</summary>
    /// <param name="_camera">�\����������ʂ̃J����</param>
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �x�C�u���[�h���V���[�g���邽�߂̃X�N���v�g
/// </summary>
public class ShootController : MonoBehaviour
{
    Rigidbody _rb;
    Camera _camera;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //Y���Ɖ�]�l���t���[�Y������
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        _camera.targetDisplay = 2;
    }

    void Update()
    {
        //�}�E�X�|�C���^�[���\��
        Cursor.visible = false;
        //�}�E�X�ɘA�����ăx�C�u���[�h�𓮂���
        var target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        target.y = transform.position.y;
        transform.position = target;
    }
}

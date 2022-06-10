using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ベイブレードをシュートするためのスクリプト
/// </summary>
public class ShootController : MonoBehaviour
{
    Rigidbody _rb;
    Camera _camera;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //Y軸と回転値をフリーズさせる
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        _camera.targetDisplay = 2;
    }

    void Update()
    {
        //マウスポインターを非表示
        Cursor.visible = false;
        //マウスに連動してベイブレードを動かす
        var target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        target.y = transform.position.y;
        transform.position = target;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �x�C�u���[�h���V���[�g���邽�߂̃X�N���v�g
/// </summary>
public class ShootController : MonoBehaviour
{
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.velocity = (transform.position - Input.mousePosition).normalized;
    }
}

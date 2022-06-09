using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ベイブレードをシュートするためのスクリプト
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

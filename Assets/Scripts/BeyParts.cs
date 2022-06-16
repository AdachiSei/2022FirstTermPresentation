using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyParts : MonoBehaviour
{
    Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.gameObject.transform.position.y < ShootManager.Instance.Height)
        {
            _collider.isTrigger = false;
        }
    }
}

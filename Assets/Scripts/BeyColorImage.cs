using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeyColorImage : MonoBehaviour
{
    Image _image;

    void OnEnable()
    {
        _image = GetComponent<Image>();
        _image.color = ColorManager.Instance.FirstPlayerColor;
    }
    void Update()
    {
        var r = _image.color.r != ColorManager.Instance.FirstPlayerColor.x;
        var g = _image.color.g != ColorManager.Instance.FirstPlayerColor.y;
        var b = _image.color.b != ColorManager.Instance.FirstPlayerColor.z;

        //if (r || g || b)
        //{
        //    _image.color = new Vector4(ColorManager.Instance.FirstPlayerColor.x, ColorManager.Instance.FirstPlayerColor.y, ColorManager.Instance.FirstPlayerColor.z, ColorManager.Instance.FirstPlayerColor.w);
        //}
        Debug.Log(ColorManager.Instance.FirstPlayerColor);
    }
}

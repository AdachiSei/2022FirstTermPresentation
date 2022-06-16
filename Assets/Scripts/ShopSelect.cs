using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelect : MonoBehaviour
{
    /// <summary>プレイヤー1のショップ画面</summary>
    [SerializeField]
    [Header("プレイヤー1のショップ画面")]
    Canvas _firstPlayerCanvas;

    /// <summary>プレイヤー2のショップ画面</summary>
    [SerializeField]
    [Header("プレイヤー2のショップ画面")]
    Canvas _secondPlayerCanvas;

    /// <summary>ショップのパネル</summary>
    [SerializeField]
    [Header("ショップのパネル")]
    Image _shopPanel = null;

    void Start()
    {
        UIManager.Instance.FirstPlayerMoney(MoneyManager.Instance.FirstPlayerMoney);
        UIManager.Instance.SecondPlayerMoney(MoneyManager.Instance.SecondPlayerMoney);
    }

    /// <summary>「＞」or「＜」Buttonを押したら切り替える</summary>
    public void Select()
    {
        if(_firstPlayerCanvas.gameObject.activeSelf)//武器屋だったら
        {
            _firstPlayerCanvas.gameObject.SetActive(false);
            _secondPlayerCanvas.gameObject.SetActive(true);
            _shopPanel.color = new Color32(255, 73, 64, 255);     
        }
        else//装備屋だったら
        {
            _firstPlayerCanvas.gameObject.SetActive(true);
            _secondPlayerCanvas.gameObject.SetActive(false);
            _shopPanel.color = new Color32(3, 159, 255, 255);
        }
    }
}

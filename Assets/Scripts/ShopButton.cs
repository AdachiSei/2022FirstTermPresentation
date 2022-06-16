using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>ショップのボタンに必要なスクリプト/summary>

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    [Header("色")]
    Image _image;

    /// <summary>買うか買わないか確認するパネル</summary>
    [SerializeField]
    [Header("アイテムを買うか買わないか確認するパネル")]
    Image _shopPanel = null;

    /// <summary>パネルにあるボタン以外の全てのボタン</summary>
    [SerializeField]
    [Header("パネルの後ろにある全ボタン")]
    List<Button> _deleteButtons = new List<Button>();

    //ボタンを押したらパネルを表示する
    public void Click()
    {
        _deleteButtons.ForEach(button => { button.interactable = false; });//ボタンを押せなくする
        _shopPanel.gameObject.SetActive(true);//パネルを表示する
        Debug.Log("Click");
    }

    //ボタンを押したらパネルを非表示にする
    public void Cancel()
    {
        _deleteButtons.ForEach(button => { button.interactable = true; });//ボタンを押せるようにする
        _shopPanel.gameObject.SetActive(false);//パネルを非表示する
        Debug.Log("Cancel");
    }

    public void FirstPlayrBuy(int price)
    {
        if (MoneyManager.Instance.FirstPlayerMoney >= price)
        {
            //お金を減らす処理をかく
            Debug.Log("を買いました");
            MoneyManager.Instance.ChangeMoney(Money.FirstPlayer, -price);
            ColorManager.Instance.ChangeColor(Color.First);
            _image.color = ColorManager.Instance.FirstPlayerColor;
            _deleteButtons.ForEach(button => { button.interactable = true; });//ボタンを押せるようにする
            _shopPanel.gameObject.SetActive(false);//パネルを非表示する
            UIManager.Instance.FirstPlayerMoney(MoneyManager.Instance.FirstPlayerMoney);
        }
        else
        {
            Debug.Log("お金が足りません");
        }
    }

    public void SecondPlayerBuy(int price)
    {
        if (MoneyManager.Instance.SecondPlayerMoney >= price)
        {
            //お金を減らす処理をかく
            Debug.Log("を買いました");
            MoneyManager.Instance.ChangeMoney(Money.SecondPlayer, -price);
            ColorManager.Instance.ChangeColor(Color.Second);
            _deleteButtons.ForEach(button => { button.interactable = true; });//ボタンを押せるようにする
            _shopPanel.gameObject.SetActive(false);//パネルを非表示する
            UIManager.Instance.SecondPlayerMoney(MoneyManager.Instance.SecondPlayerMoney);
        }
        else
        {
            Debug.Log("お金が足りません");
        }
    }
}
public enum Player
{
    First,
    Second
}




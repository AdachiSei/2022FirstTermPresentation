using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UIマネージャー
/// UIの表示は全てここで行う
/// </summary>
public class UIManager : SingletonMonoBehaviour<UIManager>
{
    /// <summary>Player1の勝利ポイントテキスト</summary>
    [SerializeField]
    [Header("Player1の勝利ポイント")]
    Text _firstPlayerPointText;

    /// <summary>Player2の勝利ポイントのテキスト</summary>
    [SerializeField]
    [Header("Player2の勝利ポイント")]
    Text _secondPlayerPointText;

    /// <summary>現在のラウンド数のテキスト</summary>
    [SerializeField]
    [Header("ラウンド数のText")]
    Text _roundText;

    /// <summary>相手より長く回って勝利した時に表示するテキスト</summary>
    [SerializeField]
    [Header("相手より長く回って勝利した時に表示するテキスト")]
    Text _spinFinishText;

    /// <summary>相手を場外に追い出した時に表示するテキスト</summary>
    [SerializeField]
    [Header("相手を場外に追い出した時に表示するテキスト")]
    Text _overFinishText;

    /// <summary>相手を破壊した時に表示するテキスト(実装未定)</summary>
    [SerializeField]
    [Header("相手を破壊した時に表示するテキスト)")]
    Text _burstFinishText;

    /// <summary>結果画面のパネル</summary>
    [SerializeField]
    [Header("結果画面のパネル")]
    Text _resultPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OverFinishText()
    {

    }   
    
    public void SpinFinishText()
    {

    }

    public void BurstFinishText()
    {

    }
}

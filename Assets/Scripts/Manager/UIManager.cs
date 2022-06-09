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
    /// <summary>Player1の勝利ポイントのテキスト</summary>
    [SerializeField]
    [Header("Player1の勝利ポイントのテキスト")]
    Text _firstPlayerPointText;

    /// <summary>Player2の勝利ポイントのテキスト</summary>
    [SerializeField]
    [Header("Player2の勝利ポイントのテキスト")]
    Text _secondPlayerPointText;

    /// <summary>現在のラウンド数のテキスト</summary>
    [SerializeField]
    [Header("ラウンド数のテキスト")]
    Text _roundText;

    /// <summary>相手を場外に追い出した時に表示するテキスト</summary>
    [SerializeField]
    [Header("相手を場外に追い出した時に表示するテキスト")]
    Text _overFinishText;

    /// <summary>相手より長く回って勝利した時に表示するテキスト</summary>
    [SerializeField]
    [Header("相手より長く回って勝利した時に表示するテキスト")]
    Text _spinFinishText;

    /// <summary>相手を破壊した時に表示するテキスト(実装未定)</summary>
    [SerializeField]
    [Header("相手を破壊した時に表示するテキスト)")]
    Text _burstFinishText;

    /// <summary>引き分けになった時に表示するテキスト</summary>
    [SerializeField]
    [Header("引き分けになった時に表示するテキスト")]
    Text _drawFinishText;

    [SerializeField]
    [Header("勝敗が決まった時に表示するテキスト")]
    Text _gameSetText;

    /// <summary>結果画面のパネル</summary>
    [SerializeField]
    [Header("結果画面のパネル")]
    Image _resultPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>Player1が持っている勝利ポイント</summary>
    /// <param name="FirstPlayerPoint">現在の勝利ポイント</param>
    public void FirstPlayerText(int FirstPlayerPoint) => _firstPlayerPointText.text = "Player1 " + FirstPlayerPoint.ToString() + "P";

    /// <summary>Player2が持っている勝利ポイント</summary>
    /// <param name="SecondPlayerPoint">現在の勝利ポイント</param>
    public void SecondPlayerText(int SecondPlayerPoint) => _secondPlayerPointText.text = "Player2 " + SecondPlayerPoint.ToString() + "P";
    /// <summary>オーバーフィニッシュが決まったときに表示</summary>
    public void OverFinishText() => _overFinishText.gameObject.SetActive(true);     
    /// <summary>スピンフィニッシュが決まったときに表示</summary>
    public void SpinFinishText() => _spinFinishText.gameObject.SetActive(true);
    /// <summary>バーストフィニッシュが決まった時に表示（未定）</summary>
    public void BurstFinishText() => _burstFinishText.gameObject.SetActive(true);
    /// <summary>ドローになった時に表示（未定）</summary>
    public void DrawFinishText() => _drawFinishText.gameObject.SetActive(true);

    /// <summary>決着がついたときに表示する</summary>
    /// <param name="playerName">プレイヤーの名前</param>
    public void GameSet(string playerName)
    {
        _gameSetText.text = playerName + " Win";
        _gameSetText.gameObject.SetActive(true);
    }
}
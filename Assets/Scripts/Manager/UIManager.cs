using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UIマネージャー
/// UIの表示は全てここで行う
/// </summary>
public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public Slider ShootPowerSlider => _shootPowerSlider;

    /// <summary>フィニッシュテキストの表示秒数</summary>
    [SerializeField]
    [Header("フィニッシュテキストの表示秒数(ミリ秒)")]
    int _seconds = 50;

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

    /// <summary>シュートする場所を決めるときに表示するテキスト</summary>
    [SerializeField]
    [Header("シュートする場所を決めるときに表示するテキスト")]
    Text _shootPosText;

    [SerializeField]
    [Header("パワーを決める時に表示するテキスト")]
    Text _shootPowerText;

    /// <summary>シュート時に表示するテキスト</summary>
    [SerializeField]
    [Header("シュート時に表示するテキスト")]
    Text _shootText;

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

    /// <summary>シュートパワーを決めるスライダー</summary>
    [SerializeField]
    [Header("シュートパワーを決めるスライダー")]
    Slider _shootPowerSlider;

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

    public void ShootPower(float changePower) => ShootPowerSlider.value += changePower;

    /// <summary>シュート時に表示するテキスト</summary>
    /// <param name="text"></param>
    public void ReadySetText(string text) => _shootText.text = text;

    
    /// <summary>どちらかがポイントを手に入れたときに数秒間表示するテキスト</summary>
    /// <param name="finish">勝ち方</param>
    public async void FinishText(UIFinish finish)
    {
        switch (finish)
        {
            case UIFinish.Over:
                _overFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _overFinishText.gameObject.SetActive(false);
                break;

            case UIFinish.Spin:
                _spinFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _spinFinishText.gameObject.SetActive(false);
                break;

            case UIFinish.Burst:
                _burstFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _burstFinishText.gameObject.SetActive(false);
                break;

            case UIFinish.Draw:
                _drawFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _drawFinishText.gameObject.SetActive(false);
                break;
        }
    }

    /// <summary>決着がついたときに表示する</summary>
    /// <param name="playerName">プレイヤーの名前</param>
    public void GameSet(string playerName)
    {
        _gameSetText.text = playerName + " Win";
        _gameSetText.gameObject.SetActive(true);
    }
}
public enum UIFinish
{
    Over,
    Spin,
    Burst,
    Draw
}
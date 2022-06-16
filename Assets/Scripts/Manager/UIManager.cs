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
    public List<Slider> ShootPowerSlider => _shootPowerSlider;

    /// <summary>フィニッシュテキストの表示秒数</summary>
    [SerializeField]
    [Header("フィニッシュテキストの表示秒数(ミリ秒)")]
    int _seconds = 300;

    [SerializeField]
    [Header("シュート前のカウントの表示秒数(ミリ秒)")]
    int _countSeconds = 1000;

    /// <summary>Player1の勝利ポイントのテキスト</summary>
    [SerializeField]
    [Header("Player1の勝利ポイントのテキスト")]
    Text _firstPlayerPointText;

    /// <summary>Player2の勝利ポイントのテキスト</summary>
    [SerializeField]
    [Header("Player2の勝利ポイントのテキスト")]
    Text _secondPlayerPointText;

    [SerializeField]
    [Header("Player1の所持金のテキスト")]
    Text _firstPlayerMoneyText;

    [SerializeField]
    [Header("Player2の所持金のテキスト")]
    Text _secondPlayerMoneyText;

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
    [Header("シュート時に表示するテキスト(Ready)")]
    Text _readyText;

    /// <summary>シュート時に表示するテキスト</summary>
    [SerializeField]
    [Header("シュート時に表示するテキスト(3)")]
    Text _threeText;

    /// <summary>シュート時に表示するテキスト</summary>
    [SerializeField]
    [Header("シュート時に表示するテキスト(2)")]
    Text _twoText;

    /// <summary>シュート時に表示するテキスト</summary>
    [SerializeField]
    [Header("シュート時に表示するテキスト(1)")]
    Text _oneText;

    /// <summary>シュート時に表示するテキスト</summary>
    [SerializeField]
    [Header("シュート時に表示するテキスト(GO)")]
    Text _goText;

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
    List<Slider> _shootPowerSlider = new List<Slider>();

    /// <summary>結果画面のパネル</summary>
    [SerializeField]
    [Header("結果画面のパネル")]
    Image _resultPanel;

    /// <summary>結果画面のパネル</summary>
    [SerializeField]
    [Header("シーン移動用画面のパネル")]
    Image _scenePanel;

    void Start()
    {
        if (_readyText) _readyText.gameObject.SetActive(false);
        if (_threeText) _threeText.gameObject.SetActive(false);
        if (_twoText) _twoText.gameObject.SetActive(false);
        if (_oneText) _oneText.gameObject.SetActive(false);
        if (_goText) _goText.gameObject.SetActive(false);
    }

    /// <summary>Player1が持っている勝利ポイント</summary>
    public void FirstPlayerText(int firstPlayerPoint) => _firstPlayerPointText.text = "Player1 " + firstPlayerPoint.ToString() + "P";

    /// <summary>Player2が持っている勝利ポイント</summary>
    public void SecondPlayerText(int secondPlayerPoint) => _secondPlayerPointText.text = "Player2 " + secondPlayerPoint.ToString() + "P";

    public void FirstPlayerMoney(int FirstPlayerMoney) => _firstPlayerMoneyText.text = "Player1 " + FirstPlayerMoney;

    public void SecondPlayerMoney(int SecondPlayerMoney) => _secondPlayerMoneyText.text = "Player2 " + SecondPlayerMoney;

    /// <summary>ラウンド数</summary>
    public void RoundText(int roundCount) => _roundText.text = "Round" + roundCount.ToString();

    /// <summary>表示するかどうかを変える</summary>
    public void DisplayShootPowerSlider(bool setActive) => _shootPowerSlider.ForEach(x => { x.gameObject.SetActive(setActive); });

    /// <summary>スライダーの値を変える</summary>
    public void ShootPower(float changePower,int number) => _shootPowerSlider[number].value += changePower;

    /// <summary>シュート時に表示するテキスト</summary>
    public async void ShootCountText()
    {
        _readyText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _readyText.gameObject.SetActive(false);
        _threeText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _threeText.gameObject.SetActive(false);
        _twoText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _twoText.gameObject.SetActive(false);
        _oneText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _oneText.gameObject.SetActive(false);
        _goText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _goText.gameObject.SetActive(false);
    }

    /// <summary>どちらかがポイントを手に入れたときに数秒間表示するテキスト</summary>
    /// <param name="finish">勝ち方</param>
    public async void FinishText(FinishUI finish)
    {
        switch (finish)
        {
            case FinishUI.Over:
                _overFinishText.gameObject.SetActive(true);              
                await Task.Delay(_seconds);
                _overFinishText.gameObject.SetActive(false);
                break;

            case FinishUI.Spin:
                _spinFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _spinFinishText.gameObject.SetActive(false);
                break;

            case FinishUI.Burst:
                _burstFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _burstFinishText.gameObject.SetActive(false);
                break;

            case FinishUI.Draw:
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
public enum FinishUI
{
    Over,
    Spin,
    Burst,
    Draw
}

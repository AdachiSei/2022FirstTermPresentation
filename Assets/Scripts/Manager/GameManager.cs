using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// ゲームマネージャー
/// 対戦ゲームなので勝敗の処理はここで行う
/// 貰える金額も決められる
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject FirstPlayer => _firstPlayer;

    public GameObject SecondPlayer => _secondPlayer;

    /// <summary>何ポイント先取で勝ちか</summary>
    [SerializeField]
    [Header("何ポイント先取で勝ちか")]
    [Range(1,100)]
    int _winPoints = 3;

    /// <summary>相手より長く回って勝利した時に貰えるポイント</summary>
    [SerializeField]
    [Header("相手より長く回った時に貰えるポイント")]
    [Range(0,100)]
    int _spinFinishPoints = 1;

    /// <summary>相手を場外に追い出した時に貰えるポイント</summary>
    [SerializeField]
    [Header("相手を場外に追い出した時に貰えるポイント")]
    [Range(0, 100)]
    int _overFinishPoints = 1;

    /// <summary>相手を破壊した時に貰えるポイント(実装未定)</summary>
    [SerializeField]
    [Header("相手を破壊した時に貰えるポイント(実装未定)")]
    [Range(0, 100)]
    int _burstFinishPoints = 2;

    /// <summary>試合後に必ず貰える金額</summary>
    [SerializeField]
    [Header("試合後に必ず貰える金額")]
    float _money;

    /// <summary>勝利後に貰える金額のボーナス</summary>
    [SerializeField]
    [Header("勝利時にもらえる金額のボーナス")]
    float _winMoney;

    /// <summary>相手より長く回る度に貰える金額のボーナス</summary>
    [SerializeField]
    [Header("相手より長く回る度に貰える金額のボーナス")]
    float _spinFinishBonus;

    /// <summary>相手を場外に追い出す度に貰える金額のボーナス</summary>
    [SerializeField]
    [Header("相手を場外に追い出す度に貰える金額のボーナス")]
    float _overFinishBonus;

    /// <summary>相手を破壊する度に貰える金額のボーナス(実装未定)</summary>
    [SerializeField]
    [Header("相手を破壊する度に貰える金額のボーナス(実装未定)")]
    float _burstFinishBonus;

    /// <summary>Player1のゲームオブジェクト</summary>
    GameObject _firstPlayer;
    /// <summary>Player2のゲームオブジェクト</summary>
    GameObject _secondPlayer;
    /// <summary>Player1が持っている勝利ポイント</summary>
    static int _firstPlayerPoint;
    /// <summary>Player2が持っている勝利ポイント</summary>
    static int _secondPlayerPoint;
    /// <summary>Player1のオーバー回数</summary>
    static int _firstPlayerOverCount;
    /// <summary>Player1のスピン回数</summary>
    static int _firstPlayerSpinCount;
    /// <summary>Player1のバースト回数</summary>
    static int _firstPlayerBurstCount;
    /// <summary>Player2のオーバー回数</summary>
    static int _secondPlayerOverCount;
    /// <summary>Player2のスピン回数</summary>
    static int _secondPlayerSpinCount;
    /// <summary>Player2のバースト回数</summary>
    static int _secondPlayerBurstCount;
    /// <summary>判定回数</summary>
    int _judgCount;
    /// <summary>ラウンド数</summary>
    static int _roundCount = 1;
    /// <summary>一回だけ反応するように切り替え</summary>
    bool _isJudg;
    /// <summary>Player1のTag</summary>
    const string FIRST_PLAYER_TAG = "Player";
    /// <summary>Player2のTag</summary>
    const string SECOND_PLAYER_TAG = "SecondPlayer";
    /// <summary>引き分けになる判定回数</summary>
    const int DRAW_COUNT = 2;
    /// <summary>一瞬待つ</summary>
    const int JUDG_TIME = 100;

    protected override void Awake()
    {
        base.Awake();
        _firstPlayer = GameObject.FindWithTag(FIRST_PLAYER_TAG);
        _secondPlayer = GameObject.FindWithTag(SECOND_PLAYER_TAG);
        _isJudg = true;
        UIManager.Instance.RoundText(_roundCount);
        UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
        UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
    }

    /// <summary>敵プレイヤーに勝利ポイントを追加</summary>
    /// <param name="enemyPlayrTag">敵プレイヤーのTag</param>
    public async void BattleFinish(string enemyPlayrTag, Finish finish)
    {
        if (_isJudg)
        {
            _judgCount++;//判定回数

            if (enemyPlayrTag == FIRST_PLAYER_TAG)//Player1のTagだったら
            {              
                await Task.Delay(JUDG_TIME);//一瞬待つ
                if (_judgCount >= DRAW_COUNT)//判定回数が2回以上なら
                {
                    UIManager.Instance.FinishText(FinishUI.Draw);//引き分け
                }
                else
                {
                    switch (finish)
                    {
                        case Finish.Over://オーバーなら
                            _firstPlayerPoint += _overFinishPoints;
                            _firstPlayerOverCount++;
                            UIManager.Instance.FinishText(FinishUI.Over);
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                        case Finish.Spin://スピンなら
                            _firstPlayerPoint += _spinFinishPoints;
                            _firstPlayerSpinCount++;
                            UIManager.Instance.FinishText(FinishUI.Spin);
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                        case Finish.Burst://バーストなら
                            _firstPlayerPoint += _burstFinishPoints;
                            _firstPlayerBurstCount++;
                            UIManager.Instance.FinishText(FinishUI.Burst);
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                    }
                }
            }

            //Player2のTagだったら
            else
            {
                await Task.Delay(JUDG_TIME);//一瞬待つ
                switch (_judgCount)//判定回数
                {
                    case DRAW_COUNT://判定回数が2回なら
                        UIManager.Instance.FinishText(FinishUI.Draw);//引き分け
                        break;
                    default://勝利ポイントを渡してテキストで表示
                        switch (finish)
                        {
                            case Finish.Over://オーバーなら
                                _secondPlayerPoint += _overFinishPoints;
                                _secondPlayerOverCount++;
                                UIManager.Instance.FinishText(FinishUI.Over);
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                            case Finish.Spin://スピンなら
                                _secondPlayerPoint += _spinFinishPoints;
                                _secondPlayerSpinCount++;
                                UIManager.Instance.FinishText(FinishUI.Spin);
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                            case Finish.Burst://バーストなら
                                _secondPlayerPoint += _burstFinishPoints;
                                _secondPlayerBurstCount++;
                                UIManager.Instance.FinishText(FinishUI.Burst);
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                        }
                        break;
                }
            }
            if(_isJudg)HalfTime();
            _isJudg = false;//２回目は勝敗を判定しないようにする           
        }
    }

    /// <summary>試合途中の休憩時間</summary>
    public async void HalfTime()
    {
        await Task.Delay(5000);//ちょっと待つ
        if(_firstPlayerPoint >= _winPoints)
        {
            UIManager.Instance.GameSet("Player1");
            MoneyManager.Instance.ChangeMoney(Money.FirstPlayer, (int)_winMoney + (int)_money);
            MoneyManager.Instance.ChangeMoney(Money.SecondPlayer, (int)_money);
        }
        else if(_secondPlayerPoint >= _winPoints)
        {
            UIManager.Instance.GameSet("Player2");
            MoneyManager.Instance.ChangeMoney(Money.FirstPlayer, (int)_money);
            MoneyManager.Instance.ChangeMoney(Money.SecondPlayer, (int)_winMoney + (int)_money);
        }
        else
        {
            _roundCount++;//ラウンド数を増やす
            UIManager.Instance.RoundText(_roundCount);
            EndGame();
        }
    }

    /// <summary>ゲーム終了</summary>
    void EndGame()
    {
        SceneLoader.Instance.LoadScene("BattleScene");
    }
}

public enum Finish
{ 
    Over,
    Spin,
    Burst,
    Draw
}


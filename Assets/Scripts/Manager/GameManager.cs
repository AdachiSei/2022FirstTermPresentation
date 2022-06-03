using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ゲームマネージャー
/// 対戦ゲームなので勝敗の処理はここで行う
/// 貰える金額も決められる
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>何ポイント先取で勝ちか</summary>
    [SerializeField]
    [Header("何ポイント先取で勝ちか")]
    [Range(1,100)]
    int _points = 3;

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
    int _money;

    /// <summary>勝利後に貰える金額のボーナス</summary>
    [SerializeField]
    [Header("勝利時にもらえる金額のボーナス")]
    float _victoryMoney;

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

    /// <summary>Player1のTag</summary>
    [SerializeField]
    [Header("Player1のTag")]
    string _firstPlayerTag = "Player";

    /// <summary>Player2のTag</summary>
    [SerializeField]
    [Header("Player2のTag")]
    string _secondPlayerTag = "Player2";

    /// <summary>PlaneのCollider</summary>
    [SerializeField]
    [Header("PlaneのCollider")]
    Collider _collider;

    Rigidbody _rb;

    /// <summary>Player1のゲームオブジェクト</summary>
    GameObject _firstPlayer;
    /// <summary>Player2のゲームオブジェクト</summary>
    GameObject _secondPlayer;
    /// <summary>Player1が持っている勝利ポイント</summary>
    int _firstPlayerPoint;
    /// <summary>Player2が持っている勝利ポイント</summary>
    int _secondPlayerPoint;

    protected override void Awake()
    {
        base.Awake();
        _firstPlayer = GameObject.FindWithTag(_firstPlayerTag);
        _secondPlayer = GameObject.FindWithTag(_secondPlayerTag);
    }


    void Update()
    {

    }

}

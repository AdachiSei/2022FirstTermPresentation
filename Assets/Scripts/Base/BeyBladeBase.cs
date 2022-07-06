using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ベイブレードの基底クラス
/// 回転させる処理、勝利判定はここで行う
/// </summary>
public class BeyBladeBase : MonoBehaviour
{
    public Rigidbody Rb => _rb;
    /// <summary>移動スピードのプロパティ</summary>
    public float Speed => _speed;
    /// <summary>回転スピードのプロパティ</summary>
    public float RotSpeed => _rotSpeed;
    /// <summary>ターゲットとなるスタジアムの中心を示す空のオブジェクトのプロパティ</summary>
    public GameObject Target => _target;
    /// <summary>敵PlayerのTagのプロパティ</summary>
    public string EnemyPlayerTag => _enemyPlayerTag;
    /// <summary>WallのTagのプロパティ</summary>
    public string WallTag => _wallTag;
    /// <summary>FloorのTagのプロパティ</summary>
    public string FloorTag => _floorTag;
    /// <summary>体力のプロパティ</summary>
    public int HP => _hp;

    /// <summary>体力</summary>
    [SerializeField]
    [Header("体力")]
    int _hp;

    /// <summary>移動スピード</summary>
    [SerializeField]
    [Header("移動スピード")]
    float _speed = 2f;

    /// <summary>回転スピード</summary>
    [SerializeField]
    [Header("回転スピード")]
    float _rotSpeed = 10;

    [SerializeField]
    [Header("回転値の減少値")]
    float _rotSpeedDown = 0.00001f;

    /// <summary>ターゲットとなるスタジアムの中心を示す空のオブジェクトのTag</summary>
    [SerializeField]
    [Header("ターゲットとなるスタジアムの中心のオブジェクトのTag")]
    string _targetTag;

    /// <summary>WallのTag</summary>
    [SerializeField]
    [Header("WallのTag")]
    string _wallTag = "Wall";

    /// <summary>FloorのTag</summary>
    [SerializeField]
    [Header("FloorのTag")]
    string _floorTag = "Floor";

    Rigidbody _rb;
    Collider _collider;
    Material _material;
    /// <summary>ターゲットとなるオブジェクト</summary>
    GameObject _target;
    /// <summary>1回だけ実行</summary>
    bool _oneJudg;
    /// <summary>敵PlayerのTag</summary>
    string _enemyPlayerTag;
    /// <summary>Player1のTag</summary>
    const string FIRST_PLAYER_TAG = "Player";
    /// <summary>Player2のTag</summary>
    const string SECOND_PLAYER_TAG = "SecondPlayer";

    protected virtual void Awake()
    {
        //_rb = GetComponent<Rigidbody>();
        if (TryGetComponent(out _rb))
        {
            Debug.Log(_rb);
        }
        _collider = GetComponent<Collider>();
        _material = GetComponent<Renderer>().material;
        _collider.isTrigger = true;
        
        _target = GameObject.FindWithTag(_targetTag);

        switch (gameObject.tag)
        {
            case FIRST_PLAYER_TAG:
                _enemyPlayerTag = SECOND_PLAYER_TAG;
                _material.color = ColorManager.Instance.FirstPlayerColor;
                break;
            case SECOND_PLAYER_TAG:
                _enemyPlayerTag = FIRST_PLAYER_TAG;
                _material.color = ColorManager.Instance.SecondPlayerColor;
                break;
        }

        _oneJudg = true;
        //スクリプトを無効にする
        enabled = false;
    }

    protected virtual void Update()
    {
        BeyRotates();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //敵に当たったら
        if (collision.gameObject.tag == _enemyPlayerTag)
        {
            _rotSpeed -= 1;
        }
        //場外の床に当たったら
        else if (collision.gameObject.tag == _floorTag && _oneJudg)
        {
            //GameManagerに伝えるオーバーフィニッシュの処理
            GameManager.Instance.BattleFinish(_enemyPlayerTag, Finish.Over);
            _oneJudg = false;
        }
        _rotSpeed -= _rotSpeedDown;
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        //壁に当たったら
        if (collision.gameObject.tag == WallTag)
        {
            //自分の体制を整える
            transform.rotation = Quaternion.Euler(-180f, transform.rotation.y, 0f);
        }
    }

    protected virtual void BeyRotates()
    {
        //回転
        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, _rotSpeed, _rb.angularVelocity.z);
        //回転スピードを下げる
        if (_rotSpeed > 0) _rotSpeed -= _rotSpeedDown;
        //回転スピードが0になったら止まる
        else
        {
            if (_oneJudg)
            {
                //GameManagerに伝えるスピンフィニッシュの処理
                GameManager.Instance.BattleFinish(_enemyPlayerTag, Finish.Spin);
                _oneJudg = false;
            }
            _rotSpeed = 0;
        }
        //回転スピードがほぼなくなったら体勢を崩す
        if (_rotSpeed <= 10f) _rb.constraints = RigidbodyConstraints.None;
    }
    public void ChangePower(float number)
    {
        _rotSpeed *= number;
    }
}


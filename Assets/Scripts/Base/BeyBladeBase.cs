using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ベイブレードのベースクラス
/// </summary>
public class BeyBladeBase : MonoBehaviour
{
    public Rigidbody Rb => _rb;
    /// <summary>ターゲットとなるスタジアムの中心を示す空のオブジェクトのプロパティ</summary>
    public GameObject Target => _target;
    /// <summary>敵PlayerのTagのプロパティ</summary>
    public string EnemyPlayerTag => _enemyPlayerTag;
    /// <summary>WallのTagのプロパティ</summary>
    public string WallTag => _wallTag;
    /// <summary>FloorのTagのプロパティ</summary>
    public string FloorTag => _floorTag;
    /// <summary>移動スピードのプロパティ</summary>
    public float Speed { get => _speed; set =>  _speed = value; }
    /// <summary>回転スピードのプロパティ</summary>
    public float RotSpeed{ get =>_rotSpeed; set => _rotSpeed = value; }   
    /// <summary>切り替え用のプロパティ</summary>
    public bool Switch { get => _switch; set => _switch = value; }

    /// <summary>ターゲットとなるスタジアムの中心を示す空のオブジェクトのTag</summary>
    [SerializeField]
    [Header("ターゲットとなるスタジアムの中心のオブジェクトのTag")]
    string _targetTag;

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

    /// <summary>敵PlayerのTag</summary>
    [SerializeField]
    [Header("敵PlayerのTag")]
    string _enemyPlayerTag = "Player";

    /// <summary>WallのTag</summary>
    [SerializeField]
    [Header("WallのTag")]
    string _wallTag = "Wall";

    /// <summary>FloorのTag</summary>
    [SerializeField]
    [Header("FloorのTag")]
    string _floorTag = "Floor";

    Rigidbody _rb;
    /// <summary>ターゲットとなるオブジェクト</summary>
    GameObject _target;
    /// <summary>切り替え用</summary>
    bool _switch;
    /// <summary>回転値Xを固定するためのメンバー変数</summary>
    RigidbodyConstraints freezeRotX = RigidbodyConstraints.FreezeRotationX;
    /// <summary>回転値Zを固定するためのメンバー変数</summary>
    RigidbodyConstraints freezeRotZ = RigidbodyConstraints.FreezeRotationZ;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _target = GameObject.FindWithTag(_targetTag);
        //回転値のXとZを固定
        _rb.constraints = freezeRotX | freezeRotZ;
    }

    protected virtual void Update()
    {
        //回転
        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, _rotSpeed, _rb.angularVelocity.z);
        //回転スピードを下げる
        if (_rotSpeed > 0) _rotSpeed -= _rotSpeedDown;
        //回転スピードが0になったら止まる
        else
        {
            _rotSpeed = 0;
            //GameManagerに伝える処理を書く
        }
        //回転スピードがほぼなくなったら体勢を崩す
        if (_rotSpeed <= 10f) _rb.constraints = RigidbodyConstraints.None;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //敵に当たったら
        if (collision.gameObject.tag == _enemyPlayerTag)
        {
            //自分の体制が崩れる
            _rb.constraints = freezeRotX & freezeRotZ;
            _switch = true;
        }
        //場外の床に当たったら
        else if(collision.gameObject.tag == _floorTag)
        {
            //GameManagerに伝える処理を書く
        }
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        //壁に当たったら
        if(collision.gameObject.tag == WallTag && _switch)
        {
            //自分の体制を整える
            transform.rotation = Quaternion.Euler(-180f, transform.rotation.y, 0f);
            ////回転値のXとZを固定
            _rb.constraints = freezeRotX | freezeRotZ;
            _switch = false;
        }
    }
}

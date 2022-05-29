using UnityEngine;

public class BeyBladeBase : MonoBehaviour
{
    public Rigidbody Rb => _rb;
    /// <summary>ターゲットとなるオブジェクトのプロパティ</summary>
    public GameObject Target => _target;
    public string PlayerTag => _playerTag;
    public string WallTag => _wallTag;
    /// <summary>移動スピードのプロパティ</summary>
    public float Speed { get => _speed; set => _speed = value; }
    /// <summary>回転スピードのプロパティ</summary>
    public float RotSpeed{ get =>_rotSpeed; set => _rotSpeed = value; }   
    /// <summary>半径のプロパティ</summary>
    public float Radius { get => _radius; set => _radius = value; }
    /// <summary>切り替え用のプロパティ</summary>
    public bool Switch { get => _switch; set => _switch = value; }

    /// <summary>ターゲットとなるゲームオブジェクト</summary>
    [SerializeField]
    [Header("ターゲット")]
    GameObject _target;

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

    /// <summary>半径</summary>
    [SerializeField]
    [Header("半径")]
    float _radius = 30;

    /// <summary>PlayerのTag</summary>
    [SerializeField]
    [Header("PlayerのTag")]
    string _playerTag = "Player";

    /// <summary>WallのTag</summary>
    [SerializeField]
    [Header("WallのTag")]
    string _wallTag = "Wall";

    Rigidbody _rb;
    float _timer;
    /// <summary>切り替え用</summary>
    bool _switch;

    //回転値を固定する用
    RigidbodyConstraints freezeRotX = RigidbodyConstraints.FreezeRotationX;
    RigidbodyConstraints freezeRotZ = RigidbodyConstraints.FreezeRotationZ;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        //回転値のXとZを固定
        _rb.constraints = freezeRotX | freezeRotZ;
    }

    protected virtual void FixedUpdate()
    {
        _timer += Time.deltaTime;
        //回転
        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, _rotSpeed, _rb.angularVelocity.z);
        //回転スピードを下げる
        if (_rotSpeed > 0) _rotSpeed -= _rotSpeedDown;
        else _rotSpeed = 0;
        //////移動速度を下げる
        //if (_speed > 0) _speed -= _rotSpeedDown / _rotSpeed;
        //else _speed = 0;
        if (_rotSpeed <= 1f) _rb.constraints = RigidbodyConstraints.None;
        if (_rotSpeed >= RotSpeed) _radius -= _rotSpeedDown;
        else _radius = 0;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //敵に触れたら
        if(collision.gameObject.tag == PlayerTag)
        {
            //自分の体制が崩れる
            _rb.constraints = freezeRotX & freezeRotZ;
            _timer = 0;
            _switch = true;
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

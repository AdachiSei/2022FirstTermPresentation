using UnityEngine;

public class BeyBladeBase : MonoBehaviour
{
    public Rigidbody Rb => _rb;
    /// <summary>�^�[�Q�b�g�ƂȂ�I�u�W�F�N�g�̃v���p�e�B</summary>
    public GameObject Target => _target;
    public string PlayerTag => _playerTag;
    public string WallTag => _wallTag;
    /// <summary>�ړ��X�s�[�h�̃v���p�e�B</summary>
    public float Speed { get => _speed; set => _speed = value; }
    /// <summary>��]�X�s�[�h�̃v���p�e�B</summary>
    public float RotSpeed{ get =>_rotSpeed; set => _rotSpeed = value; }   
    /// <summary>���a�̃v���p�e�B</summary>
    public float Radius { get => _radius; set => _radius = value; }
    /// <summary>�؂�ւ��p�̃v���p�e�B</summary>
    public bool Switch { get => _switch; set => _switch = value; }

    /// <summary>�^�[�Q�b�g�ƂȂ�Q�[���I�u�W�F�N�g</summary>
    [SerializeField]
    [Header("�^�[�Q�b�g")]
    GameObject _target;

    /// <summary>�ړ��X�s�[�h</summary>
    [SerializeField]
    [Header("�ړ��X�s�[�h")]
    float _speed = 2f;
    
    /// <summary>��]�X�s�[�h</summary>
    [SerializeField]
    [Header("��]�X�s�[�h")]
    float _rotSpeed = 10;

    [SerializeField]
    [Header("��]�l�̌����l")]
    float _rotSpeedDown = 0.00001f;

    /// <summary>���a</summary>
    [SerializeField]
    [Header("���a")]
    float _radius = 30;

    /// <summary>Player��Tag</summary>
    [SerializeField]
    [Header("Player��Tag")]
    string _playerTag = "Player";

    /// <summary>Wall��Tag</summary>
    [SerializeField]
    [Header("Wall��Tag")]
    string _wallTag = "Wall";

    Rigidbody _rb;
    float _timer;
    /// <summary>�؂�ւ��p</summary>
    bool _switch;

    //��]�l���Œ肷��p
    RigidbodyConstraints freezeRotX = RigidbodyConstraints.FreezeRotationX;
    RigidbodyConstraints freezeRotZ = RigidbodyConstraints.FreezeRotationZ;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        //��]�l��X��Z���Œ�
        _rb.constraints = freezeRotX | freezeRotZ;
    }

    protected virtual void FixedUpdate()
    {
        _timer += Time.deltaTime;
        //��]
        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, _rotSpeed, _rb.angularVelocity.z);
        //��]�X�s�[�h��������
        if (_rotSpeed > 0) _rotSpeed -= _rotSpeedDown;
        else _rotSpeed = 0;
        //////�ړ����x��������
        //if (_speed > 0) _speed -= _rotSpeedDown / _rotSpeed;
        //else _speed = 0;
        if (_rotSpeed <= 1f) _rb.constraints = RigidbodyConstraints.None;
        if (_rotSpeed >= RotSpeed) _radius -= _rotSpeedDown;
        else _radius = 0;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //�G�ɐG�ꂽ��
        if(collision.gameObject.tag == PlayerTag)
        {
            //�����̑̐��������
            _rb.constraints = freezeRotX & freezeRotZ;
            _timer = 0;
            _switch = true;
        }      
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        //�ǂɓ���������
        if(collision.gameObject.tag == WallTag && _switch)
        {
            //�����̑̐��𐮂���
            transform.rotation = Quaternion.Euler(-180f, transform.rotation.y, 0f);
            ////��]�l��X��Z���Œ�
            _rb.constraints = freezeRotX | freezeRotZ;
            _switch = false;
        }
    }
}

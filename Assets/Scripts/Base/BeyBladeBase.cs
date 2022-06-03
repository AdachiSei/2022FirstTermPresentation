using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �x�C�u���[�h�̃x�[�X�N���X
/// </summary>
public class BeyBladeBase : MonoBehaviour
{
    public Rigidbody Rb => _rb;
    /// <summary>�^�[�Q�b�g�ƂȂ�X�^�W�A���̒��S��������̃I�u�W�F�N�g�̃v���p�e�B</summary>
    public GameObject Target => _target;
    /// <summary>�GPlayer��Tag�̃v���p�e�B</summary>
    public string EnemyPlayerTag => _enemyPlayerTag;
    /// <summary>Wall��Tag�̃v���p�e�B</summary>
    public string WallTag => _wallTag;
    /// <summary>Floor��Tag�̃v���p�e�B</summary>
    public string FloorTag => _floorTag;
    /// <summary>�ړ��X�s�[�h�̃v���p�e�B</summary>
    public float Speed { get => _speed; set =>  _speed = value; }
    /// <summary>��]�X�s�[�h�̃v���p�e�B</summary>
    public float RotSpeed{ get =>_rotSpeed; set => _rotSpeed = value; }   
    /// <summary>�؂�ւ��p�̃v���p�e�B</summary>
    public bool Switch { get => _switch; set => _switch = value; }

    /// <summary>�^�[�Q�b�g�ƂȂ�X�^�W�A���̒��S��������̃I�u�W�F�N�g��Tag</summary>
    [SerializeField]
    [Header("�^�[�Q�b�g�ƂȂ�X�^�W�A���̒��S�̃I�u�W�F�N�g��Tag")]
    string _targetTag;

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

    /// <summary>�GPlayer��Tag</summary>
    [SerializeField]
    [Header("�GPlayer��Tag")]
    string _enemyPlayerTag = "Player";

    /// <summary>Wall��Tag</summary>
    [SerializeField]
    [Header("Wall��Tag")]
    string _wallTag = "Wall";

    /// <summary>Floor��Tag</summary>
    [SerializeField]
    [Header("Floor��Tag")]
    string _floorTag = "Floor";

    Rigidbody _rb;
    /// <summary>�^�[�Q�b�g�ƂȂ�I�u�W�F�N�g</summary>
    GameObject _target;
    /// <summary>�؂�ւ��p</summary>
    bool _switch;
    /// <summary>��]�lX���Œ肷�邽�߂̃����o�[�ϐ�</summary>
    RigidbodyConstraints freezeRotX = RigidbodyConstraints.FreezeRotationX;
    /// <summary>��]�lZ���Œ肷�邽�߂̃����o�[�ϐ�</summary>
    RigidbodyConstraints freezeRotZ = RigidbodyConstraints.FreezeRotationZ;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _target = GameObject.FindWithTag(_targetTag);
        //��]�l��X��Z���Œ�
        _rb.constraints = freezeRotX | freezeRotZ;
    }

    protected virtual void Update()
    {
        //��]
        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, _rotSpeed, _rb.angularVelocity.z);
        //��]�X�s�[�h��������
        if (_rotSpeed > 0) _rotSpeed -= _rotSpeedDown;
        //��]�X�s�[�h��0�ɂȂ�����~�܂�
        else
        {
            _rotSpeed = 0;
            //GameManager�ɓ`���鏈��������
        }
        //��]�X�s�[�h���قڂȂ��Ȃ�����̐������
        if (_rotSpeed <= 10f) _rb.constraints = RigidbodyConstraints.None;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //�G�ɓ���������
        if (collision.gameObject.tag == _enemyPlayerTag)
        {
            //�����̑̐��������
            _rb.constraints = freezeRotX & freezeRotZ;
            _switch = true;
        }
        //��O�̏��ɓ���������
        else if(collision.gameObject.tag == _floorTag)
        {
            //GameManager�ɓ`���鏈��������
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

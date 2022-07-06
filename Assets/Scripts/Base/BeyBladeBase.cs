using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �x�C�u���[�h�̊��N���X
/// ��]�����鏈���A��������͂����ōs��
/// </summary>
public class BeyBladeBase : MonoBehaviour
{
    public Rigidbody Rb => _rb;
    /// <summary>�ړ��X�s�[�h�̃v���p�e�B</summary>
    public float Speed => _speed;
    /// <summary>��]�X�s�[�h�̃v���p�e�B</summary>
    public float RotSpeed => _rotSpeed;
    /// <summary>�^�[�Q�b�g�ƂȂ�X�^�W�A���̒��S��������̃I�u�W�F�N�g�̃v���p�e�B</summary>
    public GameObject Target => _target;
    /// <summary>�GPlayer��Tag�̃v���p�e�B</summary>
    public string EnemyPlayerTag => _enemyPlayerTag;
    /// <summary>Wall��Tag�̃v���p�e�B</summary>
    public string WallTag => _wallTag;
    /// <summary>Floor��Tag�̃v���p�e�B</summary>
    public string FloorTag => _floorTag;
    /// <summary>�̗͂̃v���p�e�B</summary>
    public int HP => _hp;

    /// <summary>�̗�</summary>
    [SerializeField]
    [Header("�̗�")]
    int _hp;

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

    /// <summary>�^�[�Q�b�g�ƂȂ�X�^�W�A���̒��S��������̃I�u�W�F�N�g��Tag</summary>
    [SerializeField]
    [Header("�^�[�Q�b�g�ƂȂ�X�^�W�A���̒��S�̃I�u�W�F�N�g��Tag")]
    string _targetTag;

    /// <summary>Wall��Tag</summary>
    [SerializeField]
    [Header("Wall��Tag")]
    string _wallTag = "Wall";

    /// <summary>Floor��Tag</summary>
    [SerializeField]
    [Header("Floor��Tag")]
    string _floorTag = "Floor";

    Rigidbody _rb;
    Collider _collider;
    Material _material;
    /// <summary>�^�[�Q�b�g�ƂȂ�I�u�W�F�N�g</summary>
    GameObject _target;
    /// <summary>1�񂾂����s</summary>
    bool _oneJudg;
    /// <summary>�GPlayer��Tag</summary>
    string _enemyPlayerTag;
    /// <summary>Player1��Tag</summary>
    const string FIRST_PLAYER_TAG = "Player";
    /// <summary>Player2��Tag</summary>
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
        //�X�N���v�g�𖳌��ɂ���
        enabled = false;
    }

    protected virtual void Update()
    {
        BeyRotates();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //�G�ɓ���������
        if (collision.gameObject.tag == _enemyPlayerTag)
        {
            _rotSpeed -= 1;
        }
        //��O�̏��ɓ���������
        else if (collision.gameObject.tag == _floorTag && _oneJudg)
        {
            //GameManager�ɓ`����I�[�o�[�t�B�j�b�V���̏���
            GameManager.Instance.BattleFinish(_enemyPlayerTag, Finish.Over);
            _oneJudg = false;
        }
        _rotSpeed -= _rotSpeedDown;
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        //�ǂɓ���������
        if (collision.gameObject.tag == WallTag)
        {
            //�����̑̐��𐮂���
            transform.rotation = Quaternion.Euler(-180f, transform.rotation.y, 0f);
        }
    }

    protected virtual void BeyRotates()
    {
        //��]
        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, _rotSpeed, _rb.angularVelocity.z);
        //��]�X�s�[�h��������
        if (_rotSpeed > 0) _rotSpeed -= _rotSpeedDown;
        //��]�X�s�[�h��0�ɂȂ�����~�܂�
        else
        {
            if (_oneJudg)
            {
                //GameManager�ɓ`����X�s���t�B�j�b�V���̏���
                GameManager.Instance.BattleFinish(_enemyPlayerTag, Finish.Spin);
                _oneJudg = false;
            }
            _rotSpeed = 0;
        }
        //��]�X�s�[�h���قڂȂ��Ȃ�����̐������
        if (_rotSpeed <= 10f) _rb.constraints = RigidbodyConstraints.None;
    }
    public void ChangePower(float number)
    {
        _rotSpeed *= number;
    }
}


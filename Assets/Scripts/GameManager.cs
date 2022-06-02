using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �Q�[���}�l�[�W���[
/// �ΐ�Q�[���Ȃ̂ŏ��s�̏����͂����ōs��
/// �Ⴆ����z�����߂���
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>���|�C���g���ŏ�����</summary>
    [SerializeField]
    [Header("���|�C���g���ŏ�����")]
    [Range(1,100)]
    int _points = 3;

    /// <summary>�����蒷������ď����������ɖႦ��|�C���g</summary>
    [SerializeField]
    [Header("�����蒷����������ɖႦ��|�C���g")]
    [Range(0,100)]
    int _spinFinishPoints = 1;

    /// <summary>�������O�ɒǂ��o�������ɖႦ��|�C���g</summary>
    [SerializeField]
    [Header("�������O�ɒǂ��o�������ɖႦ��|�C���g")]
    [Range(0, 100)]
    int _overFinishPoints = 1;

    /// <summary>�����j�󂵂����ɖႦ��|�C���g(��������)</summary>
    [SerializeField]
    [Header("�����j�󂵂����ɖႦ��|�C���g(��������)")]
    [Range(0, 100)]
    int _burstFinishPoints = 2;

    /// <summary>������ɕK���Ⴆ����z</summary>
    [SerializeField]
    [Header("������ɕK���Ⴆ����z")]
    int _money;

    /// <summary>������ɖႦ����z�̃{�[�i�X</summary>
    [SerializeField]
    [Header("�������ɂ��炦����z�̃{�[�i�X")]
    float _victoryMoney;

    /// <summary>�����蒷�����x�ɖႦ����z�̃{�[�i�X</summary>
    [SerializeField]
    [Header("�����蒷�����x�ɖႦ����z�̃{�[�i�X")]
    float _spinFinishBonus;

    /// <summary>�������O�ɒǂ��o���x�ɖႦ����z�̃{�[�i�X</summary>
    [SerializeField]
    [Header("�������O�ɒǂ��o���x�ɖႦ����z�̃{�[�i�X")]
    float _overFinishBonus;

    /// <summary>�����j�󂷂�x�ɖႦ����z�̃{�[�i�X(��������)</summary>
    [SerializeField]
    [Header("�����j�󂷂�x�ɖႦ����z�̃{�[�i�X(��������)")]
    float _burstFinishBonus;

    /// <summary>Player1��Tag</summary>
    [SerializeField]
    [Header("Player1��Tag")]
    string _firstPlayerTag = "Player";

    /// <summary>Player2��Tag</summary>
    [SerializeField]
    [Header("Player2��Tag")]
    string _secondPlayerTag = "Player2";

    /// <summary>Plane��Collider</summary>
    [SerializeField]
    [Header("Plane��Collider")]
    Collider _collider;

    Rigidbody _rb;

    /// <summary>Player1�̃Q�[���I�u�W�F�N�g</summary>
    GameObject _firstPlayer;
    /// <summary>Player2�̃Q�[���I�u�W�F�N�g</summary>
    GameObject _secondPlayer;
    /// <summary>Player1�������Ă��鏟���|�C���g</summary>
    int _firstPlayerPoint;
    /// <summary>Player2�������Ă��鏟���|�C���g</summary>
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

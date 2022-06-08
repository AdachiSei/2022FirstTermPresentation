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
    /// <summary>Player1�������Ă��鏟���|�C���g�̃v���p�e�B</summary>
    public int FirstPlayerPoint => _firstPlayerPoint;

    /// <summaryPlayer2�������Ă��鏟���|�C���g�̃v���p�e�B</summary>
    public int SecondPlayerPoint => _secondPlayerPoint;

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

    Rigidbody _rb;
    /// <summary>Player1�̃Q�[���I�u�W�F�N�g</summary>
    GameObject _firstPlayer;
    /// <summary>Player2�̃Q�[���I�u�W�F�N�g</summary>
    GameObject _secondPlayer;
    /// <summary>Player1�������Ă��鏟���|�C���g</summary>
    int _firstPlayerPoint;
    /// <summary>Player2�������Ă��鏟���|�C���g</summary>
    int _secondPlayerPoint;

    /// <summary>Player1��Tag</summary>
    const string FIRST_PLAYER_TAG = "Player";
    /// <summary>Player2��Tag</summary>
    const string SECOND_PLAYER_TAG = "SecondPlayer";

    protected override void Awake()
    {
        base.Awake();
        _firstPlayer = GameObject.FindWithTag(FIRST_PLAYER_TAG);
        _secondPlayer = GameObject.FindWithTag(SECOND_PLAYER_TAG);
    }


    void Update()
    {

    }


    /// <summary>�G�v���C���[�ɏ����|�C���g��ǉ�</summary>
    /// <param name="playerTag">�G�v���C���[��Tag </param>
    public void OverFinish(string enemyPlayerTag)
    {
        switch (enemyPlayerTag)
        {
            case FIRST_PLAYER_TAG://Player1�Ȃ�
                _firstPlayerPoint += _overFinishPoints;
                UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                break;
            case SECOND_PLAYER_TAG://Player2�Ȃ�
                _secondPlayerPoint += _overFinishPoints;
                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                break;
        }
        UIManager.Instance.OverFinishText();
        Debug.Log("over");
    }

    /// <summary>�G�v���C���[�ɏ����|�C���g��ǉ�</summary>
    /// <param name="enemyPlayrTag">�G�v���C���[��Tag</param>
    public void SpinFinish(string enemyPlayrTag)
    {
        switch(enemyPlayrTag)
        {
            case FIRST_PLAYER_TAG://Player1�Ȃ�
                _firstPlayerPoint += _spinFinishPoints;
                UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                break;
            case SECOND_PLAYER_TAG://Player2�Ȃ�
                _secondPlayerPoint += _spinFinishPoints;
                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                break;
        }
        UIManager.Instance.SpinFinishText();
        Debug.Log("spin");
    }

    /// <summary>�G�v���C���[�ɏ����|�C���g��ǉ�(����)</summary>
    /// <param name="enemyPlayerTag"></param>
    public void BurstFinish(string enemyPlayerTag)
    {
        switch (enemyPlayerTag)
        {
            case FIRST_PLAYER_TAG://Player1�Ȃ�
                _firstPlayerPoint += _burstFinishPoints;
                UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                break;
            case SECOND_PLAYER_TAG://Player2�Ȃ�
                _secondPlayerPoint += _burstFinishPoints;
                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                break;
        }
        UIManager.Instance.BurstFinishText();
    }

    /// <summary>�Q�[���I��</summary>
    void EndGame()
    {

    }
}

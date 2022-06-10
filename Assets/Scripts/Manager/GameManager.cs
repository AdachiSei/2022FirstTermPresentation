using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    int _winPoints = 3;

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
    float _winMoney;

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
    /// <summary>Player1�̃I�[�o�[��</summary>
    int _firstPlayerOverCount;
    /// <summary>Player1�̃X�s����</summary>
    int _firstPlayerSpinCount;
    /// <summary>Player1�̃o�[�X�g��</summary>
    int _firstPlayerBurstCount;
    /// <summary>Player2�̃I�[�o�[��</summary>
    int _secondPlayerOverCount;
    /// <summary>Player2�̃X�s����</summary>
    int _secondPlayerSpinCount;
    /// <summary>Player2�̃o�[�X�g��</summary>
    int _secondPlayerBurstCount;
    /// <summary>�����</summary>
    int _judgCount;
    /// <summary>���E���h��</summary>
    int _roundCount = 1;
    /// <summary>��񂾂���������悤�ɐ؂�ւ�</summary>
    bool _isJudg;
    /// <summary>Player1��Tag</summary>
    const string FIRST_PLAYER_TAG = "Player";
    /// <summary>Player2��Tag</summary>
    const string SECOND_PLAYER_TAG = "SecondPlayer";
    /// <summary>���������ɂȂ锻���</summary>
    const int DRAW_COUNT = 2;
    /// <summary>��u�҂�</summary>
    const int JUDG_TIME = 1;

    protected override void Awake()
    {
        base.Awake();
        _firstPlayer = GameObject.FindWithTag(FIRST_PLAYER_TAG);
        _secondPlayer = GameObject.FindWithTag(SECOND_PLAYER_TAG);
        _isJudg = true;
        //�X�N���v�g��L���ɂ���
        //_firstPlayer.GetComponent<BeyBladeBase>().enabled = true;
        //_secondPlayer.GetComponent<BeyBladeBase>().enabled = true;
    }

    /// <summary>�G�v���C���[�ɏ����|�C���g��ǉ�</summary>
    /// <param name="enemyPlayrTag">�G�v���C���[��Tag</param>
    public async void BattleFinish(string enemyPlayrTag, Finish finish)
    {
        if (_isJudg)
        {
            _judgCount++;//�����

            if (enemyPlayrTag == FIRST_PLAYER_TAG)//Player1��Tag��������
            {              
                await Task.Delay(JUDG_TIME);//��u�҂�
                if (_judgCount >= DRAW_COUNT)//����񐔂�2��ȏ�Ȃ�
                {
                    UIManager.Instance.DrawFinishText();//��������
                }
                else
                {
                    switch (finish)
                    {
                        case Finish.Over://�I�[�o�[�Ȃ�
                            _firstPlayerPoint += _overFinishPoints;
                            _firstPlayerOverCount++;
                            UIManager.Instance.FinishText(Finish.Over);
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                        case Finish.Spin://�X�s���Ȃ�
                            _firstPlayerPoint += _spinFinishPoints;
                            _firstPlayerSpinCount++;
                            UIManager.Instance.SpinFinishText();
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                        case Finish.Burst://�o�[�X�g�Ȃ�
                            _firstPlayerPoint += _burstFinishPoints;
                            _firstPlayerBurstCount++;
                            UIManager.Instance.BurstFinishText();
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                    }
                }
            }

            //Player2��Tag��������
            else
            {
                await Task.Delay(JUDG_TIME);//��u�҂�
                switch (_judgCount)//�����
                {
                    case DRAW_COUNT://����񐔂�2��Ȃ�
                        UIManager.Instance.DrawFinishText();//��������
                        break;
                    default://�����|�C���g��n���ăe�L�X�g�ŕ\��
                        switch (finish)
                        {
                            case Finish.Over://�I�[�o�[�Ȃ�
                                _secondPlayerPoint += _overFinishPoints;
                                _secondPlayerOverCount++;
                                UIManager.Instance.OverFinishText();
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                            case Finish.Spin://�X�s���Ȃ�
                                _secondPlayerPoint += _spinFinishPoints;
                                _secondPlayerSpinCount++;
                                UIManager.Instance.SpinFinishText();
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                            case Finish.Burst://�o�[�X�g�Ȃ�
                                _secondPlayerPoint += _burstFinishPoints;
                                _secondPlayerBurstCount++;
                                UIManager.Instance.BurstFinishText();
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                        }
                        break;
                }
            }
            _isJudg = false;//�Q��ڂ͏��s�𔻒肵�Ȃ��悤�ɂ���
            HalfTime();
        }
    }

    /// <summary>�����r���̋x�e����</summary>
    public async void HalfTime()
    {
        await Task.Delay(50);//������Ƒ҂�
        if(_firstPlayerPoint >= _winPoints)
        {
            UIManager.Instance.GameSet("Player1");

        }
        else if(_secondPlayerPoint >= _winPoints)
        {
            UIManager.Instance.GameSet("Player2");
        }
        else
        {
            _roundCount++;//���E���h���𑝂₷
        }
    }

    /// <summary>�Q�[���I��</summary>
    void EndGame()
    {

    }
}

public enum Finish
{ 
    Over,
    Spin,
    Burst,
    Draw
}


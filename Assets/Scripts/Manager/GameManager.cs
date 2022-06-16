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
    public GameObject FirstPlayer => _firstPlayer;

    public GameObject SecondPlayer => _secondPlayer;

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
    float _money;

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

    /// <summary>Player1�̃Q�[���I�u�W�F�N�g</summary>
    GameObject _firstPlayer;
    /// <summary>Player2�̃Q�[���I�u�W�F�N�g</summary>
    GameObject _secondPlayer;
    /// <summary>Player1�������Ă��鏟���|�C���g</summary>
    static int _firstPlayerPoint;
    /// <summary>Player2�������Ă��鏟���|�C���g</summary>
    static int _secondPlayerPoint;
    /// <summary>Player1�̃I�[�o�[��</summary>
    static int _firstPlayerOverCount;
    /// <summary>Player1�̃X�s����</summary>
    static int _firstPlayerSpinCount;
    /// <summary>Player1�̃o�[�X�g��</summary>
    static int _firstPlayerBurstCount;
    /// <summary>Player2�̃I�[�o�[��</summary>
    static int _secondPlayerOverCount;
    /// <summary>Player2�̃X�s����</summary>
    static int _secondPlayerSpinCount;
    /// <summary>Player2�̃o�[�X�g��</summary>
    static int _secondPlayerBurstCount;
    /// <summary>�����</summary>
    int _judgCount;
    /// <summary>���E���h��</summary>
    static int _roundCount = 1;
    /// <summary>��񂾂���������悤�ɐ؂�ւ�</summary>
    bool _isJudg;
    /// <summary>Player1��Tag</summary>
    const string FIRST_PLAYER_TAG = "Player";
    /// <summary>Player2��Tag</summary>
    const string SECOND_PLAYER_TAG = "SecondPlayer";
    /// <summary>���������ɂȂ锻���</summary>
    const int DRAW_COUNT = 2;
    /// <summary>��u�҂�</summary>
    const int JUDG_TIME = 100;

    protected override void Awake()
    {
        base.Awake();
        _firstPlayer = GameObject.FindWithTag(FIRST_PLAYER_TAG);
        _secondPlayer = GameObject.FindWithTag(SECOND_PLAYER_TAG);
        _isJudg = true;
        UIManager.Instance.RoundText(_roundCount);
        UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
        UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
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
                    UIManager.Instance.FinishText(FinishUI.Draw);//��������
                }
                else
                {
                    switch (finish)
                    {
                        case Finish.Over://�I�[�o�[�Ȃ�
                            _firstPlayerPoint += _overFinishPoints;
                            _firstPlayerOverCount++;
                            UIManager.Instance.FinishText(FinishUI.Over);
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                        case Finish.Spin://�X�s���Ȃ�
                            _firstPlayerPoint += _spinFinishPoints;
                            _firstPlayerSpinCount++;
                            UIManager.Instance.FinishText(FinishUI.Spin);
                            UIManager.Instance.FirstPlayerText(_firstPlayerPoint);
                            break;
                        case Finish.Burst://�o�[�X�g�Ȃ�
                            _firstPlayerPoint += _burstFinishPoints;
                            _firstPlayerBurstCount++;
                            UIManager.Instance.FinishText(FinishUI.Burst);
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
                        UIManager.Instance.FinishText(FinishUI.Draw);//��������
                        break;
                    default://�����|�C���g��n���ăe�L�X�g�ŕ\��
                        switch (finish)
                        {
                            case Finish.Over://�I�[�o�[�Ȃ�
                                _secondPlayerPoint += _overFinishPoints;
                                _secondPlayerOverCount++;
                                UIManager.Instance.FinishText(FinishUI.Over);
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                            case Finish.Spin://�X�s���Ȃ�
                                _secondPlayerPoint += _spinFinishPoints;
                                _secondPlayerSpinCount++;
                                UIManager.Instance.FinishText(FinishUI.Spin);
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                            case Finish.Burst://�o�[�X�g�Ȃ�
                                _secondPlayerPoint += _burstFinishPoints;
                                _secondPlayerBurstCount++;
                                UIManager.Instance.FinishText(FinishUI.Burst);
                                UIManager.Instance.SecondPlayerText(_secondPlayerPoint);
                                break;
                        }
                        break;
                }
            }
            if(_isJudg)HalfTime();
            _isJudg = false;//�Q��ڂ͏��s�𔻒肵�Ȃ��悤�ɂ���           
        }
    }

    /// <summary>�����r���̋x�e����</summary>
    public async void HalfTime()
    {
        await Task.Delay(5000);//������Ƒ҂�
        if(_firstPlayerPoint >= _winPoints)
        {
            UIManager.Instance.GameSet("Player1");
            MoneyManager.Instance.ChangeMoney(Money.FirstPlayer, (int)_winMoney + (int)_money);
            MoneyManager.Instance.ChangeMoney(Money.SecondPlayer, (int)_money);
        }
        else if(_secondPlayerPoint >= _winPoints)
        {
            UIManager.Instance.GameSet("Player2");
            MoneyManager.Instance.ChangeMoney(Money.FirstPlayer, (int)_money);
            MoneyManager.Instance.ChangeMoney(Money.SecondPlayer, (int)_winMoney + (int)_money);
        }
        else
        {
            _roundCount++;//���E���h���𑝂₷
            UIManager.Instance.RoundText(_roundCount);
            EndGame();
        }
    }

    /// <summary>�Q�[���I��</summary>
    void EndGame()
    {
        SceneLoader.Instance.LoadScene("BattleScene");
    }
}

public enum Finish
{ 
    Over,
    Spin,
    Burst,
    Draw
}


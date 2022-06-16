using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI�}�l�[�W���[
/// UI�̕\���͑S�Ă����ōs��
/// </summary>
public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public List<Slider> ShootPowerSlider => _shootPowerSlider;

    /// <summary>�t�B�j�b�V���e�L�X�g�̕\���b��</summary>
    [SerializeField]
    [Header("�t�B�j�b�V���e�L�X�g�̕\���b��(�~���b)")]
    int _seconds = 300;

    [SerializeField]
    [Header("�V���[�g�O�̃J�E���g�̕\���b��(�~���b)")]
    int _countSeconds = 1000;

    /// <summary>Player1�̏����|�C���g�̃e�L�X�g</summary>
    [SerializeField]
    [Header("Player1�̏����|�C���g�̃e�L�X�g")]
    Text _firstPlayerPointText;

    /// <summary>Player2�̏����|�C���g�̃e�L�X�g</summary>
    [SerializeField]
    [Header("Player2�̏����|�C���g�̃e�L�X�g")]
    Text _secondPlayerPointText;

    [SerializeField]
    [Header("Player1�̏������̃e�L�X�g")]
    Text _firstPlayerMoneyText;

    [SerializeField]
    [Header("Player2�̏������̃e�L�X�g")]
    Text _secondPlayerMoneyText;

    /// <summary>���݂̃��E���h���̃e�L�X�g</summary>
    [SerializeField]
    [Header("���E���h���̃e�L�X�g")]
    Text _roundText;

    /// <summary>�V���[�g����ꏊ�����߂�Ƃ��ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�V���[�g����ꏊ�����߂�Ƃ��ɕ\������e�L�X�g")]
    Text _shootPosText;

    [SerializeField]
    [Header("�p���[�����߂鎞�ɕ\������e�L�X�g")]
    Text _shootPowerText;

    /// <summary>�V���[�g���ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�V���[�g���ɕ\������e�L�X�g(Ready)")]
    Text _readyText;

    /// <summary>�V���[�g���ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�V���[�g���ɕ\������e�L�X�g(3)")]
    Text _threeText;

    /// <summary>�V���[�g���ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�V���[�g���ɕ\������e�L�X�g(2)")]
    Text _twoText;

    /// <summary>�V���[�g���ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�V���[�g���ɕ\������e�L�X�g(1)")]
    Text _oneText;

    /// <summary>�V���[�g���ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�V���[�g���ɕ\������e�L�X�g(GO)")]
    Text _goText;

    /// <summary>�������O�ɒǂ��o�������ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�������O�ɒǂ��o�������ɕ\������e�L�X�g")]
    Text _overFinishText;

    /// <summary>�����蒷������ď����������ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("�����蒷������ď����������ɕ\������e�L�X�g")]
    Text _spinFinishText;

    /// <summary>�����j�󂵂����ɕ\������e�L�X�g(��������)</summary>
    [SerializeField]
    [Header("�����j�󂵂����ɕ\������e�L�X�g)")]
    Text _burstFinishText;

    /// <summary>���������ɂȂ������ɕ\������e�L�X�g</summary>
    [SerializeField]
    [Header("���������ɂȂ������ɕ\������e�L�X�g")]
    Text _drawFinishText;

    [SerializeField]
    [Header("���s�����܂������ɕ\������e�L�X�g")]
    Text _gameSetText;

    /// <summary>�V���[�g�p���[�����߂�X���C�_�[</summary>
    [SerializeField]
    [Header("�V���[�g�p���[�����߂�X���C�_�[")]
    List<Slider> _shootPowerSlider = new List<Slider>();

    /// <summary>���ʉ�ʂ̃p�l��</summary>
    [SerializeField]
    [Header("���ʉ�ʂ̃p�l��")]
    Image _resultPanel;

    /// <summary>���ʉ�ʂ̃p�l��</summary>
    [SerializeField]
    [Header("�V�[���ړ��p��ʂ̃p�l��")]
    Image _scenePanel;

    void Start()
    {
        if (_readyText) _readyText.gameObject.SetActive(false);
        if (_threeText) _threeText.gameObject.SetActive(false);
        if (_twoText) _twoText.gameObject.SetActive(false);
        if (_oneText) _oneText.gameObject.SetActive(false);
        if (_goText) _goText.gameObject.SetActive(false);
    }

    /// <summary>Player1�������Ă��鏟���|�C���g</summary>
    public void FirstPlayerText(int firstPlayerPoint) => _firstPlayerPointText.text = "Player1 " + firstPlayerPoint.ToString() + "P";

    /// <summary>Player2�������Ă��鏟���|�C���g</summary>
    public void SecondPlayerText(int secondPlayerPoint) => _secondPlayerPointText.text = "Player2 " + secondPlayerPoint.ToString() + "P";

    public void FirstPlayerMoney(int FirstPlayerMoney) => _firstPlayerMoneyText.text = "Player1 " + FirstPlayerMoney;

    public void SecondPlayerMoney(int SecondPlayerMoney) => _secondPlayerMoneyText.text = "Player2 " + SecondPlayerMoney;

    /// <summary>���E���h��</summary>
    public void RoundText(int roundCount) => _roundText.text = "Round" + roundCount.ToString();

    /// <summary>�\�����邩�ǂ�����ς���</summary>
    public void DisplayShootPowerSlider(bool setActive) => _shootPowerSlider.ForEach(x => { x.gameObject.SetActive(setActive); });

    /// <summary>�X���C�_�[�̒l��ς���</summary>
    public void ShootPower(float changePower,int number) => _shootPowerSlider[number].value += changePower;

    /// <summary>�V���[�g���ɕ\������e�L�X�g</summary>
    public async void ShootCountText()
    {
        _readyText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _readyText.gameObject.SetActive(false);
        _threeText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _threeText.gameObject.SetActive(false);
        _twoText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _twoText.gameObject.SetActive(false);
        _oneText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _oneText.gameObject.SetActive(false);
        _goText.gameObject.SetActive(true);
        await Task.Delay(_countSeconds);
        _goText.gameObject.SetActive(false);
    }

    /// <summary>�ǂ��炩���|�C���g����ɓ��ꂽ�Ƃ��ɐ��b�ԕ\������e�L�X�g</summary>
    /// <param name="finish">������</param>
    public async void FinishText(FinishUI finish)
    {
        switch (finish)
        {
            case FinishUI.Over:
                _overFinishText.gameObject.SetActive(true);              
                await Task.Delay(_seconds);
                _overFinishText.gameObject.SetActive(false);
                break;

            case FinishUI.Spin:
                _spinFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _spinFinishText.gameObject.SetActive(false);
                break;

            case FinishUI.Burst:
                _burstFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _burstFinishText.gameObject.SetActive(false);
                break;

            case FinishUI.Draw:
                _drawFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _drawFinishText.gameObject.SetActive(false);
                break;
        }
    }

    /// <summary>�����������Ƃ��ɕ\������</summary>
    /// <param name="playerName">�v���C���[�̖��O</param>
    public void GameSet(string playerName)
    {
        _gameSetText.text = playerName + " Win";
        _gameSetText.gameObject.SetActive(true);
    }
}
public enum FinishUI
{
    Over,
    Spin,
    Burst,
    Draw
}

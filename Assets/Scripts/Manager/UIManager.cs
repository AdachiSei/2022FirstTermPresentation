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
    public Slider ShootPowerSlider => _shootPowerSlider;

    /// <summary>�t�B�j�b�V���e�L�X�g�̕\���b��</summary>
    [SerializeField]
    [Header("�t�B�j�b�V���e�L�X�g�̕\���b��(�~���b)")]
    int _seconds = 50;

    /// <summary>Player1�̏����|�C���g�̃e�L�X�g</summary>
    [SerializeField]
    [Header("Player1�̏����|�C���g�̃e�L�X�g")]
    Text _firstPlayerPointText;

    /// <summary>Player2�̏����|�C���g�̃e�L�X�g</summary>
    [SerializeField]
    [Header("Player2�̏����|�C���g�̃e�L�X�g")]
    Text _secondPlayerPointText;

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
    [Header("�V���[�g���ɕ\������e�L�X�g")]
    Text _shootText;

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
    Slider _shootPowerSlider;

    /// <summary>���ʉ�ʂ̃p�l��</summary>
    [SerializeField]
    [Header("���ʉ�ʂ̃p�l��")]
    Image _resultPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>Player1�������Ă��鏟���|�C���g</summary>
    /// <param name="FirstPlayerPoint">���݂̏����|�C���g</param>
    public void FirstPlayerText(int FirstPlayerPoint) => _firstPlayerPointText.text = "Player1 " + FirstPlayerPoint.ToString() + "P";

    /// <summary>Player2�������Ă��鏟���|�C���g</summary>
    /// <param name="SecondPlayerPoint">���݂̏����|�C���g</param>
    public void SecondPlayerText(int SecondPlayerPoint) => _secondPlayerPointText.text = "Player2 " + SecondPlayerPoint.ToString() + "P";

    public void ShootPower(float changePower) => ShootPowerSlider.value += changePower;

    /// <summary>�V���[�g���ɕ\������e�L�X�g</summary>
    /// <param name="text"></param>
    public void ReadySetText(string text) => _shootText.text = text;

    
    /// <summary>�ǂ��炩���|�C���g����ɓ��ꂽ�Ƃ��ɐ��b�ԕ\������e�L�X�g</summary>
    /// <param name="finish">������</param>
    public async void FinishText(UIFinish finish)
    {
        switch (finish)
        {
            case UIFinish.Over:
                _overFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _overFinishText.gameObject.SetActive(false);
                break;

            case UIFinish.Spin:
                _spinFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _spinFinishText.gameObject.SetActive(false);
                break;

            case UIFinish.Burst:
                _burstFinishText.gameObject.SetActive(true);
                await Task.Delay(_seconds);
                _burstFinishText.gameObject.SetActive(false);
                break;

            case UIFinish.Draw:
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
public enum UIFinish
{
    Over,
    Spin,
    Burst,
    Draw
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI�}�l�[�W���[
/// UI�̕\���͑S�Ă����ōs��
/// </summary>
public class UIManager : SingletonMonoBehaviour<UIManager>
{
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
    /// <summary>�I�[�o�[�t�B�j�b�V�������܂����Ƃ��ɕ\��</summary>
    public void OverFinishText() => _overFinishText.gameObject.SetActive(true);     
    /// <summary>�X�s���t�B�j�b�V�������܂����Ƃ��ɕ\��</summary>
    public void SpinFinishText() => _spinFinishText.gameObject.SetActive(true);
    /// <summary>�o�[�X�g�t�B�j�b�V�������܂������ɕ\���i����j</summary>
    public void BurstFinishText() => _burstFinishText.gameObject.SetActive(true);
    /// <summary>�h���[�ɂȂ������ɕ\���i����j</summary>
    public void DrawFinishText() => _drawFinishText.gameObject.SetActive(true);

    /// <summary>�����������Ƃ��ɕ\������</summary>
    /// <param name="playerName">�v���C���[�̖��O</param>
    public void GameSet(string playerName)
    {
        _gameSetText.text = playerName + " Win";
        _gameSetText.gameObject.SetActive(true);
    }
}
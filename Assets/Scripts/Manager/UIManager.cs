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
    /// <summary>Player1�̏����|�C���g�e�L�X�g</summary>
    [SerializeField]
    [Header("Player1�̏����|�C���g")]
    Text _firstPlayerPointText;

    /// <summary>Player2�̏����|�C���g�̃e�L�X�g</summary>
    [SerializeField]
    [Header("Player2�̏����|�C���g")]
    Text _secondPlayerPointText;

    /// <summary>���݂̃��E���h���̃e�L�X�g</summary>
    [SerializeField]
    [Header("���E���h����Text")]
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

    /// <summary>���ʉ�ʂ̃p�l��</summary>
    [SerializeField]
    [Header("���ʉ�ʂ̃p�l��")]
    Text _resultPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>�I�[�o�[�t�B�j�b�V�������܂����Ƃ��ɕ\��</summary>
    public void OverFinishText() => _overFinishText.gameObject.SetActive(true);     
    /// <summary>�X�s���t�B�j�b�V�������܂����Ƃ��ɕ\��</summary>
    public void SpinFinishText() => _spinFinishText.gameObject.SetActive(true);
    /// <summary>�o�[�X�g�t�B�j�b�V�������܂������ɕ\���i����j</summary>
    public void BurstFinishText() => _burstFinishText.gameObject.SetActive(true);
}

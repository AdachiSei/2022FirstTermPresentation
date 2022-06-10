using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �x�C�u���[�h���V���[�g���邽�߂̃X�N���v�g
/// </summary>
public class ShootController : MonoBehaviour
{
    /// <summary>�V���[�g�p���[�����߂�X���C�_�[</summary>
    [SerializeField]
    [Header("�V���[�g�p���[�����߂�X���C�_�[")]
    Slider _shootPowerSlider;

    [SerializeField]
    [Header("�X���C�_�[�̒l��ω�������傫��")]
    [Range(0f,1f)]
    float _changePower = 0.05f;


    Rigidbody _rb;  
    string _inputButton;
    /// <summary>�x�C�u���[�h���V���[�g���邽�߂̉ߒ�</summary>
    ShootProcess _shootProsess = ShootProcess.Pos;

    


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //Y���Ɖ�]�l���t���[�Y������
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //�J������ύX
        CameraManager.Instance.ChangeCamera(CameraType.High);

        if(gameObject.tag == "Player")//�v���C���[1��������
        {
            _inputButton = "Fire1";
        }
        else//�v���C���[2��������
        {
            _inputButton = "Fire2";
        }
    }

    void Update()
    {
        //�}�E�X�|�C���^�[���\��
        Cursor.visible = false;

        Shoot();
    }

    void Shoot()
    { 
        switch (_shootProsess)
        {
            case ShootProcess.Pos://�ʒu�����߂�
                //�}�E�X�ɘA�����ē�����
                var target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                target.y = transform.position.y;
                transform.position = target;
                break;

            case ShootProcess.Power://��]�l�����߂��ʂ�������
                _shootPowerSlider.value += _changePower;//�X���C�_�[�̒l�𓮂���
                //�l���ő傩�ŏ��ɂȂ�����
                if (_shootPowerSlider.value == 0 || _shootPowerSlider.value == 1)
                {
                    _changePower = -_changePower;//�t�����ɓ�����
                }
                break;

            case ShootProcess.Shoot:
                ReadySet();
                break;
        }

        if (Input.GetButtonDown(_inputButton))
        {
            switch (_shootProsess)//���̃V���[�g���邽�߂̉ߒ�
            {
                case ShootProcess.Pos://�x�C�u���[�h�̈ʒu��ݒ肵��
                    CameraManager.Instance.ChangeCamera(CameraType.Side);//�J������ύX
                    _shootPowerSlider.gameObject.SetActive(true);//�X���C�_�[��\��
                    _shootProsess = ShootProcess.Power;
                    break;

                case ShootProcess.Power://�V���[�g�p���[�����߂�
                    CameraManager.Instance.ChangeCamera(CameraType.High);//�J������ύX
                    _shootPowerSlider.gameObject.SetActive(false);
                    _shootProsess = ShootProcess.Shoot;
                    break;
            }
        }
    }

    async void ReadySet()
    {

        await Task.Delay(50);

        await Task.Delay(10);

        await Task.Delay(10);

        await Task.Delay(10);
    }
}
public enum ShootProcess
{
    Pos,
    Power,
    Shoot
}
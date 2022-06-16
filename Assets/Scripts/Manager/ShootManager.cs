using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShootManager : SingletonMonoBehaviour<ShootManager>
{
    public float Height => _height;

    [SerializeField]
    [Header("�x�C�̍���")]
    float _height = 7f;

    [SerializeField]
    [Header("�X���C�_�[�̒l��ω�������傫��")]
    [Range(0f, 1f)]
    float _changePower = 0.05f;

    Rigidbody _firstPlayerRb;
    Rigidbody _secondPlayerRb;
    Collider _firstPlayerCollider;
    Collider _secondPlayerCollider;
    string _inputButton;
    /// <summary>�x�C�u���[�h���V���[�g���邽�߂̉ߒ�</summary>
    ShootProcess _shootProsess = ShootProcess.firstPos;

    bool _isFirstShootPower;
    bool _isSecondShootPower;
    bool _isShoot;

    void Start()
    {
        _firstPlayerRb = GameManager.Instance.FirstPlayer.GetComponent<Rigidbody>();
        _secondPlayerRb = GameManager.Instance.SecondPlayer.GetComponent<Rigidbody>();
        _firstPlayerCollider = GameManager.Instance.FirstPlayer.GetComponent<Collider>();
        _secondPlayerCollider = GameManager.Instance.SecondPlayer.GetComponent<Collider>();
        _isFirstShootPower = true;
        _isSecondShootPower = true;
        _isShoot = true;
        //Y���Ɖ�]�l���t���[�Y������
        _firstPlayerRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        _secondPlayerRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        //�J������ύX
        CameraManager.Instance.ChangeCamera(CameraType.High);
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
            case ShootProcess.firstPos://�ŏ��̃v���C���[�̈ʒu�����߂�
                //�}�E�X�ɘA�����ē�����
                var fisrtTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                fisrtTarget.y = _height;
                GameManager.Instance.FirstPlayer.transform.position = fisrtTarget;
                break;

            case ShootProcess.secondPos://���̃v���C���[�̈ʒu�����߂�
                var secondTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                secondTarget.y = _height;
                GameManager.Instance.SecondPlayer.transform.position = secondTarget;
                break;

            case ShootProcess.Power://��]�l�����߂��ʂ�������
                //�X���C�_�[�̒l�𓮂���
                if (_isFirstShootPower) UIManager.Instance.ShootPower(_changePower, 0);
                if (_isSecondShootPower) UIManager.Instance.ShootPower(_changePower, 1);

                //�l���ő傩�ŏ��ɂȂ�����
                bool firstSlider;
                bool secondSlider;

                if (_isFirstShootPower)
                {
                    firstSlider = UIManager.Instance.ShootPowerSlider[0].value == 0 || UIManager.Instance.ShootPowerSlider[0].value == 1;
                }
                else firstSlider = false;

                if (_isSecondShootPower)
                {
                    secondSlider = UIManager.Instance.ShootPowerSlider[1].value == 0 || UIManager.Instance.ShootPowerSlider[1].value == 1;
                }
                else secondSlider = false;

                if (firstSlider || secondSlider)
                {
                    _changePower = -_changePower;//�t�����ɓ�����
                }
                break;

            case ShootProcess.Shoot:
                if (_isShoot) ReadySet();
                break;
        }

        if (Input.GetButtonDown("Fire1"))//�v���C���[1
        {
            switch (_shootProsess)//���̃V���[�g���邽�߂̉ߒ�
            {
                case ShootProcess.firstPos://�x�C�u���[�h�̈ʒu��ݒ肵��
                    _shootProsess = ShootProcess.secondPos;
                    break;

                case ShootProcess.Power://�V���[�g�p���[�����߂�
                    _isFirstShootPower = false;

                    if (!_isFirstShootPower && !_isSecondShootPower)
                    {
                        CameraManager.Instance.ChangeCamera(CameraType.High);//�J������ύX
                        UIManager.Instance.DisplayShootPowerSlider(false);//�X���C�_�[���\��
                        _shootProsess = ShootProcess.Shoot;
                    }
                    
                    break;
            }
        }

        else if (Input.GetButtonDown("Fire2"))//�v���C���[2
        {
            switch (_shootProsess)
            {
                case ShootProcess.secondPos://�x�C�u���[�h�̈ʒu��ݒ肵��
                    CameraManager.Instance.ChangeCamera(CameraType.Side);//�J������ύX
                    UIManager.Instance.DisplayShootPowerSlider(true);//�X���C�_�[��\��
                    _shootProsess = ShootProcess.Power;
                    break;

                case ShootProcess.Power://�V���[�g�p���[�����߂�
                    _isSecondShootPower = false;

                    if(!_isFirstShootPower && !_isSecondShootPower)
                    {
                        CameraManager.Instance.ChangeCamera(CameraType.High);//�J������ύX
                        UIManager.Instance.DisplayShootPowerSlider(false);//�X���C�_�[���\��
                        _shootProsess = ShootProcess.Shoot;
                    }
                    
                    break;
            }
        }
    }

    async void ReadySet()
    {
        _isShoot = false;
        UIManager.Instance.ShootCountText();
        await Task.Delay(4000);

        if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
        {
            CameraManager.Instance.ChangeCamera(CameraType.Main);
            GameManager.Instance.FirstPlayer.GetComponent<BeyBladeBase>().enabled = true;
            GameManager.Instance.SecondPlayer.GetComponent<BeyBladeBase>().enabled = true;
            _firstPlayerRb.constraints = RigidbodyConstraints.FreezePositionY & RigidbodyConstraints.FreezeRotation;
            _secondPlayerRb.constraints = RigidbodyConstraints.FreezePositionY & RigidbodyConstraints.FreezeRotation;
            _firstPlayerCollider.isTrigger = false;
            _secondPlayerCollider.isTrigger = false;
        }
        else
        {
            await Task.Delay(1000);
            ReadySet();
        }
    }
}
public enum ShootProcess
{
    firstPos,
    secondPos,
    Power,
    Shoot
}

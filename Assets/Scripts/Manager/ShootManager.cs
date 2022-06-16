using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShootManager : SingletonMonoBehaviour<ShootManager>
{
    public float Height => _height;

    [SerializeField]
    [Header("ベイの高さ")]
    float _height = 7f;

    [SerializeField]
    [Header("スライダーの値を変化させる大きさ")]
    [Range(0f, 1f)]
    float _changePower = 0.05f;

    Rigidbody _firstPlayerRb;
    Rigidbody _secondPlayerRb;
    Collider _firstPlayerCollider;
    Collider _secondPlayerCollider;
    string _inputButton;
    /// <summary>ベイブレードをシュートするための過程</summary>
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
        //Y軸と回転値をフリーズさせる
        _firstPlayerRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        _secondPlayerRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        //カメラを変更
        CameraManager.Instance.ChangeCamera(CameraType.High);
    }

    void Update()
    {
        //マウスポインターを非表示
        Cursor.visible = false;
        Shoot();
    }

    void Shoot()
    {
        switch (_shootProsess)
        {
            case ShootProcess.firstPos://最初のプレイヤーの位置を決める
                //マウスに連動して動かす
                var fisrtTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                fisrtTarget.y = _height;
                GameManager.Instance.FirstPlayer.transform.position = fisrtTarget;
                break;

            case ShootProcess.secondPos://次のプレイヤーの位置を決める
                var secondTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                secondTarget.y = _height;
                GameManager.Instance.SecondPlayer.transform.position = secondTarget;
                break;

            case ShootProcess.Power://回転値を決める場面だったら
                //スライダーの値を動かす
                if (_isFirstShootPower) UIManager.Instance.ShootPower(_changePower, 0);
                if (_isSecondShootPower) UIManager.Instance.ShootPower(_changePower, 1);

                //値が最大か最小になったら
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
                    _changePower = -_changePower;//逆方向に動かす
                }
                break;

            case ShootProcess.Shoot:
                if (_isShoot) ReadySet();
                break;
        }

        if (Input.GetButtonDown("Fire1"))//プレイヤー1
        {
            switch (_shootProsess)//今のシュートするための過程
            {
                case ShootProcess.firstPos://ベイブレードの位置を設定した
                    _shootProsess = ShootProcess.secondPos;
                    break;

                case ShootProcess.Power://シュートパワーを決めた
                    _isFirstShootPower = false;

                    if (!_isFirstShootPower && !_isSecondShootPower)
                    {
                        CameraManager.Instance.ChangeCamera(CameraType.High);//カメラを変更
                        UIManager.Instance.DisplayShootPowerSlider(false);//スライダーを非表示
                        _shootProsess = ShootProcess.Shoot;
                    }
                    
                    break;
            }
        }

        else if (Input.GetButtonDown("Fire2"))//プレイヤー2
        {
            switch (_shootProsess)
            {
                case ShootProcess.secondPos://ベイブレードの位置を設定した
                    CameraManager.Instance.ChangeCamera(CameraType.Side);//カメラを変更
                    UIManager.Instance.DisplayShootPowerSlider(true);//スライダーを表示
                    _shootProsess = ShootProcess.Power;
                    break;

                case ShootProcess.Power://シュートパワーを決めた
                    _isSecondShootPower = false;

                    if(!_isFirstShootPower && !_isSecondShootPower)
                    {
                        CameraManager.Instance.ChangeCamera(CameraType.High);//カメラを変更
                        UIManager.Instance.DisplayShootPowerSlider(false);//スライダーを非表示
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

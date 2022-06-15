using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShootManager : SingletonMonoBehaviour<ShootManager>
{
    [SerializeField]
    [Header("スライダーの値を変化させる大きさ")]
    [Range(0f, 1f)]
    float _changePower = 0.05f;

    Rigidbody _firstPlayerRb;
    Rigidbody _secondPlayerRb;
    string _inputButton;
    /// <summary>ベイブレードをシュートするための過程</summary>
    ShootProcess _shootProsess = ShootProcess.Pos;

    bool _isShoot;


    void Start()
    {
        _firstPlayerRb = GameManager.Instance.FirstPlayer.GetComponent<Rigidbody>();
        _secondPlayerRb = GameManager.Instance.SecondPlayer.GetComponent<Rigidbody>();


        _isShoot = true;
        //Y軸と回転値をフリーズさせる
        _firstPlayerRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        _secondPlayerRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        //カメラを変更
        CameraManager.Instance.ChangeCamera(CameraType.High);

        if (_firstPlayerRb.gameObject.tag == "Player")//プレイヤー1だったら
        {
            _inputButton = "Fire1";
        }
        else//プレイヤー2だったら
        {
            _inputButton = "Fire2";
        }
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
            case ShootProcess.Pos://位置を決める
                //マウスに連動して動かす
                var target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                target.y = 7f;
                GameManager.Instance.FirstPlayer.transform.position = target;
                break;

            case ShootProcess.Power://回転値を決める場面だったら
                UIManager.Instance.ShootPower(_changePower);//スライダーの値を動かす
                //値が最大か最小になったら
                if (UIManager.Instance.ShootPowerSlider[0].value == 0 || UIManager.Instance.ShootPowerSlider[0].value == 1)
                {
                    _changePower = -_changePower;//逆方向に動かす
                }
                break;

            case ShootProcess.Shoot:
                if (_isShoot) ReadySet();
                break;
        }

        if (Input.GetButtonDown(_inputButton))
        {
            switch (_shootProsess)//今のシュートするための過程
            {
                case ShootProcess.Pos://ベイブレードの位置を設定した
                    CameraManager.Instance.ChangeCamera(CameraType.Side);//カメラを変更
                    UIManager.Instance.DisplayShootPowerSlider(true);//スライダーを表示
                    _shootProsess = ShootProcess.Power;
                    break;

                case ShootProcess.Power://シュートパワーを決めた
                    //CameraManager.Instance.ChangeCamera(CameraType.High);//カメラを変更
                    UIManager.Instance.DisplayShootPowerSlider(false);//スライダーを非表示
                    _shootProsess = ShootProcess.Shoot;
                    break;
            }
        }
    }

    async void ReadySet()
    {
        _isShoot = false;
        Debug.Log("R");
        await Task.Delay(2000);
        Debug.Log(3);
        await Task.Delay(1000);
        Debug.Log(2);
        await Task.Delay(1000);
        Debug.Log(1);
        await Task.Delay(1000);
        Debug.Log(0);
        if(Input.GetAxis("Mouse X") > 0f|| Input.GetAxis("Mouse Y") > 0f)
        {
            CameraManager.Instance.ChangeCamera(CameraType.Main);
            GameManager.Instance.FirstPlayer.GetComponent<BeyBladeBase>().enabled = true;
            GameManager.Instance.SecondPlayer.GetComponent<BeyBladeBase>().enabled = true;
            _firstPlayerRb.constraints = RigidbodyConstraints.FreezePositionY & RigidbodyConstraints.FreezeRotation;
            _secondPlayerRb.constraints = RigidbodyConstraints.FreezePositionY & RigidbodyConstraints.FreezeRotation;
        }
        else
        {

        }
    }
}
public enum ShootProcess
{
    Pos,
    Power,
    Shoot
}

using UnityEngine;

public class BeyBladeMove : MonoBehaviour
{
    Rigidbody _rb;

    float _timer;

    bool _switch;
    
    /// <summary>��]�X�s�[�h</summary>
    [SerializeField]
    [Header("��]�X�s�[�h")]
    float _rotSpeed = 10;

    /// <summary>Player��Tag</summary>
    [SerializeField]
    [Header("Player��Tag")]
    string _playerTag = "Player";

    /// <summary>Wall��Tag</summary>
    [SerializeField]
    [Header("Wall��Tag")]
    string _wallTag = "Wall";

    RigidbodyConstraints freezeRotX = RigidbodyConstraints.FreezeRotationX;
    RigidbodyConstraints freezeRotZ = RigidbodyConstraints.FreezeRotationZ;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        //��]�l��X��Y���Œ�
        _rb.constraints = freezeRotX | freezeRotZ;
    }

    void Start()
    {
        //_rb.velocity = gameObject.transform.rotation * new Vector3(0, -50, 0);      
    }

    void FixedUpdate()
    {
        _timer += Time.deltaTime;
        _rb.angularVelocity = new Vector3(_rb.angularVelocity.x, _rotSpeed, _rb.angularVelocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == _playerTag)
        {
            _rb.constraints = freezeRotX & freezeRotZ;
            _timer = 0;
            _switch = true;
        }      
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == _wallTag && _switch)
        {
            transform.rotation = Quaternion.Euler(-180f, transform.rotation.y, 0f);
            _rb.constraints = freezeRotX | freezeRotZ;
            _switch = false;
        }
    }
}

#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Train Stats")]
    [SerializeField] private float _health;

    [Header("Train Movement")]
    [SerializeField] private TrainPath _path;

    [SerializeField] private float _speed;
    [SerializeField] private float _followDistance;

    private float _curPosition = 0.0f;

    [SerializeField] private Train _head;
    [SerializeField] private Train _tail;

    [Header("Train Geometery")]
    [SerializeField] private float _length;
    private Vector2 _front = Vector2.zero;
    private Vector2 _back = Vector2.zero;

    public Vector2 Forward { get { return _front - _back; } }

    private enum TrainType
    { 
        Engine,
        Follow1,
        Follow2,
        Count
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
#if DEBUG
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            _curPosition = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.P) && _tail == null)
        {
            AddFollowTrain(TrainType.Engine);
        }
#endif

        if (_head == null)
        {
            _curPosition += _speed * Time.deltaTime;
            Vector2 centerPos = _path.GetPathPosition(_curPosition);
            // Vector2 lookDir = _path.GetPathDirection(_curPosition).normalized;
            _front = _path.GetPathPosition(_curPosition + _length);
            _back = _path.GetPathPosition(_curPosition - _length);
        }
        else
        {
            float front = _head._curPosition - _head._length - _followDistance;
            float back = _head._curPosition - _head._length * 3 - _followDistance;
            _curPosition = Mathf.Lerp(front, back, 0.5f);
            _front = _path.GetPathPosition(front);
            _back = _path.GetPathPosition(back);
        }

        gameObject.transform.position = Vector2.Lerp(_front, _back, 0.5f);
        float lookAngle = Mathf.Atan2(_front.y - _back.y, _front.x - _back.x);
        gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * lookAngle, Vector3.forward);
    }

    private void AddFollowTrain(TrainType type)
    {
        if (_tail != null)
        {
            return;
        }

        string trainType = type.ToString();

        GameObject trainGo = Instantiate(Resources.Load<GameObject>($"Train/{trainType}"), gameObject.transform.parent);
        Train train = trainGo.GetComponent<Train>();
        train._head = this;
        train._path = _path;
        train._speed = _speed;
        train._followDistance = _followDistance;
        _tail = trainGo.GetComponent<Train>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_back, 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_front, 0.2f);
    }
}

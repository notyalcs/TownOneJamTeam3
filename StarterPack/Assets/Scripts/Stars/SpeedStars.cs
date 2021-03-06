using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStars : MonoBehaviour
{
    private Train _train;

    [Header("Twiddles")]
    [SerializeField, Range(0, 2)] private float _xSmearModifier = 1.0f;
    [SerializeField, Range(0, 2)] private float _ySmearModifier = 1.0f;
    [SerializeField] private float _finalScaleModifier = 0.2f;
    [SerializeField, Range(0, 1)] private float _maxRandomSize = 1.0f;
    [SerializeField] private Color _color;

    private float _timeAlive = 0.0f;

    [Header("Components")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _randomSize = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.color = Color.clear;
        _randomSize = Random.Range(0, _maxRandomSize);
    }

    // Update is called once per frame
    void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive < 1.0f)
        {
            _spriteRenderer.color = Color.Lerp(Color.clear, _color, _timeAlive);
        }
        else
        {
            Color c = _spriteRenderer.color;
            c.a = Mathf.PingPong(_timeAlive, 1);
            _spriteRenderer.color = c;
        }

        float smear = Mathf.Sqrt(_train.Forward.x * _train.Forward.x + _train.Forward.y * _train.Forward.y);
        Vector3 curScale = Vector3.one;
        if (smear > 1)
        {
            curScale.x = smear * _xSmearModifier;
            curScale.y = (1 / smear) * _ySmearModifier;
        }

        gameObject.transform.localScale = curScale * _finalScaleModifier * _randomSize;
        gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(_train.Forward.y, _train.Forward.x), Vector3.forward);
    }

    public void SetTrain(Train t)
    {
        _train = t;
    }
}

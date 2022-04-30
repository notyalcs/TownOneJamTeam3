using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Comp_PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 10.0f;

    private Comp_PlayerInputs _inputs;

    private void Start()
    {
        _inputs = GetComponent<Comp_PlayerInputs>();
    }

    private void Update()
    {
        if (_inputs.Up.GetKey())
        {
            Debug.Log("Up");
        }
        if (_inputs.Down.GetKey())
        {
            Debug.Log("Down");
        }
        if (_inputs.Right.GetKey())
        {
            Debug.Log("Right");
        }
        if (_inputs.Left.GetKey())
        {
            Debug.Log("Left");
        }
    }
}

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
        if (_inputs._up.GetKey())
        {
            Debug.Log("Up");
        }
        if (_inputs._down.GetKey())
        {
            Debug.Log("Down");
        }
        if (_inputs._right.GetKey())
        {
            Debug.Log("Right");
        }
        if (_inputs._left.GetKey())
        {
            Debug.Log("Left");
        }
    }
}

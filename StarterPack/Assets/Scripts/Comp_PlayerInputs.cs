using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInput
{
    [SerializeField] private KeyCode primary;
    [SerializeField] private KeyCode secondary;

    public bool GetKey()
    {
        return Input.GetKey(primary) || Input.GetKey(secondary);
    }

    public bool GetKeyDown()
    {
        return Input.GetKeyDown(primary) || Input.GetKeyDown(secondary);
    }

    public bool GetKeyUp()
    {
        return Input.GetKeyUp(primary) || Input.GetKeyUp(secondary);
    }
}

public class Comp_PlayerInputs : MonoBehaviour
{
    [SerializeField] public PlayerInput _up;
    [SerializeField] public PlayerInput _down;
    [SerializeField] public PlayerInput _left;
    [SerializeField] public PlayerInput _right;

    public float GetAxisVerticalRaw()
    {
        if (_up.GetKey() && _down.GetKey()) { return 0.0f; }

        if (_up.GetKey()) { return 1.0f; }
        if (_down.GetKey()) { return -1.0f; }

        return 0.0f;
    }

    public float GetAxisHorizontalRaw()
    {
        if (_left.GetKey() && _right.GetKey()) { return 0.0f; }

        if (_right.GetKey()) { return 1.0f; }
        if (_left.GetKey()) { return -1.0f; }

        return 0.0f;
    }
}

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
    [SerializeField] public PlayerInput Up;
    [SerializeField] public PlayerInput Down;
    [SerializeField] public PlayerInput Left;
    [SerializeField] public PlayerInput Right;

    public float GetAxisVerticalRaw()
    {
        if (Up.GetKey() && Down.GetKey()) { return 0.0f; }

        if (Up.GetKey()) { return 1.0f; }
        if (Down.GetKey()) { return -1.0f; }

        return 0.0f;
    }

    public float GetAxisHorizontalRaw()
    {
        if (Left.GetKey() && Right.GetKey()) { return 0.0f; }

        if (Right.GetKey()) { return 1.0f; }
        if (Left.GetKey()) { return -1.0f; }

        return 0.0f;
    }
}

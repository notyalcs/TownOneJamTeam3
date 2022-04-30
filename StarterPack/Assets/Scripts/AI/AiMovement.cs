using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{

    bool needsToMove = false;

    [SerializeField]float moveSpeed = 1;
    [SerializeField]float acceptedRange = 0;
    [SerializeField][Tooltip("Should these fields take " +
    "precedence over those in a Comp_UnitInfo component" +
    "attached to this GameObject?")] bool overrideUnitInfo = false;

    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        if (!overrideUnitInfo)
        {
            Comp_UnitInfo unitOverride = gameObject.GetComponent<Comp_UnitInfo>();
            if (unitOverride != null)
            {
                moveSpeed = unitOverride.Speed;
            }
        }
    }

    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void SetAcceptedRange(float newRange)
    {
        acceptedRange = newRange;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetAcceptedRange()
    {
        return acceptedRange;
    }

    //START moving to position. Execution will continue without waiting for it to be done.
    public void MoveTo(Vector2 targetLoc)
    {
        targetPos = targetLoc;
        needsToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(needsToMove && targetPos != null)
        {
            Vector2 delta = targetPos - (Vector2)gameObject.transform.position;
            if (delta.magnitude > acceptedRange)
            {
                gameObject.transform.position += (Vector3)(delta.normalized * moveSpeed * Time.deltaTime);
            } else
            {
                needsToMove = false;
            }
        }
    }
}

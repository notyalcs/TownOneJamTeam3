using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{

    bool needsToMove = false;

    [SerializeField]float moveSpeed = 1;
    [SerializeField]float acceptedRange = 0;

    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{

    [Header("Subcontrollers")]
    [SerializeField] AiMovement movement;

    [Header("Test Items")]
    [SerializeField] Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        if(movement == null)
        {
            movement = gameObject.GetComponent<AiMovement>();
        }

        Debug.Log("Moving");
        movement.MoveTo(targetPos);
        Debug.Log("Next Instruction");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{

    [Header("Subcontrollers")]
    [SerializeField] AiMovement movement;
    [SerializeField] AiAttack attack;
    [SerializeField][Tooltip("Should these field be " +
        "used instead of ones " +
        "found attached to this GameObject?")] bool overrideUnitControllerChoice = false;

    [Header("Test Items")]
    [SerializeField] Vector2 targetPos;
    [SerializeField] GameObject attackVictim;

    // Start is called before the first frame update
    void Start()
    {
        if(!overrideUnitControllerChoice)
        {
            movement = gameObject.GetComponent<AiMovement>();
            attack = gameObject.GetComponent<AiAttack>();
        }

        movement.SetAcceptedRange(attack.GetRange());

        movement.MoveTo(attackVictim.transform.position);
        StartCoroutine(attack.ContiniousAttack(attackVictim));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{

    Comp_UnitInfo unitInfo;

    [SerializeField] public GameObject objectiveTarget;

    ContactFilter2D sensorFilter;

    [Header("Sensor")]
    [SerializeField] Collider2D sensor;
    [SerializeField][Tooltip("Should this field be " +
    "used instead of the first Collider2D " +
    "found attached to this GameObject?")] bool overrideSenseFinding = true;

    [Header("Subcontrollers")]
    [SerializeField] AiMovement movement;
    [SerializeField] AiAttack attack;
    [SerializeField][Tooltip("Should these fields be " +
        "used instead of ones " +
        "found attached to this GameObject?")] bool overrideUnitControllerChoice = false;

    /*
    [Header("Test Items")]
    [SerializeField] Vector2 targetPos;
    [SerializeField] GameObject attackVictim;
    */

    bool coroutineTalkIsDistracted = false;
    bool coroutineTalkIsMovingOnObjective = false;
    IEnumerator AttackDistraction(GameObject distraction)
    {
        coroutineTalkIsDistracted = true;
        coroutineTalkIsMovingOnObjective = false;
        StartCoroutine(attack.ContiniousAttack(distraction));

        Comp_UnitInfo target_cui = distraction.GetComponent<Comp_UnitInfo>();

        while(target_cui.Health > 0)
        {
            movement.MoveTo(distraction.transform.position);
            yield return null;
        }
        coroutineTalkIsDistracted = false;
        coroutineTalkIsMovingOnObjective = false;
        Debug.Log(gameObject.name + " finished distraction");
    }

    IEnumerator AttackObjective()
    {
        coroutineTalkIsMovingOnObjective = true;

        movement.MoveTo(objectiveTarget.transform.position);

        StartCoroutine(attack.ContiniousAttack(objectiveTarget));

        Comp_UnitInfo target_cui = objectiveTarget.GetComponent<Comp_UnitInfo>();

        while(target_cui.Health > 0)
        {

            if (!coroutineTalkIsMovingOnObjective)
            {
                yield break;
            }

            Debug.Log("ASFHUDHSGIUHE");

            movement.MoveTo(objectiveTarget.transform.position);

            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter Detected: " + gameObject.name + " found " + collision.gameObject.name);
        if (collision.gameObject.layer == sensorFilter.layerMask.value && !collision.isTrigger)
        {
            Debug.Log("They are touching");
            if (collision.gameObject.GetComponent<Comp_UnitInfo>().Health > 0)
            {
                StartCoroutine(AttackDistraction(collision.gameObject));
            }
        }
    }

    IEnumerator attackObjectiveWithDistractions()
    {
        while (true)
        {
            if (!coroutineTalkIsDistracted)
            {
                /*                Collider2D[] results = new Collider2D[255];
                                int check = sensor.OverlapCollider(sensorFilter, results);
                                    GameObject livingEnemy = null;
                                    for(int i = 0; i < results.Length; i++)
                                    {
                                        if(results[i] == null)
                                        {
                                            break;
                                        }
                                    if (gameObject.name == "TestObject (3)")
                                    {
                                        Debug.Log(results[i].gameObject.name + " " + check);
                                    }
                                        if(results[i].gameObject.GetComponent<Comp_UnitInfo>().Health > 0)
                                        {
                                            livingEnemy = results[i].gameObject;
                                            break;
                                        }
                                    }
                                    if (livingEnemy != null)
                                    {
                                        StartCoroutine(AttackDistraction(livingEnemy));
                                    }
                */
                Debug.Log("Got here");
                    /*else*/ if (!coroutineTalkIsMovingOnObjective && objectiveTarget != null)
                    {
                    Debug.Log("asdf");
                        StartCoroutine(AttackObjective());
                    } else if (objectiveTarget == null) {
//                    yield return null;
                }
            }
            if(unitInfo == null || unitInfo.Health <= 0)
            {
                yield break;
            }
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!overrideSenseFinding || sensor == null) 
        {
            sensor = GetComponent<Collider2D>();
        }
        if(!overrideUnitControllerChoice)
        {
            movement = gameObject.GetComponent<AiMovement>();
            attack = gameObject.GetComponent<AiAttack>();
        }

        unitInfo = gameObject.GetComponent<Comp_UnitInfo>();

        sensorFilter = new ContactFilter2D();
        sensorFilter.useTriggers = false;
        sensorFilter.useLayerMask = true;
//        Debug.Log(LayerMask.LayerToName(gameObject.layer) + " " + gameObject.name);
        if (LayerMask.LayerToName(gameObject.layer) == "EnemyUnit")
        {
//            Debug.Log(gameObject.name);
            sensorFilter.layerMask = LayerMask.NameToLayer("PlayerUnit");
        } else
        {
            sensorFilter.layerMask = LayerMask.NameToLayer("EnemyUnit");
        }

        movement.SetAcceptedRange(attack.GetRange());

        if (objectiveTarget == null) {
            objectiveTarget = GameObject.FindGameObjectWithTag("Train");
        }

        StartCoroutine(attackObjectiveWithDistractions());


//        movement.MoveTo(attackVictim.transform.position);
//        StartCoroutine(attack.ContiniousAttack(attackVictim));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

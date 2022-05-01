using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttack : MonoBehaviour
{

    [SerializeField] float range = 0;
    [SerializeField] float damage = 1;
    [SerializeField] float attackSpeed = 1;
    [SerializeField][Tooltip("Should these fields take " +
        "precedence over those in a Comp_UnitInfo component" +
        "attached to this GameObject?")] bool overrideUnitInfo = false;

    //Check range and attack the target if withing range.
    public bool Attack(GameObject target)
    {
        if (IsInRange(target))
        {
            target.GetComponent<Comp_UnitInfo>().TakeDamage(damage);
            return true;
        } else
        {
            return false;
        }
    }

    //Check range and attack the target if withing range.
    public bool Attack(Comp_UnitInfo target)
    {
        if (IsInRange(target.gameObject))
        {
//            Debug.Log("Making CUI attack.");
            target.GetComponent<Comp_UnitInfo>().TakeDamage(damage);
            return true;
        }
        else
        {
//            Debug.Log("Out of range on CUI attack.");
            return false;
        }
    }

    //Start attacking and keep going until target's HP is 0 or less.
    //Will check range.
    public IEnumerator ContiniousAttack(GameObject target)
    {
        Comp_UnitInfo targetInfo = target.GetComponent<Comp_UnitInfo>();
        while(target != null && targetInfo.Health > 0)
        {
            Attack(targetInfo);
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    public bool IsInRange(GameObject target)
    {
        return (target.transform.position - gameObject.transform.position).magnitude <= range 
            || target.transform.position == gameObject.transform.position;
        //This last bit is necessary because == is designed to avoid float error
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!overrideUnitInfo)
        {
            Comp_UnitInfo unitOverride = gameObject.GetComponent<Comp_UnitInfo>();
            if(unitOverride != null)
            {
                range = unitOverride.AttackRange;
                damage = unitOverride.AttackDamage;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetRange() { return range; }

    public float GetDamage() { return damage; }

    public float GetAttackSpeed() { return attackSpeed; }

    public void SetRange(float newRange) { range = newRange; }

    public void SetDamage(float newDamage) { damage = newDamage; }

    public void SetAttackSpeed(float newAttackSpeed) { attackSpeed = newAttackSpeed; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_UnitInfo : MonoBehaviour
{
    
    [Header("Unit Info")]
    [SerializeField] public Constants.AlienTypes Species;
    [SerializeField] public float Health;
    [SerializeField] public float Armor;
    [SerializeField] public float AttackDamage;
    [SerializeField] public float AttackRange;
    [SerializeField] public float AttackSpeed;
    [SerializeField] public float Speed;
    [SerializeField] public float Money;

    [SerializeField] public virtual void TakeDamage(float DamageToTake)
    {
        Health -= DamageToTake;
        if(Health <= 0)
        {
            if (gameObject.layer == 13) // enemy layer
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().currentMoney += Money;
            }

            Destroy(gameObject);
        }
    }


}

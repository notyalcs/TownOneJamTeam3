using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(Species == Constants.AlienTypes.TRAIN)
            {
                Debug.Log("AFSNSDHGUHG");
                SceneManager.LoadScene("CreditsScene");
            }
            Destroy(gameObject);
        }
    }


}

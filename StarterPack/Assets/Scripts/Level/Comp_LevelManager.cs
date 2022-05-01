using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_LevelManager : MonoBehaviour
{
    [Header("Train Info")]
    [SerializeField] public GameObject Train;

    [Header("Enemy Info")]
    [SerializeField] public int EnemyCount = 0;

    private void LateUpdate() {
        if (EnemyCount <= 0) {
            Debug.Log("YOU BEAT THE LEVEL");
        }
    }

}

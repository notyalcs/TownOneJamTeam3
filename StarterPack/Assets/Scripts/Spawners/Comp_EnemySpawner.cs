using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_EnemySpawner : MonoBehaviour
{

    [Header("Unit Info")]
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private int _unitCount = 25;

    [Header("Spawn Info")]
    [SerializeField] private float _spawnSpeed = 0.2f;
    [SerializeField] private float _spawnRadius = 4.0f;


    private void Start() {

        GetComponentInParent<Comp_LevelManager>().EnemyCount += _unitCount;

        var spawning = StartCoroutine(SpawnUnit());
    }

    private IEnumerator SpawnUnit() {
        for (int i = 0; i < _unitCount; ++i) {
            float spawnX = transform.position.x + Random.value * _spawnRadius - (_spawnRadius / 2);
            float spawnY = transform.position.y + Random.value * _spawnRadius - (_spawnRadius / 2);

            GameObject newUnit = Instantiate(_unitPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
            //newUnit.GetComponent<AiController>().objectiveTarget = gameObject.transform.parent.gameObject.GetComponent<Comp_LevelManager>().Train;

            yield return new WaitForSeconds(_spawnSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0));
    }

}

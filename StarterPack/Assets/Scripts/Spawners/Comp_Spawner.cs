using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_Spawner : MonoBehaviour
{
    [Header("Spawn Info")]
    [SerializeField] private float _delay = 0.1f;
    [SerializeField] private float _distanceMultiplier = 10.0f;

    [Header("Unit Info")]
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private int _unitCount = 5;

    [Header("Cost")]
    [SerializeField] public float SpawnCost = 10.0f;

    private Vector3 _position;
    private Vector2 _spawnDirection;

    public void SpawnUnits() {
        _position = GetComponentInParent<Transform>().position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        Vector3 spawnDirection3D = mousePos - _position;
        _spawnDirection = new Vector2(spawnDirection3D.x, spawnDirection3D.y).normalized;

        StartCoroutine(InstantiateUnit());
    }

    private IEnumerator InstantiateUnit() {
        for (int i = 0; i < _unitCount; ++i) {
            _position = GetComponentInParent<Transform>().position;
            Vector3 spawnLocation = new Vector3(_spawnDirection.x, _spawnDirection.y, 0) * (Random.value * _distanceMultiplier);
            Instantiate(_unitPrefab, spawnLocation + _position, Quaternion.identity);
            yield return new WaitForSeconds(_delay);
        }
    }
}

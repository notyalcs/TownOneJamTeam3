using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_Spawner : MonoBehaviour
{
    [Header("Spawn Info")]
    [SerializeField] public float _delay = 0.1f;
    [SerializeField] public float _distanceMultiplier = 10.0f;
    [SerializeField] public float _angleOffset = 1.0f;

    [Header("Unit Info")]
    [SerializeField] public GameObject _unitPrefab;
    [SerializeField] public int _unitCount = 5;

    [Header("Cost")]
    [SerializeField] public float SpawnCost = 10.0f;

    private Vector3 _position;
    private Vector2 _spawnDirection;

    public void SpawnUnits(Vector3 spawnDirection3D) {
        //_position = GetComponentInParent<Transform>().position;
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        //Vector3 spawnDirection3D = mousePos - _position;
        _spawnDirection = new Vector2(spawnDirection3D.x, spawnDirection3D.y).normalized;

        StartCoroutine(InstantiateUnit());
    }

    private IEnumerator InstantiateUnit() {

        var audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Comp_MenuAudio>();
        audio.SpawnSFX();

        for (int i = 0; i < _unitCount; ++i) {
            //audio.SpawnSFX();
            _position = GetComponentInParent<Transform>().position;
            Vector3 spawnLocation = new Vector3(_spawnDirection.x + Random.value * _angleOffset, _spawnDirection.y + Random.value * _angleOffset, 0) * (Random.value * _distanceMultiplier);
            Instantiate(_unitPrefab, spawnLocation + _position, Quaternion.identity);

            yield return new WaitForSeconds(_delay);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [Header("Star Parameters")]
    [SerializeField] GameObject _starPrefab;
    [SerializeField] private int _spawnCount = 10;
    [SerializeField] private float _spawnFrequency = 1.0f;

    [Header("Other Objects")]
    [SerializeField] private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            float xPos = Random.Range(0, _camera.pixelWidth);
            float yPos = Random.Range(0, _camera.pixelHeight);
            Vector2 pos = new Vector2(xPos, yPos);
            pos = _camera.ScreenToWorldPoint(pos);

            GameObject go = Instantiate(_starPrefab, pos, Quaternion.identity, gameObject.transform);
            go.transform.localScale *= Random.Range(0, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [Header("Star Parameters")]
    [SerializeField] GameObject _starPrefab;
    [SerializeField] private int _spawnCount = 10;
    [SerializeField] private float _spawnFrequency = 1.0f;
    [SerializeField] private float _maxStarSize = 1.0f;
    [SerializeField] private float _starOffscreenBuffer = 20.0f;
    [SerializeField, Range(0, 500)] private int _maxOutOfBounds = 100;
    [SerializeField] private int _maxStars = 200;

    private float _timeSinceLastSpawn = 0;
    private int StarCount { get { return gameObject.transform.childCount; } }

    [Header("Other Objects")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Train _train;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            float xPos = Random.Range(-_maxOutOfBounds, _camera.pixelWidth + _maxOutOfBounds);
            float yPos = Random.Range(-_maxOutOfBounds, _camera.pixelHeight + _maxOutOfBounds);
            Vector2 pos = new Vector2(xPos, yPos);
            pos = _camera.ScreenToWorldPoint(pos);

            GameObject go = Instantiate(_starPrefab, pos, Quaternion.identity, gameObject.transform);
            go.GetComponent<DestructionManager>().SetCamera(_camera);
            go.GetComponent<SpeedStars>().SetTrain(_train);
            go.transform.localScale *= Random.Range(0, _maxStarSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn > 1 / _spawnFrequency && StarCount < _maxStars)
        {
            SpawnNewStar();
            _timeSinceLastSpawn = 0;
        }
    }

    void SpawnNewStar()
    {
        float xPos = Random.Range(-_maxOutOfBounds, _camera.pixelWidth + _maxOutOfBounds);
        float yPos = Random.Range(-_maxOutOfBounds, _camera.pixelHeight + _maxOutOfBounds);
        Vector2 pos = new Vector2(xPos, yPos);
        pos = _camera.ScreenToWorldPoint(pos);

        GameObject go = Instantiate(_starPrefab, pos, Quaternion.identity, gameObject.transform);
        go.GetComponent<DestructionManager>().SetCamera(_camera);
        go.GetComponent<SpeedStars>().SetTrain(_train);
        go.transform.localScale *= Random.Range(0, _maxStarSize);
    }
}

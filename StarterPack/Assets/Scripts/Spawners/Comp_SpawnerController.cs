using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_SpawnerController : MonoBehaviour
{
    [Header("UI Setup")]
    [SerializeField] private GameObject _buttonContainerInstance;
    [SerializeField] private GameObject _selectionItemPrefab;

    [Header("Spawners")]
    [SerializeField] private int _activeSpawner = 0;
    [SerializeField] private List<Comp_Spawner> _spawners;
    [SerializeField] private List<GameObject> _unitPrefabs;
    [SerializeField] private GameObject _spawnerPrefab;

    [Header("Cannon")]
    [SerializeField] private GameObject _cannonBase;
    [SerializeField] private float _cannonDistance = 1.0f;

    private const string _leftShoulder = "Fire1";
    private const string _rightShoulder = "Fire2";
    private const string _spawnButton = "Fire3";

    private bool _leftShoulderActive = false;
    private bool _rightShoulderActive = false;
    private bool _spawnButtonActive = false;

    private Comp_PlayerController _playerController;

    private Vector3 _spawnDirection;

    private void Start() {
        _playerController = GetComponent<Comp_PlayerController>();
        _activeSpawner = 0;
    }

    public void AddSpawner(Constants.AlienTypes species) {
        GameObject newSpawner = Instantiate(_spawnerPrefab, gameObject.transform);
        switch (species) {
            case Constants.AlienTypes.STRONG:
                newSpawner.GetComponent<Comp_Spawner>()._delay = 1.5f;
                newSpawner.GetComponent<Comp_Spawner>()._distanceMultiplier = 5f;
                newSpawner.GetComponent<Comp_Spawner>()._unitCount = 1;
                newSpawner.GetComponent<Comp_Spawner>().SpawnCost = 4f;
                newSpawner.GetComponent<Comp_Spawner>()._unitPrefab = _unitPrefabs[0];
                break;
            default:
                break;
        }

        _spawners.Add(newSpawner.GetComponent<Comp_Spawner>());
    }

    public void LevelStart()
    {
        _buttonContainerInstance = GameObject.FindGameObjectWithTag("AddableContaier");
        _playerController = GetComponent<Comp_PlayerController>();
        _activeSpawner = 0;
        for (int i = 0; i < _spawners.Count; i++)
        {
            GameObject fresh = Instantiate(_selectionItemPrefab);
            fresh.GetComponent<SpawnableElement>().Initialize(_spawners[i], i, this);
            fresh.transform.parent = _buttonContainerInstance.transform;
        }
    }

    public void SetSelectedIndex(int index)
    {
        _activeSpawner = index;
    }

    private void Update() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        _spawnDirection = mousePos - transform.position;

        Vector3 newSpawnDirection = new Vector3(_spawnDirection.x, _spawnDirection.y, 0).normalized;

        _cannonBase.transform.position = transform.position + newSpawnDirection * _cannonDistance;
        _cannonBase.transform.right = newSpawnDirection;

        if (!_leftShoulderActive && Input.GetAxisRaw(_leftShoulder) != 0) {
            _leftShoulderActive = true;

            if (_activeSpawner <= 0) {
                _activeSpawner = _spawners.Count - 1;
            } else {
                --_activeSpawner;
            }
        }

        if (!_rightShoulderActive && Input.GetAxisRaw(_rightShoulder) != 0) {
            _rightShoulderActive = true;

            if (_activeSpawner >= _spawners.Count - 1) {
                _activeSpawner = 0;
            } else {
                ++_activeSpawner;
            }
        }

        if (!_spawnButtonActive && Input.GetAxisRaw(_spawnButton) != 0) {
            _spawnButtonActive = true;

            AttemptToSpawn();
        }

        if (_leftShoulderActive && Input.GetAxisRaw(_leftShoulder) == 0) {
            _leftShoulderActive = false;
        }

        if (_rightShoulderActive && Input.GetAxisRaw(_rightShoulder) == 0) {
            _rightShoulderActive = false;
        }

        if (_spawnButtonActive && Input.GetAxisRaw(_spawnButton) == 0) {
            _spawnButtonActive = false;
        }

    }

    private void AttemptToSpawn() {
        if (_playerController.CurrentMoney >= _spawners[_activeSpawner].SpawnCost) {
            _spawners[_activeSpawner].SpawnUnits(_spawnDirection);
            _playerController.CurrentMoney -= _spawners[_activeSpawner].SpawnCost;
        }
    }

}

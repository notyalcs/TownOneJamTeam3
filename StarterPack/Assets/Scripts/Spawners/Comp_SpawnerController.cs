using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_SpawnerController : MonoBehaviour
{

    [Header("Spawners")]
    [SerializeField] private int _activeSpawner = 0;
    [SerializeField] private List<Comp_Spawner> _spawners;

    private const string _leftShoulder = "Fire1";
    private const string _rightShoulder = "Fire2";
    private const string _spawnButton = "Fire3";

    private bool _leftShoulderActive = false;
    private bool _rightShoulderActive = false;
    private bool _spawnButtonActive = false;

    private Comp_PlayerController _playerController;

    private void Start() {
        _playerController = GetComponent<Comp_PlayerController>();
        _activeSpawner = 0;
    }

    private void Update() {
        //AttemptToSpawn();

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
        if (_playerController.UpgradeResources >= _spawners[_activeSpawner].SpawnCost) {
            _spawners[_activeSpawner].SpawnUnits();
            _playerController.UpgradeResources -= _spawners[_activeSpawner].SpawnCost;
        }
    }

}

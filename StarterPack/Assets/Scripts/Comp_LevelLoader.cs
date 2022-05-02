using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_LevelLoader : MonoBehaviour
{

    [Header("In Level")]
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _path;

    private void Awake()
    {

    }

    private void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
        
        manager.GetComponent<GameManager>()._engine.SetActive(true);

        GameObject engine = manager.GetComponent<GameManager>()._engine.gameObject;

        _camera.GetComponent<Awesome2DCamera>().target = engine.transform;

        engine.GetComponent<Train>()._path = _path.GetComponent<TrainPath>();

        engine.GetComponentInChildren<Comp_SpawnerController>().LevelStart();
    }

}

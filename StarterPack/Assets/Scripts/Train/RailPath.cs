using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPath : MonoBehaviour
{
    [Header("Sprite Information")]
    [SerializeField] private TrainPath path;
    private int numPaths;
    [SerializeField] private int _railSteps = 5;

    [Header("Prefabs")]
    [SerializeField] private GameObject _railPrefab;


    // Start is called before the first frame update
    void Start()
    {
        numPaths = path.PathCount;

        for (int i = 0; i < _railSteps; i++)
        {
            Vector2 start = path.GetPathPosition(((float) i * numPaths) / _railSteps);
            Vector2 end = path.GetPathPosition(((float) (i + 1) * numPaths) / _railSteps);
            Vector2 center = Vector2.Lerp(start, end, 0.5f);
            float pathCenter = (((float) i * numPaths) / _railSteps + ((float) (i + 1) * numPaths) / _railSteps) / 2;
            Vector2 direction = path.GetPathDirection(pathCenter);
            float theta = Mathf.Atan2(direction.y, direction.x);
            Instantiate<GameObject>(_railPrefab, center, Quaternion.AngleAxis(Mathf.Rad2Deg * theta, Vector3.forward), transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

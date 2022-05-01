using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionManager : MonoBehaviour
{
    [Header("Tracking Camera")]
    [SerializeField] private Camera _camera;

    [Header("Feelers")]
    [SerializeField, Range(0, 500)] private int _maxLiveDist = 100;
    // Update is called once per frame
    void Update()
    {
        // slow, stands for optimisation
        if (_camera.WorldToScreenPoint(transform.position).x < 0 - _maxLiveDist
         || _camera.WorldToScreenPoint(transform.position).x > _camera.pixelWidth + _maxLiveDist
         || _camera.WorldToScreenPoint(transform.position).y < 0 - _maxLiveDist
         || _camera.WorldToScreenPoint(transform.position).y > _camera.pixelHeight + _maxLiveDist)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetCamera(Camera cam)
    {
        _camera = cam;
    }
}

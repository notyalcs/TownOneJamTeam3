#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Train Movement")]
    [SerializeField] private TrainPath path;

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float followDistance = 0.5f;

    private float curPosition = 0.0f;

    private Train head;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
#if DEBUG
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            curPosition = 0.0f;
        }
#endif

        curPosition += speed;
        gameObject.transform.position = path.GetPathPosition(curPosition);
        Vector2 lookDir = path.GetPathDirection(curPosition).normalized;
        float lookAngle = Mathf.Atan2(lookDir.y, lookDir.x);
        gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * lookAngle, Vector3.forward);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(gameObject.transform.position, path.GetPathDirection(curPosition).normalized);
    }
}

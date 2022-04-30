using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPath : MonoBehaviour
{
    [SerializeField]
    private List<BezierCurve> paths;


    [SerializeField, Range(1, 20)]
    private int _curveGizmoSteps = 5;

    private void Start() 
    {

    }

    public Vector2 GetPathPosition(float position)
    {
        int pathIndex = (int) Mathf.Clamp(position, 0, paths.Count - 0.01f);
        float posDecimal = position - (int) position;
        return paths[pathIndex].Berp(posDecimal);
    }

    public Vector2 GetPathDirection(float position)
    {
        int pathIndex = (int) Mathf.Clamp(position, 0, paths.Count - 0.01f);
        float posDecimal = position - (int) position;
        return paths[pathIndex].Direction(posDecimal);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        foreach (var path in paths)
        {
            for (int i = 0; i < _curveGizmoSteps; i++)
            {
                Vector2 curveFirst = path.Berp((float)i / _curveGizmoSteps);
                Vector2 curveSecond = path.Berp((float)(i + 1) / _curveGizmoSteps);
                Vector3 from = new Vector3(curveFirst.x, curveFirst.y);
                Vector3 to = new Vector3(curveSecond.x, curveSecond.y);
                Gizmos.DrawLine(from, to);
                Gizmos.DrawSphere(path.P1, 0.2f);
                Gizmos.DrawLine(path.P0, path.P1);
                Gizmos.DrawSphere(path.P2, 0.2f);
                Gizmos.DrawLine(path.P3, path.P2);
            }
        }
    }
}

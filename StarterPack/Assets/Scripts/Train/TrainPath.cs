using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPath : MonoBehaviour
{
    [SerializeField]
    private List<BezierCurve> paths;
    public int PathCount { get { return paths.Count; } }

    [SerializeField, Range(1, 20)]
    private int _curveGizmoSteps = 5;

    private void Start() 
    {

    }

    public Vector2 GetPathPosition(float position)
    {
        int pathIndex = (int) Mathf.Clamp(position, 0, paths.Count - 0.01f);
        float posDecimal = position - (int) pathIndex;
        return paths[pathIndex].Berp(posDecimal);
    }

    public Vector2 GetPathDirection(float position)
    {
        int pathIndex = (int) Mathf.Clamp(position, 0, paths.Count - 0.01f);
        float posDecimal = position - (int) pathIndex;
        return paths[pathIndex].Direction(posDecimal);
    }

    void OnDrawGizmos()
    {
        foreach (var path in paths)
        {
            Gizmos.color = Color.white;
            for (int i = 0; i < _curveGizmoSteps; i++)
            {
                Vector2 curveFirst = path.Berp((float) i / _curveGizmoSteps);
                Vector2 curveSecond = path.Berp((float) (i + 1) / _curveGizmoSteps);
                Vector3 from = new Vector3(curveFirst.x, curveFirst.y);
                Vector3 to = new Vector3(curveSecond.x, curveSecond.y);
                Gizmos.DrawLine(from, to);
                Gizmos.DrawSphere(from, 0.1f);
            }

            // control points
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(path.P1, 0.2f);
            Gizmos.DrawLine(path.P0, path.P1);
            Gizmos.DrawSphere(path.P2, 0.2f);
            Gizmos.DrawLine(path.P3, path.P2);

            // destination points
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(path.P0, 0.2f);
            Gizmos.DrawSphere(path.P3, 0.2f);
        }
    }
}

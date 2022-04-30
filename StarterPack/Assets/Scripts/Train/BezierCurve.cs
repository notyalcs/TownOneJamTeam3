using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BezierCurve
{

    public Vector2 P0;
    public Vector2 P1;
    public Vector2 P2;
    public Vector2 P3;

    public BezierCurve(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3) => (P0, P1, P2, P3) = (p0, p1, p2, p3);

    /// <summary>
    /// Finds a point along the bezier curve. 0 <= t <= 1, t is clamped between 0 and 1.
    /// </summary>
    /// <param name="t">The % point along the curve (time technically)</param>
    /// <returns>The point along the bezier curve</returns>
    public Vector2 Berp(float t) 
    {
        t = Mathf.Clamp01(t);
        return Mathf.Pow(1 - t, 3) * P0 + 3 * Mathf.Pow(1 - t, 2) * t * P1 + 3 * (1 - t) * Mathf.Pow(t, 2) * P2 + Mathf.Pow(t, 3) * P3;
    }

    public Vector2 Direction(float t)
    {
        t = Mathf.Clamp01(t);
        return 3 * Mathf.Pow(1 - t, 2) * (P1 - P0) + 6 * (1 - t) * t * (P2 - P1) + 3 * Mathf.Pow(t, 2) * (P3 - P2);
    }
}

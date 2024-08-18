using System.Collections;
using UnityEditor;
using UnityEngine;

public class QuadraticBezierCurve : MonoBehaviour
{
    [SerializeField] private Vector3 point0, point1, point2;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float pause = 1f;
    private TrailRenderer trail;
    private float t = 0f;

    void Start() {
        trail = GetComponent<TrailRenderer>();
    }

    void Update() {
        StartCoroutine(MoonCurve());
    }

    private IEnumerator MoonCurve() {
        if (t == 0) {
            t += Time.deltaTime / duration;
            transform.position = CalculateQuadraticBezierPoint(t, point0, point1, point2);
        }
        else if (t < 1) {
            trail.enabled = true;            
            t += Time.deltaTime / duration;
            transform.position = CalculateQuadraticBezierPoint(t, point0, point1, point2);
        } else {
            trail.enabled = false;
            yield return new WaitForSeconds(pause);
            t = 0f;
        }
    }

    Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0; // (1-t)^2 * p0
        p += 2 * u * t * p1; // 2 * (1-t) * t * p1
        p += tt * p2; // t^2 * p2

        return p;
    }
}


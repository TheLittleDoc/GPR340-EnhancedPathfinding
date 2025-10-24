using System.Collections;
using System.Collections.Generic;
using Algos;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    List<Vector3> points = new List<Vector3>();

    private Smoothing smoothing;

    private List<Vector2> _interpolatedPoints;

    // Start is called before the first frame update
    void Start()
    {
        smoothing = GetComponent<Smoothing>();
        points.Add(transform.position);
        points.Add(transform.position + Vector3.left);
        points.Add(points[1] + Vector3.forward);
        points.Add(points[2] + Vector3.left);
        List<Vector2> flatPoints = new List<Vector2>();
        foreach (Vector3 point in points)
        {
            flatPoints.Add(new Vector2(point.x, point.z));
        }
        _interpolatedPoints = smoothing.Smooth(flatPoints, 32);
        
        string output = "";
        foreach (Vector2 point in _interpolatedPoints)
        {
            output += point.ToString();
            output += ",";
        }
        Debug.Log(output);
        transform.position = _interpolatedPoints[0];
        // animate one point per second
        StartCoroutine(Co_FollowPath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Co_FollowPath()
    {
        var steps = _interpolatedPoints.Count;
        for (int i = 0; i <= steps; i++)
        {
            yield return new WaitForSeconds(1);
            transform.position = _interpolatedPoints[i];
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using Algos;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float speed = 1.0f;
    public float progress = 1.0f;
    public PathFindingGrid grid;
    public Pathfinding pathfinder;

    List<Vector3> points = new List<Vector3>();
    //temporary pathfind testers
    Vector3 to;
    public Vector3 from;

    public bool active = false;

    private Smoothing smoothing;
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
        List<Vector2> interpolatedPoints = smoothing.Smooth(flatPoints, 32);
        string output = "";
        foreach (Vector2 point in interpolatedPoints)
        {
            output += point.ToString();
            output += ",";
        }
        Debug.Log(output);
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            progress += Time.deltaTime * speed;

            if(progress >= 1.0f)
            {
                from = to;
                //THIS IS BROKEN
                if(to == from)
                {
                    active = false;
                    return;
                }
                progress = 0.0f;
            }
            this.transform.position = Vector3.Lerp(from, to, progress);
        }
    }

    public void spawnTeleport()
    {
        this.transform.position = grid.indexPosition(grid.spawnIndex);
    }
}

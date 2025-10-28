using System.Collections;
using System.Collections.Generic;
using Algos;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float speed = 1.0f;
    public float progress = 0.0f;
    public PathFindingGrid grid;
    public Pathfinding pathfinder;

    List<Vector3> points = new List<Vector3>();
    List<Vector3> splinePoints = new List<Vector3>();
    //temporary pathfind testers
    Vector3 to;
    public Vector3 from;

    private Vector3 fromSpline;
    private Vector3 toSpline;

    public bool active = false;
    bool lastMove = false;
    private int step = 0;

    [SerializeField] private Smoothing smoothing;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            progress += Time.deltaTime * speed;
            step = smoothing.steps * (int)(smoothing.steps * progress);
            if(progress >= 1.0f)
            {
                if (lastMove)
                {
                    active = false;
                    lastMove = false;
                    return;
                }
                from = to;
                fromSpline = toSpline;
                pathfinder.calculatePath();
                splinePoints.Clear();
                
                splinePoints = smoothing.Smooth(grid.getPathList(), 25);
                string splineMessage = "Spline Points: ";
                foreach (Vector3 v in splinePoints)
                {
                    splineMessage += v.ToString() + ", ";
                }
                Debug.Log(splineMessage);
                to = grid.indexPosition(pathfinder.next.index);
                toSpline = splinePoints[splinePoints.Count - 1];
                if (to == grid.indexPosition(grid.goalIndex))
                {
                    lastMove = true;
                }
                progress = 0.0f;

            }
            transform.position = Vector3.Lerp(fromSpline, toSpline, progress);
        }
    }

    public void spawnTeleport()
    {
        this.transform.position = grid.indexPosition(grid.spawnIndex);
        from = this.transform.position;
        to = from;
    }
}

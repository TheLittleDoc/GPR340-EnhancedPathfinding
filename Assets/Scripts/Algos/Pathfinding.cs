using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
    public int index;
    public int fromIndex;
    public int costSoFar;
    public int costEstimated;

    public Location() { }
    public Location(int iIn, int fiIn, int csfIn, int ceIn)
    {
       index = iIn; 
       fromIndex = fiIn; 
       costSoFar = csfIn; 
       costEstimated = ceIn; 
    }
}

public class Pathfinding : MonoBehaviour
{
    // Get world data, run algorithm
    public PathFindingGrid grid;

    Location goal = new Location();
    Location next = new Location();

    List<int> toExplore = new List<int>();
    Dictionary<int, Location> exploring = new Dictionary<int, Location>();
    Dictionary<int, Location> explored = new Dictionary<int, Location>();
    int preAddition = 0;

    private Vector3 _location;
    Dictionary<Vector3, Vector3> _path = new Dictionary<Vector3, Vector3>();
     
    // Start is called before the first frame update
    void Start()
    {
        goal.costSoFar = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        //update goal from grid
        goal.index = grid.goalIndex;
    }

    void GetPosition()
    {
        _location = transform.position;
    }

    int addIndexSorted(List<int> list, int index, int costE)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (costE < exploring[list[i]].costEstimated)
            {
                list.Insert(i, index);
                if(i <= preAddition)
                {
                    return 1;
                }
                return 0;
            }
        }
        list.Add(index);
        return 0;
    }

    public int calculatePath()
    {
        //reset
        toExplore.Clear();
        exploring.Clear();
        explored.Clear();

        //intialize
        int start = grid.indexAtPoint(transform.position);
        toExplore.Add(start);
        exploring.Add(start, new Location(start, start, 0, 0));
        goal.costSoFar = 100000;

        Location current;
        List<int> nearby = new List<int>();

        while (exploring[toExplore[0]].costEstimated < goal.costSoFar)
        {
            current = exploring[toExplore[0]];
            preAddition = 0;

            nearby.Clear();
            grid.getValidNeighbors(current.index, nearby);

            foreach (int i in nearby)
            { 
                Location neighbor = new Location(i, current.index, current.costSoFar + 1, 0);

                //manhattan distance. do we need additional hueristic?
                neighbor.costEstimated = grid.getDist(i, goal.index);

                if (explored.ContainsKey(i))
                {
                    if (explored[i].costSoFar <= neighbor.costSoFar)
                    {
                        continue;
                    }

                    exploring.Add(i, neighbor);
                    preAddition += addIndexSorted(toExplore, i, neighbor.costEstimated);
                    explored.Remove(i);
                }
                else if (exploring.ContainsKey(i))
                {
                    if (exploring[i].costSoFar <= neighbor.costSoFar)
                    {
                        continue;
                    }
                    //theoretically this should be resorted in the to search list
                    exploring[i].costSoFar = neighbor.costSoFar;
                    exploring[i].costEstimated = neighbor.costEstimated;
                }
                else
                {
                    exploring.Add(i, neighbor);
                    preAddition += addIndexSorted(toExplore, i, neighbor.costEstimated);

                }
            }

            //add to explord, remove from exploring and search
            explored.Add(current.index, current);
            exploring.Remove(current.index);
            toExplore.RemoveAt(0 + preAddition);

            //check if goal inaccessible somewhere here
        }

        //best route should now be found
        int posI = grid.indexAtPoint(transform.position);
        int check0 = goal.index;
        int check1 = goal.fromIndex;
        while(check1 != posI)
        {
            check0 = check1;
            check1 = explored[check0].fromIndex;
        }

        next = explored[check0];
        return next.index;
    }
    
    
}

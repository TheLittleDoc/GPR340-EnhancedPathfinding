using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Node
{
    public Vector2 pos;
    public bool blocked;

    public Node(float x , float y)
    {
        pos = new Vector2 (x, y);
        blocked = false;
    }
    public void toggleBlock()
    {
        blocked = !blocked;
    }
}

public class PathFindingGrid : MonoBehaviour
{
    public int width = 5;
    public int height = 5;
    float hiddenY = -50.0f;
    float visibleY = 1.0f;

    int spawnIndex = 0;
    int goalIndex;

    float gridSpacing = 5;

    public GameObject blocker;
    public GameObject debugParticle;
    public GameObject spawnEffect, goalEffect;

    List<Node> grid;
    List<GameObject> blockers;
    // Start is called before the first frame update
    void Start()
    {
        generateGrid(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //generates and regenerates grid by supplied width and height
    public void generateGrid(bool reset)
    {
        if (reset)
        {
            grid.Clear();
            blockers.Clear();
        }

        grid = new List<Node>(width * height);
        blockers = new List<GameObject>();
        //Debug.Log(width * height + " / " + grid.Capacity);
        for (int x = -width / 2; x <= width / 2; x++)
        {
            for (int y = -height / 2; y <= height / 2; y++)
            {
                grid.Add(new Node(x * gridSpacing, y * gridSpacing));
                blockers.Add(Instantiate(blocker, new Vector3(x * gridSpacing, hiddenY, y * gridSpacing), Quaternion.identity));
            }
        }
        spawnIndex = 0;
        goalIndex = width * height;

        //this is just debug to see gridpoints
        foreach (Node node in grid)
        {
            //Instantiate(debugParticle, new Vector3(node.pos.x, 0.0f, node.pos.y), Quaternion.identity);
            //Replace with new image thing
        }
    }

    int indexAtPoint(Vector3 pos)
    {
        int index = 0;
        float xDist = 1000.0f, zDist = 1000.0f;

        for (int i = 0; i < grid.Count; i++)
        {
            float xCheck = Mathf.Abs(pos.x - grid[i].pos.x);
            float zCheck = Mathf.Abs(pos.z - grid[i].pos.y);
            if (xDist >= xCheck && zDist >= zCheck)
            {
                xDist = xCheck;
                zDist = zCheck;
                index = i;
            }
        }
        Debug.Log(index);
        return index;
    }

    //enable or disable the blocker at node
    public void toggleNode(Vector3 nearestPos)
    {
        int index = indexAtPoint(nearestPos);

        if (grid[index].blocked)
        {
            blockers[index].transform.position = new Vector3(blockers[index].transform.position.x, hiddenY, blockers[index].transform.position.z);
            grid[index].toggleBlock();
        }
        else
        {
            blockers[index].transform.position = new Vector3(blockers[index].transform.position.x, visibleY, blockers[index].transform.position.z);
            grid[index].toggleBlock();
        }
    }

    public void setSpawn(Vector3 nearestPos)
    {
        int index = indexAtPoint(nearestPos);
        spawnIndex = index;
        spawnEffect.transform.position = new Vector3(grid[spawnIndex].pos.x, 0.5f, grid[spawnIndex].pos.y);

    }
    public void SetGoal(Vector3 nearestPos)
    {
        int index = indexAtPoint(nearestPos);
        goalIndex = index;
        goalEffect.transform.position = new Vector3(grid[spawnIndex].pos.x, 0.5f, grid[spawnIndex].pos.y);
    }

    public void setWidth(int widthIn)
    {
        width = widthIn;
    }
    public void setHeight(int heightIn) 
    { 
        height = heightIn; 
    }
}

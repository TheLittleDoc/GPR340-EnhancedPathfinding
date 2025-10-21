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
    float visibleY = 5.0f;

    int spawnIndex = 0;
    int goalIndex;

    float gridSpacing = 5;

    public GameObject blocker;
    public GameObject debugParticle;

    List<Node> grid;
    List<GameObject> blockers;
    // Start is called before the first frame update
    void Start()
    {
        generateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //generates and regenerates grid by supplied width and height
    public void generateGrid()
    {
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
            Instantiate(debugParticle, new Vector3(node.pos.x, 0.0f, node.pos.y), Quaternion.identity);
        }
    }

    //enable or disable the blocker at node
    public void toggleNode(Vector3 nearestPos)
    {
        if (grid[0].blocked)
        {
            blockers[0].transform.position = new Vector3(blockers[0].transform.position.x, hiddenY, blockers[0].transform.position.z);
            grid[0].toggleBlock();
        }
        else
        {
            blockers[0].transform.position = new Vector3(blockers[0].transform.position.x, visibleY, blockers[0].transform.position.z);
            grid[0].toggleBlock();
        }
    }

    public void setSpawn(Vector3 nearestPos)
    {

    }
    public void SetGoal(Vector3 nearestPos)
    {

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

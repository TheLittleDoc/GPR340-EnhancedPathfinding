using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public struct Node
{
    public Vector2 pos;
    public bool blocked;

    public Node(float x , float y)
    {
        pos = new Vector2 (x, y);
        blocked = false;
    }
}

public class PathFindingGrid : MonoBehaviour
{
    public int width = 5;
    public int height = 5;

    int spawnIndex = 0;
    int goalIndex;

    float gridSpacing = 5;

    public GameObject debugParticle;

    List<Node> grid;
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
        //Debug.Log(width * height + " / " + grid.Capacity);
        for (int x = -width / 2; x <= width / 2; x++)
        {
            for (int y = -height / 2; y <= height / 2; y++)
            {
                grid.Add(new Node(x * gridSpacing, y * gridSpacing));
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

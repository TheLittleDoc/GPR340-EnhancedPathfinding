using System.Collections;
using System.Collections.Generic;
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

    float gridSpacing = 5;

    public GameObject debugParticle;

    List<Node> grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new List<Node>(width * height);
        //Debug.Log(width * height + " / " + grid.Capacity);
        for(int x = - width / 2; x <= width / 2; x++)
        {
            for (int y = -height / 2; y <= height / 2; y++)
            {
                grid.Add(new Node(x * gridSpacing, y * gridSpacing));
            }
        }

        foreach(Node node in grid)
        {
            Instantiate(debugParticle, new Vector3(node.pos.x, 0.0f, node.pos.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    // Get world data, run algorithm

    private Vector3 _location;
    Dictionary<Vector3, Vector3> _path = new Dictionary<Vector3, Vector3>();
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetPosition()
    {
        _location = transform.position;
    }
    
    
}

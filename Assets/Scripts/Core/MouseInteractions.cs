using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractions : MonoBehaviour
{
    public bool settingSpawn = false;
    public bool settingGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            //raytrace to grid at mouse pos
            //get nearest grid node by position

            if(settingSpawn)
            {
                //setSpawn as grid node
            }
            if(settingGoal)
            {
                //set goal as grid node
            }

            //toggle block of gridmode and  enable / disable the cube
        }
    }
}

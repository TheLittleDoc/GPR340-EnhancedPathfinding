using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractions : MonoBehaviour
{
    public PathFindingGrid grid;

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
            Vector3 screenMousePos = Input.mousePosition;
            screenMousePos.z = Camera.main.transform.position.y;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

            if (settingSpawn)
            {
                //setSpawn as grid node
                grid.setSpawn(worldMousePos);
                settingSpawn = false;
            }
            else if(settingGoal)
            {
                //set goal as grid node
                grid.SetGoal(worldMousePos);
                settingGoal = false;
            }
            else
            {
                //toggle block of gridmode and  enable / disable the cube
                grid.toggleNode(worldMousePos);
            }

        }
    }
}

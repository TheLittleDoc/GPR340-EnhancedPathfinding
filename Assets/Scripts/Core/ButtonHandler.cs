using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public PathFindingGrid grid;
    public MouseInteractions mouseScript;
    public MovementController movementController;
    public Pathfinding pathfinder;
    public TMP_InputField widthInput;
    public TMP_InputField heightInput;

    // Start is called before the first frame update
    void Start()
    {
        widthInput.onEndEdit.AddListener(delegate { handleWidthInput(widthInput.text); });
        heightInput.onEndEdit.AddListener(delegate { handleHeightInput(heightInput.text); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void handleWidthInput(string input)
    {
        if (input.Length > 0)
        {
            grid.setWidth(int.Parse(input));
        }
    }
    void handleHeightInput(string input)
    {
        if (input.Length > 0)
        {
            grid.setHeight(int.Parse(input));
        }
    }

    public void toggleSpawnPlacing()
    {
        mouseScript.settingSpawn = true;
        mouseScript.settingGoal = false;
    }
    public void toggleGoalPlacing()
    {
        mouseScript.settingSpawn = false;
        mouseScript.settingGoal = true;
    }

    public void startAgent()
    {
        movementController.spawnTeleport();
        movementController.active = true;
        movementController.from = grid.indexPosition(grid.spawnIndex);
        movementController.transform.position = movementController.from + new Vector3(0.0f, 1.0f, 0.0f);
        movementController.progress = 1.0f;
    }

    public void runVisual()
    {
        movementController.spawnTeleport();
        //pathfinding.calculate
        pathfinder.calculatePath();
        List<int> path = new List<int>();

        int check0 = grid.goalIndex;
        int check1 = pathfinder.explored[check0].fromIndex;
        path.Add(check0);
        path.Add(check1);
        while (check0 != check1)
        {
            check0 = check1;
            check1 = pathfinder.explored[check0].fromIndex;
            path.Add(check1);
        }

        //set grid at indexes path variable.
        //run show path in grid
        grid.setPath(path);
        //profit?

    }
}

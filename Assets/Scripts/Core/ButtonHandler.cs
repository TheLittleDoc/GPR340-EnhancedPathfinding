using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public PathFindingGrid grid;
    public MouseInteractions mouseScript;
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
}

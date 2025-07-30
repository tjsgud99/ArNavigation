using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path; // current calculated path
    private LineRenderer line; // linerenderer to display path
    private Vector3 targetPosition = Vector3.zero; // current target position

    private int currentFloor = 1;

    private bool lineToggle = false;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    private void Update()
    {
        if (lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            Vector3[] calculatedPathAndOffset = AddLineOffset();
            line.SetPositions(calculatedPathAndOffset);

        }
    }
    public void SetCurrentNavigationTarget(int selectedValue)
    {
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if (currentTarget != null)
        {

            if (!line.enabled)
            {
                ToggleVisibility();
            }

            targetPosition = currentTarget.PositionObject.transform.position;
        }
    }

    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }

    public void ChangeActiveFloor(int floorNumber)
    {
        currentFloor = floorNumber;
        SetNavigationTargetDropDownOptions(currentFloor);
    }

    private Vector3[] AddLineOffset()
    {
        if (navigationYOffset.value == 0)
        {
            return path.corners;
        }

        Vector3[] calculatedLine = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedLine[i] = path.corners[i] + new Vector3(0, navigationYOffset.value, 0);
        }
        return calculatedLine;
    }

    private void SetNavigationTargetDropDownOptions(int floorNumber)
    {
        navigationTargetDropDown.ClearOptions();
        navigationTargetDropDown.value = 0;

        if (line.enabled)
        {
            ToggleVisibility();
        }

        if (floorNumber == 10)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube10119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube10117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube10120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube10108"));
          
        }
        if (floorNumber == 9)
        {
            
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube9119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube9117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube9120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube9108"));
        }
        if (floorNumber == 8)
        {
            
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube8119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube8117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube8120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube8108"));
        }
        if (floorNumber == 7)
        {
            
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube7119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube7117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube7120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube7108"));
        }
        if (floorNumber == 6)
        {

            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube6119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube6117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube6120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube6210"));
        }
        if (floorNumber == 5)
        {

            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube5119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube5117"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube5120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube5205"));
        }
        if (floorNumber == 4)
        {

            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube4218"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube4123"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube4205"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube4228"));
        }
        if (floorNumber == 3)
        {

            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube3120"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube3108"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube3203"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube3228"));
        }
        if (floorNumber == 2)
        {

            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube2119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube2204"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube2104-2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube2228"));
        }
        if (floorNumber == 1)
        {

            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube1119"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube1225"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCubeESpace"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("TargetCube1006-3"));
        }
    }
}
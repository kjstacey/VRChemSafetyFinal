using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRandomViolations : MonoBehaviour
{
    // Init arrays to store GameObjects
    GameObject[] foodAndDrink;
    GameObject[] safetyEqpt;
    GameObject[] heatElements;
    GameObject[] brokenGlass;
    // CHEMICAL SPILL
    GameObject[] objWalkway;

    int numFood = 0;
    int numSafety = 0;
    int numHeat = 0;
    int numGlass = 0;
    // CHEMICAL SPILL
    int numObj = 0;

    // Store Toggles
    [SerializeField]
    Toggle foodToggle;
    Toggle safetyToggle;
    Toggle heatToggle;
    Toggle glassToggle;
    // CHEMICAL SPILL GameObject toggle;
    Toggle objToggle;

    // Start is called before the first frame update
    void Start()
    {
        // Put all GameObjects in respective arrays
        foodAndDrink = GameObject.FindGameObjectsWithTag("FoodAndDrink");
        safetyEqpt = GameObject.FindGameObjectsWithTag("Safety");
        heatElements = GameObject.FindGameObjectsWithTag("HeatOn");
        brokenGlass = GameObject.FindGameObjectsWithTag("BrokenGlass");
        objWalkway = GameObject.FindGameObjectsWithTag("InWalkway");

        // TODO: Randomize to turn certain ones active

        // When activated, run through each array and count which ones are active for end printout
        foreach (var food in foodAndDrink)
        {
            if (food.activeInHierarchy)
            {
                numFood++;
            }
        }
        foreach (var eqpt in safetyEqpt)
        {
            if (eqpt.activeInHierarchy)
            {
                numSafety++;
            }
        }
        foreach (var element in heatElements)
        {
            if (element.activeInHierarchy)
            {
                numHeat++;
            }
        }
        foreach (var glass in brokenGlass)
        {
            if (glass.activeInHierarchy)
            {
                numGlass++;
            }
        }
        foreach (var obj in objWalkway)
        {
            if (obj.activeInHierarchy)
            {
                numObj++;
            }
        }
    }

    void GradeSimulation()
    {
        int correct = 0;
        int outOf = 5; // 6; - CHEMICAL SPILL
        bool objectActiveAndToggleOn = false; // Food active in the hierarchy and toggle is on (user marked violation correctly)
        bool objectInactiveAndToggleOff = false; // Food inactive in violation and toggle off (user did not mark violation because none occured)
        // If an object in the array is active AND the toggle has been clicked, say they passed
        foreach (var food in foodAndDrink)
        {
            // If there is not a food active in the hierarchy (violation) and toggle is on (user marked violation)
            if (food.activeInHierarchy && foodToggle.isOn)
            {
                objectActiveAndToggleOn = true;
            }
        }
        if (objectActiveAndToggleOn) correct++;
    }
}

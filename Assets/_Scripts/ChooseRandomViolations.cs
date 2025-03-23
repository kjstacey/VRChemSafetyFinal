using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ChooseRandomViolations : MonoBehaviour
{
    // Init arrays to store GameObjects
    GameObject[] objWalkway;
    GameObject[] foodAndDrink;
    GameObject[] heatElements;
    GameObject[] brokenGlass;
    // CHEMICAL SPILL GameObject[] chemSpill;
    GameObject[] safetyEqpt;

    public static int numObj;
    public static int numFood;
    public static int numHeat;
    public static int numGlass;
    // CHEMICAL SPILL
    public static int numSafety;

    // Store Toggles
    [SerializeField]
    Toggle objToggle;
    [SerializeField]
    Toggle foodToggle;
    [SerializeField]
    Toggle heatToggle;
    [SerializeField]
    Toggle glassToggle;
    // CHEMICAL SPILL
    // [SerializeField]
    // GameObject spillToggle;
    [SerializeField]
    Toggle safetyToggle;

    // Store TextBoxes for final screen
    [SerializeField] GameObject SubmittedScreen;
    [SerializeField] TextMeshProUGUI finalScoreTMP;
    [SerializeField] TextMeshProUGUI objectResultTMP;
    [SerializeField] TextMeshProUGUI foodResultTMP;
    [SerializeField] TextMeshProUGUI heatResultTMP;
    [SerializeField] TextMeshProUGUI glassResultTMP;
    //[SerializeField] TextMeshProUGUI spillResultTMP;
    [SerializeField] TextMeshProUGUI eqptResultTMP;
    [SerializeField] Button afterScoringExit;
    [SerializeField] Button afterScoringRestart;

    // For randomly selecting array elements
    List<int> randomNumberArrayElementObj;
    List<int> randomNumberArrayElementFood;
    List<int> randomNumberArrayElementHeat;
    List<int> randomNumberArrayElementGlass;
    // List<int> randomNumberArrayElementChem;
    List<int> randomNumberArrayElementSafety;

    [SerializeField] SendToSheets sendToGSheet;
    public string PartOfSim = "Violation Simulation";

    // SceneManagement
    SceneManagement sceneManage;

    // Start is called before the first frame update
    void Start()
    {
        // Init with 0
        numObj = 0;
        numFood = 0;
        numHeat = 0;
        numGlass = 0;
        // CHEMICAL SPILL
        numSafety = 0;

        // Put all GameObjects in respective arrays
        objWalkway = GameObject.FindGameObjectsWithTag("InWalkway");
        foodAndDrink = GameObject.FindGameObjectsWithTag("Food&Drink");
        heatElements = GameObject.FindGameObjectsWithTag("HeatOn");
        brokenGlass = GameObject.FindGameObjectsWithTag("BrokenGlass");
        // CHEMICAL SPILL chemSpill = GameObject.FindGameObjectsWithTag("ChemSpill");
        safetyEqpt = GameObject.FindGameObjectsWithTag("Safety");

        // Randomize to turn certain ones active
        // Decides how many to activate - from 0 to the total number in scene
        numObj = Random.Range(0, 2);
        numFood = Random.Range(0, 4);
        numHeat = Random.Range(0, 3);
        numGlass = Random.Range(0, 2);
        // numSpill = Random.Range(0, ?);
        numSafety = Random.Range(0, 3);

        int numObjCopy = numObj;
        int numFoodCopy = numFood;
        int numHeatCopy = numHeat;
        int numGlassCopy = numGlass;
        //int numSpillCopy = numSpill;
        int numSafetyCopy = numSafety;

        // Reshuffle each GameObject[] so that the elements turned on will be random each time
        ReshuffleArray(objWalkway);
        foreach (GameObject obj in objWalkway)
        {
            Debug.Log(obj.ToString());
        }
        ReshuffleArray(foodAndDrink);
        ReshuffleArray(heatElements);
        ReshuffleArray(brokenGlass);
        //ReshuffleArray(chemSpill);
        ReshuffleArray(safetyEqpt);

        Debug.Log("Num obj: " + numObj);
        // Obj in Walkway
        for (int i = 0; i < objWalkway.Length; i++)
        {
            if (numObjCopy > 0)
            {
                objWalkway[i].gameObject.SetActive(true);
                numObjCopy--;
            }
            else
            {
                objWalkway[i].gameObject.SetActive(false);
            }
        }
        // Food & Drink
        for (int i = 0; i < foodAndDrink.Length; i++)
        {
            if (numFoodCopy > 0)
            {
                foodAndDrink[i].gameObject.SetActive(true);
                numFoodCopy--;
            }
            else
            {
                foodAndDrink[i].gameObject.SetActive(false);
            }
        }
        // Heat Elements
        for (int i = 0; i < heatElements.Length; i++)
        {
            if (numHeatCopy > 0)
            {
                heatElements[i].gameObject.SetActive(true);
                numHeatCopy--;
            }
            else
            {
                heatElements[i].gameObject.SetActive(false);
            }
        }
        // Broken Glass
        for (int i = 0; i < brokenGlass.Length; i++)
        {
            if (numGlassCopy > 0)
            {
                brokenGlass[i].gameObject.SetActive(true);
                numGlassCopy--;
            }
            else
            {
                brokenGlass[i].gameObject.SetActive(false);
            }
        }
    }

    void ReshuffleArray(GameObject[] goArray)
    {
        for (int i = 0; i < goArray.Length; i++)
        {
            GameObject temp = goArray[i];
            int index = Random.Range(i, goArray.Length);
            goArray[i] = goArray[index];
            goArray[index] = temp;
        }
    }

    public void GradeSimulation()
    {
        int correct = 0;
        int outOf = 5; // 6; - CHEMICAL SPILL
        bool objectActiveAndToggleOn = false; // GameObj active in the hierarchy and toggle is on (user marked violation correctly), +1 point
        bool objectInactiveAndToggleOff = false; // GameObj inactive in violation and toggle off (user did not mark violation because none occured), +1 point

        // If an object in the array is active AND the toggle has been clicked, say they passed
        // Object in Walkway Check
        foreach (var obj in objWalkway)
        {
            // If there is a food active in the hierarchy (violation) and toggle is on (user marked violation), turn the bool on and give a point
            if (obj.activeInHierarchy && objToggle.isOn)
            {
                objectActiveAndToggleOn = true;
            }
            // If no food is active in hierarchy and the toggle is off, give them a point
            else if (!obj.activeInHierarchy && !objToggle.isOn)
            {
                objectInactiveAndToggleOff = true;
            }
        }
        if (objectActiveAndToggleOn || objectInactiveAndToggleOff)
        {
            correct++;
            objectResultTMP.text = "Passed (" + numObj + " present)";
        }
        else
        {
            objectResultTMP.text = "Failed (" + numObj + " present)";
        }
        objectActiveAndToggleOn = false; // Reset each time
        objectInactiveAndToggleOff = false; // Reset each time
        
            // Food & Drink Check
            foreach (var food in foodAndDrink)
            {
                // If there is a food active in the hierarchy (violation) and toggle is on (user marked violation), turn the bool on and give a point
                if (food.activeInHierarchy && foodToggle.isOn)
                {
                    objectActiveAndToggleOn = true;
                }
                // If no food is active in hierarchy and the toggle is off, give them a point
                else if (!food.activeInHierarchy && !foodToggle.isOn)
                {
                    objectInactiveAndToggleOff = true;
                }
            }
            if (objectActiveAndToggleOn || objectInactiveAndToggleOff)
            {
                correct++;
                foodResultTMP.text = "Passed (" + numFood + " present)";
            }
            else
            {
                foodResultTMP.text = "Failed (" + numFood + " present)";
            }
            objectActiveAndToggleOn = false; // Reset each time
            objectInactiveAndToggleOff = false; // Reset each time

            // Heat Element Eqpt Check
            foreach (var heat in heatElements)
            {
                // If there is a food active in the hierarchy (violation) and toggle is on (user marked violation), turn the bool on and give a point
                if (heat.activeInHierarchy && heatToggle.isOn)
                {
                    objectActiveAndToggleOn = true;
                }
                // If no food is active in hierarchy and the toggle is off, give them a point
                else if (!heat.activeInHierarchy && !heatToggle.isOn)
                {
                    objectInactiveAndToggleOff = true;
                }
            }
            if (objectActiveAndToggleOn || objectInactiveAndToggleOff)
            {
                correct++;
                heatResultTMP.text = "Passed (" + numHeat + " present)";
            }
            else
            {
                heatResultTMP.text = "Failed (" + numHeat + " present)";
            }
            objectActiveAndToggleOn = false; // Reset each time
            objectInactiveAndToggleOff = false; // Reset each time

            // Broken Glass Check
            foreach (var glass in brokenGlass)
            {
                // If there is a food active in the hierarchy (violation) and toggle is on (user marked violation), turn the bool on and give a point
                if (glass.activeInHierarchy && glassToggle.isOn)
                {
                    objectActiveAndToggleOn = true;
                }
                // If no food is active in hierarchy and the toggle is off, give them a point
                else if (!glass.activeInHierarchy && !glassToggle.isOn)
                {
                    objectInactiveAndToggleOff = true;
                }
            }
            if (objectActiveAndToggleOn || objectInactiveAndToggleOff)
            {
                correct++;
            glassResultTMP.text = "Passed (" + numGlass + " present)";
            }
            else
            {
                glassResultTMP.text = "Failed (" + numGlass + " present)";
            }
            objectActiveAndToggleOn = false; // Reset each time
            objectInactiveAndToggleOff = false; // Reset each time

        /*
            // Chemical Spill Check
            foreach (var spill in chemSpill)
            {
                // If there is a food active in the hierarchy (violation) and toggle is on (user marked violation), turn the bool on and give a point
                if (spill.activeInHierarchy && spillToggle.isOn)
                {
                    objectActiveAndToggleOn = true;
                }
                // If no food is active in hierarchy and the toggle is off, give them a point
                else if (!spill.activeInHierarchy && !spillToggle.isOn)
                {
                    objectInactiveAndToggleOff = true;
                }
            }
            if (objectActiveAndToggleOn || objectInactiveAndToggleOff)
                {
                    correct++;
                    spillResultTMP.text = "Passed (" + numSpill + " present)";
                }
                else
                {
                    spillResultTMP.text = "Failed (" + numSpill + " present)";
                }
                objectActiveAndToggleOn = false; // Reset each time
                objectInactiveAndToggleOff = false; // Reset each time
        */
        // Safety Eqpt Check
        foreach (var eqpt in safetyEqpt)
        {
            // If there is a food active in the hierarchy (violation) and toggle is on (user marked violation), turn the bool on and give a point
            if (eqpt.activeInHierarchy && safetyToggle.isOn)
            {
                objectActiveAndToggleOn = true;
            }
            // If no food is active in hierarchy and the toggle is off, give them a point
            else if (!eqpt.activeInHierarchy && !safetyToggle.isOn)
            {
                objectInactiveAndToggleOff = true;
            }
        }
        if (objectActiveAndToggleOn || objectInactiveAndToggleOff)
        {
            correct++;
            eqptResultTMP.text = "Passed (" + numSafety + " present)";
        }
        else
        {
            eqptResultTMP.text = "Failed (" + numSafety + " present)";
        }
        objectActiveAndToggleOn = false; // Reset each time
        objectInactiveAndToggleOff = false; // Reset each time

        int finalScore = (correct / outOf) * 100; // Calculates the final score

        if (finalScore > 70)
        {
            sendToGSheet.SendScore(PartOfSim, finalScore);
            finalScoreTMP.text = "Pass";
            finalScoreTMP.color = Color.green;
            PlayerPrefs.DeleteAll();
            afterScoringExit.gameObject.SetActive(true);
        }
        else
        {
            finalScoreTMP.text = "Fail";
            finalScoreTMP.color = Color.red;
            afterScoringRestart.gameObject.SetActive(true);
        }

        // Show Screen when everything filled out
        SubmittedScreen.SetActive(true);
    }
}

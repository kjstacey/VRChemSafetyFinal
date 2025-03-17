using JetBrains.Annotations;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ValidateJagNumber : MonoBehaviour
{
    // First validate input, then send to Google Sheets

    // Validate input
    [SerializeField] TMP_InputField JagNumInput;
    [SerializeField] TMP_InputField FirstLastNameInput;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] Canvas EnterInfoCanvas;
    [SerializeField] GameObject keyboard;
    [SerializeField] GameObject invisibleWall;
    [SerializeField] GameObject doors;

    public static string FirstLastNameText;
    public static string JagNumText;

    public void Validate()
    {
        // First, validate the jagnumber
        //bool validated = false;
        string input = JagNumInput.text;
        int i = 0;

        // If a 6 digit input and is a numeric value, return valid
        if (input.Length != 6 || !int.TryParse(input, out i))
        {
            //Debug.Log("input: " + input + "\ninput.length = " + input.Length + "\n!int.TryParse = " + !int.TryParse(input, out i));
            resultText.text = "JagNumber is invalid. Please enter a 6 digit number.";
            resultText.color = Color.red;
        }
        else if (FirstLastNameInput.text.Length == 0 || !FirstLastNameInput.text.Contains(' '))
        {
            resultText.text = "Please enter your first and last name.";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "Thank you!";
            resultText.color = Color.green;

            Invoke("DisableCanvasAndKeyboard", 5.0f);

            //Push to form
            FirstLastNameText = FirstLastNameInput.text;
            JagNumText = "J00" + JagNumInput.text;

            Debug.Log("name: " + FirstLastNameText + "\njnum: " + JagNumText);

            Invoke("OpenDoors", 7.0f);
        }
    }

    void DisableCanvasAndKeyboard()
    {
        EnterInfoCanvas.GetComponent<Canvas>().enabled = false;

        if (keyboard.activeInHierarchy) keyboard.SetActive(false);

        invisibleWall.SetActive(false);
    }

    void OpenDoors()
    {
        doors.GetComponent<Animation>().Play("Open");
    }
}

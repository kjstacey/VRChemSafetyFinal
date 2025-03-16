using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputToSheets : MonoBehaviour
{
    // First validate input, then send to Google Sheets

    //public string StudentName;
    //public string StudentJagNumber;

    // Validate input
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI resultText;

    public void ValidateNameInput()
    {

    }

    public void ValidateJagNumInput()
    {
        string input = inputField.text;

        int i = 0;

        // If a 6 digit input and is a numeric value, return valid
        if (input.Length != 6 || !int.TryParse(input, out i))
        {
            resultText.text = "JagNumber is invalid. Please enter a 6 digit number.";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "Valid.";
            resultText.color = Color.green;
        }
    }
}

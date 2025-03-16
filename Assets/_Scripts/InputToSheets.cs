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

    public void ValidateInput()
    {
        string input = inputField.text;

        if (input.Length != 6 || input.GetType() != typeof(int))
        {
            resultText.text = "JagNumber is invalid. Please enter a 6 digit number.";
            resultText.color = Color.red;
        }
    }
}

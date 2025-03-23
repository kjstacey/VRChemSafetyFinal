using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;

public class SendToSheets : MonoBehaviour
{
    // For sending to Sheets
    private string formUrl = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSe33yhbwTLi7DxLiLV_gdh_5Asgrv-sxdCF_4AYO7y3mk5oEA/formResponse";
    //public GameObject GettingInput; // Game object that the info store script is attached to
    string StudentName;
    string StudentJNum;

    public void SendScore(string simulationPart, int finalScore)
    {
        StudentName = PlayerPrefs.GetString("StudentName");
        StudentJNum = PlayerPrefs.GetString("StudentJ#");

        //GettingInput = GameObject.Find("JagNumberTextInput");
        //StudentName = GettingInput.GetComponent<ValidateJagNumber>().FirstLastNameText;
        //StudentJNum = GettingInput.GetComponent<ValidateJagNumber>().JagNumText;

        StartCoroutine(SendToSheet(StudentName, StudentJNum, simulationPart, finalScore));
    }

    private IEnumerator SendToSheet(string name, string jnum, string simpart, int quizscore)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.158746761", name);
        form.AddField("entry.1534266805", jnum);
        form.AddField("entry.79633266", simpart);
        form.AddField("entry.1866273638", quizscore);
        using (UnityWebRequest www = UnityWebRequest.Post(formUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("Unsuccessful, error: " + www.error);
            }
        }
    }
}

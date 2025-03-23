using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject quizUI;
    public TMP_Text questionText;
    public TMP_Text[] answerTexts;
    public TMP_Text scoreText;
    public GameObject nextSceneButton;

    private string[] questions;
    private string[][] options;
    private string[] correctAnswers;
    private int currentQuestionIndex;
    private int score;

    [SerializeField] GameObject restartQuizScreen;
    [SerializeField] GameObject passedQuizScreen;
    [SerializeField] Text badScore;
    [SerializeField] Text goodScore;

    public SendToSheets SendToSheets;
    public string PartOfSim = "Introductory Video";

    void Start()
    {
        // Initialize questions, options, and correct answers here
        questions = new string[]
        {
            "Welcome to the quiz, You will be asked a set of questions. Select the best one",
            "In the case of a spill, you should:",
            "In the case of broken glassware, you should:",
            "Mark the answer that is true:",
            "Mark the answer that is most true:",
            "Mark the answer that is true:",
            "Mark the safety rule that was broken in the video",
            "Select the answers that are true for first aid rules:"
        };

        options = new string[][]
        {
            new string[]
            {
                "Start",
                "The",
                "Quiz",
                "!"
            },
            new string[]
            {
                "Notify your teacher and have them clean it up",
                "Do nothing and continue working",
                "Clean up the spill and continue working",
                "Clean up the spill and notify your teacher"
            },
            new string[]
            {
                "Alert your teacher and have them clean it up",
                "Grab a towel and clean it up yourself disposing of it in the trash can",
                "Grab a broom and clean it up yourself, disposing of it in a special container",
                "Clean it up yourself, and then alert your teacher."
            },
            new string[]
            {
                "When mixing a base and an acid. Pour the acid into the base.",
                "When mixing acid and water. Pour water into the acid",
                "When mixing a base and an acid. Pour the base into the acid.",
                "When mixing acid and water. Pour acid into the water"
            },
            new string[]
            {
                "You should keep electrical equipment unplugged until right before it needs to be used. When done with it, unplug it again.",
                "When unplugging electrical equipment, pull the plug not the cord",
                "If possible, electric equipment should be plugged into one extension cord, in order to keep all the plugs together",
                "If a piece of electrical equipment catches on fire, use water to put out the fire."
            },
            new string[]
            {
                "It is safe to heat wet glassware",
                "To adjust the flame coming from a burner, adjust the source gas valve.",
                "When heating glassware, place it on a wire gauze platform on a ring stand.",
                "When heating glassware using a burner, place the glassware directly on the flame to heat it up thoroughly and evenly"
            },
            new string[]
            {
                "Protective Clothing (Lab Coat) not worn at all times",
                "Hair not tied up",
                "Flushing one's eyes",
                "Locating first aid kit"
            },
            new string[]
            {
                "Flush eyes with water in case of exposure",
                "Flush burns with water of any temperature",
                "If someones faints, walk away",
                "Apply pressure to cuts even without gloves on."
            }
        };

        correctAnswers = new string[]
        {
            "Start",
            "Clean up the spill and notify your teacher",
            "Alert your teacher and have them clean it up",
            "When mixing acid and water. Pour water into the acid",
            "When unplugging electrical equipment, pull the plug not the cord",
            "When heating glassware, place it on a wire gauze platform on a ring stand.",
            "Hair not tied up",
            "Flush eyes with water in case of exposure",
        };

        // Hide quiz UI initially
        quizUI.SetActive(false);
        currentQuestionIndex = 0;
        score = 0;

        ShowNextQuestion();
    }

    public void AnswerSelected(int answerIndex)
    {
        string chosenAnswer = options[currentQuestionIndex][answerIndex];
        Debug.Log("Chosen answer:" + chosenAnswer);
        if (chosenAnswer == correctAnswers[currentQuestionIndex])
        {
            Debug.Log("Correct answer: " + correctAnswers[currentQuestionIndex]);
            score++;
            Debug.Log("Correct! Score + 1. Current score: " + score);
        }

        currentQuestionIndex++;
        Debug.Log("Current question index:" + currentQuestionIndex);
        if (currentQuestionIndex < questions.Length)
        {
            ShowNextQuestion();
        }
        else
        {
            if (score > 5)
            {
                quizUI.SetActive(false);
                passedQuizScreen.SetActive(true);
                // Show score and next scene button
                goodScore.text = "Score: " + score.ToString();
                goodScore.color = Color.green;
                //nextSceneButton.SetActive(true);

                SendToSheets.SendScore(PartOfSim, score);
            }
            else
            {
                quizUI.SetActive(false);
                restartQuizScreen.SetActive(true);
                badScore.text = "Score: " + score.ToString();
                badScore.color = Color.red;
            }
        }
    }

    void ShowNextQuestion()
    {
        questionText.text = questions[currentQuestionIndex];

        // Set answer options for current question
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = options[currentQuestionIndex][i];
        }
    }

    public void Restart()
    {
        restartQuizScreen.SetActive(false);
        quizUI.SetActive(true);
        currentQuestionIndex = 0;
        score = 0;
        ShowNextQuestion();
    }
}


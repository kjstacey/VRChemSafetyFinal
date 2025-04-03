using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SocketVideo : MonoBehaviour
{
    public GameObject objectDetect; // The VHS tape object
    public VideoPlayer videoPlayer1; // The VideoPlayer component for the first screen
    public Renderer tvScreen1; // The Renderer component on the first TV screen object
    public VideoPlayer videoPlayer2; // The VideoPlayer component for the second screen
    public Renderer tvScreen2; // The Renderer component on the second TV screen object
    public GameObject quizUI; // Reference to the quiz UI GameObject
    //public GameObject nextSceneButton; // Reference to the button for the next scene
    //public GameObject scoreText; // Reference to the score text GameObject

    private bool videoPlaying = false;
    private bool quizCompleted = false;

    [SerializeField] Button replayButton;
    [SerializeField] GameObject BigScreen;
    [SerializeField] Light light1;
    [SerializeField] Light light2;

    private void Start()
    {
        // Set Active = false;
        replayButton.gameObject.SetActive(false);

        // Set the VideoPlayer's output to the TV screens
        //videoPlayer1.targetMaterialRenderer = tvScreen1;
        videoPlayer2.targetMaterialRenderer = tvScreen2;

        // Hide the quiz UI, next scene button, and score text initially
        quizUI.SetActive(false);
        //nextSceneButton.SetActive(false);
        //scoreText.SetActive(false);

        // Subscribe to the video playback completed event
        //videoPlayer1.loopPointReached += OnVideoPlaybackComplete;
        videoPlayer2.loopPointReached += OnVideoPlaybackComplete;

        
    }

    // SelectEntered socket on vhs player?
    //private void OnTriggerEnter(Collider other)
    public void PlayVideo()
    {

        BigScreen.SetActive(true);
        light1.intensity = 0.5f;
        light2.intensity = 0.3f;
                
        // Play the video on the TV screens
        //videoPlayer1.Play();
        videoPlayer2.Play();
        videoPlaying = true;
    }

    private void OnVideoPlaybackComplete(VideoPlayer vp)
    {
        StartCoroutine(Wait());
        light1.intensity = 1.07f;
        light2.intensity = 1.70f;

        replayButton.gameObject.SetActive(true);
        // Show the quiz UI when the video playback is complete
        StartCoroutine(Wait());
        quizUI.SetActive(true);
    }

    // Method to call when the quiz is completed
    public void QuizCompleted()
    {
        // Hide the quiz UI
        quizUI.SetActive(false);

        // Show the next scene button and score text
        
        //scoreText.SetActive(true);
        //nextSceneButton.SetActive(true);
        
        // Set quizCompleted flag to true
        quizCompleted = true;
    }

    // Method to call when the next scene button is clicked
    public void LoadNextScene()
    {

        SceneManager.LoadScene(1);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
    }
}

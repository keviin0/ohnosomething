using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class VideoSceneTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float transitionDelay = 5f;
    private bool hasStartedTransition = false;


    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        StartCoroutine(TransitionAfterDelay());
    }

    IEnumerator TransitionAfterDelay()
    {
        yield return new WaitForSeconds(transitionDelay);

        if (!hasStartedTransition)
        {
            hasStartedTransition = true;
            SceneManager.LoadScene("3DScene");
        }
    }
}

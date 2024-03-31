using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool flagsFound = false;
    public bool balloonsFound = false;
    public bool ballsFound = false;

    public bool allFound = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (SceneManager.GetActiveScene().name == "3DScene")
        {
            if (flagsFound)
            {
                GameObject.Find("Flags").SetActive(false);
            }
            
            if (balloonsFound)
            {
                GameObject.Find("Lungs").SetActive(false);
            }

            if (ballsFound)
            {
                GameObject.Find("Balls").SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flagsFound && balloonsFound && ballsFound)
        {
            allFound = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedAudioSource : MonoBehaviour
{

    public string file1;

    private vector<string> mFilenames;

    private vector<int> mOrder;
    private int mLastInt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //
    int GetRandomNonRepeatingInt()
    {
        int retVal = Random.Range(0, mFilenames.Length);
        while (retVal == mLastInt)
        {
            retVal = Random.Range(0, mFilenames.Length);
        }
        mLastInt = retVal;
        return retVal;
    }
}

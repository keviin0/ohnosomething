using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AudioModule;

public class RandomizedAudioSource : MonoBehaviour
{

    public List<AudioClip> audioClips;

    private int mLastInt = 300;//arbitrary high value

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayRandomClip()
    {
        AudioManager.instance.PlaySound(audioClips[mLastInt]);
    }

    //
    private int GetRandomNonRepeatingInt()
    {
        int retVal = Random.Range(0, audioClips.Count);
        while (retVal == mLastInt)
        {
            retVal = Random.Range(0, audioClips.Count);
        }
        mLastInt = retVal;
        return retVal;
    }
}

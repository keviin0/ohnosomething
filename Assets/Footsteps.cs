using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource[] footstepAudioSources; // Array to hold AudioSource components
    public CharacterController characterController;
    public float minWalkSpeed = 0.1f;
    public float footstepDelay = 0.1f; // Adjust this value for the desired delay

    public AudioClip[] footstepClips; // Array to hold footstep sound clips
    private float nextFootstepTime;
    public FPSController fpsController;

    void Start()
    {
        // Initialize the array of AudioSources
        footstepAudioSources = GetComponents<AudioSource>();
        // Check if there are any AudioSource components
        if (footstepAudioSources.Length > 0)
        {
            // Iterate through each AudioSource component
            for (int i = 0; i < footstepAudioSources.Length; i++)
            {
                // Access and do something with each AudioSource component
                AudioSource audioSource = footstepAudioSources[i];
            }
        }
        else
        {
            Debug.LogWarning("No AudioSource components found on this GameObject.");
        }

        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }

        if (fpsController == null)
        {
            // Assign the FPSController script reference
            fpsController = GetComponent<FPSController>();
        }

        nextFootstepTime = footstepDelay;

    }



    void Update()
    {
        // Check if the player is walking based on the CharacterController's velocity
        bool isWalking = characterController.velocity.magnitude > minWalkSpeed;
        bool isGrounded = characterController.isGrounded;

        if (fpsController.isRunning)
        {
            footstepDelay = 0.3f;
        }
        else
        {
            footstepDelay = 0.4f;
        }

        // Check if it's time to play the next footstep sound
        if (isWalking && Time.time >= nextFootstepTime && isGrounded)
        {
            // Randomly select a footstep sound clip from the array
            AudioClip randomClip = footstepClips[Random.Range(0, footstepClips.Length)];

            // Get an available AudioSource from the array
            AudioSource availableSource = GetAvailableAudioSource();

            // Play the selected footstep sound clip using the available AudioSource
            if (availableSource != null)
            {
                Debug.Log("Playing" + randomClip.name);
                availableSource.clip = randomClip;
                availableSource.Play();
            }

            nextFootstepTime = Time.time + footstepDelay; // Schedule the next footstep sound
            Debug.Log(nextFootstepTime);
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        int num = footstepAudioSources.Length;
        foreach (AudioSource source in footstepAudioSources)
        {
            Debug.Log(source.name);
            if (!source.isPlaying)
            {
                return source; // Return the first available AudioSource
            }
        }
        return null; // No available AudioSource found
    }
}

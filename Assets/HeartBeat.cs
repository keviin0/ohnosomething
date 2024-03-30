using System.Collections;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public Sprite heart1;
    public Sprite heart2;
    public float beatInterval = 1f;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(HeartbeatRoutine());
    }

    IEnumerator HeartbeatRoutine()
    {
        // Assuming heart1 is the starting sprite
        bool isHeart1 = true;

        // Infinite loop to keep the heartbeat going
        while (true)
        {
            // Switch between heart1 and heart2
            if (isHeart1)
            {
                spriteRenderer.sprite = heart2;
            }
            else
            {
                spriteRenderer.sprite = heart1;
            }
            isHeart1 = !isHeart1; // Toggle the state

            // Wait for beatInterval seconds before continuing the loop
            yield return new WaitForSeconds(beatInterval);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastInteract : MonoBehaviour
{
    public float interactionDistance = 10f;
    public Camera playerCamera;
    private InventoryManager inventoryManager;
    private LevelManager levelManager;
    private AudioManager audioManager;
    public AudioClip pickupSound;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log(hit.collider.name);
                    audioManager.PlaySound(pickupSound);
                    switch (hit.collider.name)
                    {
                        case "Knife":
                            break;
                        case "Lungs":
                            inventoryManager.AddBalloon();
                            levelManager.balloonsFound = true;
                            break;
                        case "Flags":
                            inventoryManager.AddFlags();
                            levelManager.flagsFound = true;
                            break;
                        case "Balls":
                            inventoryManager.AddBalls();
                            levelManager.ballsFound = true;
                            break;
                        case "Clown":
                            SceneManager.LoadScene("2DScene");
                            break;
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * interactionDistance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastInteract : MonoBehaviour
{
    public float interactionDistance = 10f; 
    public Camera playerCamera;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
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
                    switch(hit.collider.name)
                    {
                        case "Knife":
                            break;
                        case "Lungs":
                            inventoryManager.AddBalloon();
                            GameObject.Find("Lungs").SetActive(false);
                            break;
                        case "Flags":
                            inventoryManager.AddFlags();
                            GameObject.Find("Flags").SetActive(false);
                            break;
                        case "Balls":
                            inventoryManager.AddBalls();
                            GameObject.Find("Balls").SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LockCameraOnTrigger : MonoBehaviour
{
    public Camera cam;  // Reference to the Camera you want to lock
    public Transform lockPosition;  // Position where the camera should be locked
    public bool isCameraLocked = false;  // Flag to check if camera is locked

  public PlayerController playerController;  // Reference to the PlayerController script

    void Start()
    {
        // If the camera isn't assigned, find the main camera
        if (cam == null)
        {
            cam = Camera.main;
        }

        // Find the PlayerController component on the player
        playerController = cam.GetComponentInParent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogWarning("PlayerController script is not attached to the player!");
        }
    }

    // Trigger event when something enters the collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered has a specific tag or condition
        if (other.gameObject.tag == ("Player"))  // Assuming the player has the tag "Player"
        {
            LockCamera();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that entered has a specific tag or condition
        if (other.gameObject.tag == ("Player"))  // Assuming the player has the tag "Player"
        {
            UnlockCamera();
        }
    }

    // Lock the camera by setting its position and rotation or preventing movement
    void LockCamera()
    {
        // Lock the camera's position and rotation to the lockPosition
        if (lockPosition != null)
        {
            cam.transform.position = lockPosition.position;
            cam.transform.rotation = lockPosition.rotation;
        }

        // Disable player control (this will stop both player movement and camera movement)
        if (playerController != null)
        {
            playerController.LockPlayerControl();  // Lock both player movement and camera control
        }

        // Set the camera locked state
        isCameraLocked = true;
    }

    // Unlock the camera (could be triggered elsewhere, such as OnTriggerExit or by a button press)
    public void UnlockCamera()
    {
        if (playerController != null)
        {
            playerController.UnlockPlayerControl();  // Unlock player movement and camera control
        }

        isCameraLocked = false;
    }
}

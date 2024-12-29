/**
 * PlayerController.cs
 * 
 * This script is designed for controlling player movement and rotation using the Oculus Touch Controllers
 * in a Unity environment. The right thumbstick controls the player's forward, backward, left and right movements,
 * while the left thumbstick controls the player’s rotation.
 * 
 * Usage:
 * Attach this script to the player object or the object intended to be controlled by the user.
 * Adjust the `speed` and `rotationSpeed` public fields as necessary to suit your game's needs.
 * 
 * Author: Pi Ko (pk2269@nyu.edu)
 * Date: 24th September 2023
 */

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f; // Speed at which the player moves
    public float rotationSpeed = 55.0f; // Speed at which the player rotates

    private void Update()
    {
        // Action Buttons on Right Controller
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            // Insert the action to be performed when the button is pressed
        }


        //-----------------------------------
        // Player Movement Code Begins
        //-----------------------------------

        // Gather input from the right thumbstick for movement
        Vector2 movementThumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick); // Right-hand controller
        float moveHorizontal = movementThumbstick.x;
        float moveVertical = movementThumbstick.y;

        // Gather input from the left thumbstick for rotation
        Vector2 rotationThumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick); // Left-hand controller
        float rotateHorizontal = rotationThumbstick.x;

        // Move the player forward, backward, left, or right
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Rotate the player left or right based on the horizontal input from the left thumbstick
        float rotation = rotateHorizontal * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        //-----------------------------------
        // Player Movement Code Ends
        //-----------------------------------
    }
}

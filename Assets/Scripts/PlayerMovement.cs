using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float distance = 1f;
    public float actionCooldown = 0.5f;

    private bool canMoveForward = true;
    private float lastActionTime = 0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            canMoveForward = false;
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            canMoveForward = true;
        }
    }

    void Update()
    {
        // If the cooldown has passed, allow the player to move
        if (Time.time - lastActionTime > actionCooldown)
        {
            // If the player presses the W key and the front collider is not touching anything, move forward
            if (Input.GetKey(KeyCode.W))
            {
                // Make raycast to check if there is a wall in front of the player
                RaycastHit hit;
                canMoveForward = true;
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
                {
                    if (hit.collider.gameObject.tag.Contains("Wall"))
                    {
                        canMoveForward = false;
                    }
                }

                if (canMoveForward)
                {
                    transform.Translate(Vector3.forward * distance);
                    lastActionTime = Time.time;
                }
            }

            // If the player presses the A key, rotate 90 degrees to the left
            if (Input.GetKey(KeyCode.A) && Time.time - lastActionTime > actionCooldown)
            {
                transform.Rotate(Vector3.up, -90f);
                lastActionTime = Time.time;
            }

            // If the player presses the D key, rotate 90 degrees to the right
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, 90f);
                lastActionTime = Time.time;
            }
        }
    }
}
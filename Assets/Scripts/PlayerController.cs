using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent player;
    public float inputDelay = 0.5f;
    private float lastInput = 0;
    
    private float normalize(float value)
    {
        return value / Mathf.Abs(value);
    }
    
    private bool wallInWay(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 5))
        {
            if (hit.collider.tag == "Wall")
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if (lastInput + inputDelay > Time.timeSinceLevelLoad)
        {
            return;
        }
        
        // Move player forward or backward
        if (Input.GetAxis("Vertical") != 0)
        {
            float normalized = normalize(Input.GetAxis("Vertical"));

            // Check if a wall is the way of the player before moving
            if (wallInWay(transform.forward * normalized))
            {
                return;
            }

            if (normalized < 0)
            {
                transform.Rotate(0, 180, 0);
            }
            transform.position += transform.forward * 5;

            lastInput = Time.timeSinceLevelLoad;
        }
        
        // Move player left or right
        if (Input.GetAxis("Horizontal") != 0)
        {
            float normalized = normalize(Input.GetAxis("Horizontal"));

            if (wallInWay(transform.right * normalized))
            {
                return;
            }
            transform.Rotate(0, 90 * normalized, 0);
            transform.position += transform.forward * 5;
            
            lastInput = Time.timeSinceLevelLoad;
        }
        
        player.SetDestination(transform.position);
    }
}

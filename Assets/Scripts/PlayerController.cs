using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent player;
    public float inputDelay = 0.5f;
    private float lastInput = 0;

    void Update()
    {
        if (lastInput + inputDelay > Time.timeSinceLevelLoad)
        {
            return;
        }
        
        // Move player forward
        if (Input.GetAxis("Vertical") > 0)
        {
            // Check if a wall is in front of the player before moving
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                if (hit.collider.tag == "Wall")
                {
                    return;
                }
            }

            transform.position += transform.forward * 5;
            lastInput = Time.timeSinceLevelLoad;
        }
        
        // Turn player left or right
        if (Input.GetAxis("Horizontal") != 0)
        {
            float normalized = Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal"));

            transform.Rotate(0, 90 * normalized, 0);
            lastInput = Time.timeSinceLevelLoad;
        }
        
        player.SetDestination(transform.position);
    }
}

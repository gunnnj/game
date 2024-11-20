using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    public float speedReduction = 5f; 
    public PlayerMovement playerMovement; 
    private float originalSpeed;
    void Awake()
    {
        originalSpeed = playerMovement.moveSpeed;
    }
    private void OnTriggerStay2D(Collider2D other)
    {     
        if (other.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null && playerMovement.moveSpeed > speedReduction)
            {
                playerMovement.moveSpeed -= speedReduction * Time.deltaTime; 
 
                if (playerMovement.moveSpeed < 5f)
                {
                    playerMovement.moveSpeed = 5f; 
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (playerMovement != null)
            {
                playerMovement.moveSpeed += speedReduction; 
                
                if (playerMovement.moveSpeed > originalSpeed)
                {
                    playerMovement.moveSpeed = originalSpeed;
                }
            }
        }
    }
}

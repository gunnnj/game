using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGame : MonoBehaviour
{
    private PlayerMovement rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<PlayerMovement>();
            if (rb != null)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float HP = 20f;
    private Bullet bullet;
    private Blade blade;
    void Update()
    {
        if(HP<=0){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        { // chạm vào Tag("bullet")
            bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                HP-= 10;
            }
        }
        if (other.gameObject.CompareTag("blade"))
        { // chạm vào Tag("blade")
            Debug.Log("kiem");
            blade = other.gameObject.GetComponent<Blade>();
            if (blade != null)
            {
                HP-=15;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("blade"))
        { // chạm vào Tag("blade")
            Debug.Log("kiem");
            blade = other.gameObject.GetComponent<Blade>();
            if (blade != null)
            {
                HP-=15;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiden : MonoBehaviour
{
    public float HP = 20f;
    private Bullet bullet;
    private Blade blade;
    public bool isHiden = false;
    void Update()
    {
             
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
            blade = other.gameObject.GetComponent<Blade>();
            if (blade != null)
            {
                HP-=15;
            }
        }
    }
}

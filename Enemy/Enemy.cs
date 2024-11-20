using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 3f; // Tốc độ di chuyển của kẻ thù
    [SerializeField]
    public float rangeAttack = 1f; // Khoảng cách tấn công
    [SerializeField]
    public float damage = 10f; // Sát thương tấn công
    public float hpEnemy;
    [SerializeField]
    public float maxHpEnemy = 100f;
    [SerializeField]
    public float rangeFindMove = 10f;
    [SerializeField]
    public float armor=0f;
    [SerializeField]
    public Transform target;
    [SerializeField]
    private GameObject itemSpawn;
    public ControllerHealthPlayer player;
    public Bullet bullet;
    public Blade blade;
    public float dameBullet = 10f;
    public float dameBlade = 20f;
    private bool isSpawn = true;

    private void Awake()
    {
        hpEnemy = maxHpEnemy;
    }
    private void Start()
    {
        
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void MoveTowardsTarget() // Di chuyển theo Player
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if(distance <= rangeFindMove) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        { // chạm vào Tag("bullet")
            bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                hpEnemy -= (dameBullet-armor);
            }
        }
        if (collision.gameObject.CompareTag("blade"))
        { // chạm vào Tag("blade")
            blade = collision.gameObject.GetComponent<Blade>();
            if (blade != null)
            {
                hpEnemy -= (dameBlade-armor);
            }
        }
    }

    public void Spawn(){
        if(hpEnemy<=0 && isSpawn){
            Instantiate(itemSpawn, transform.position, Quaternion.identity);
            isSpawn = false;
        }
    }
   
    
    
}

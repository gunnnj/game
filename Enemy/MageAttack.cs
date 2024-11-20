using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : Enemy
{
    [SerializeField]
    private GameObject iceSpawn;
    [SerializeField]
    private Transform point;
    [SerializeField]
    private float speedFire = 20f;
    private bool canFire;
    private float timeSkill = 2f;
    private Animator animator;
    public AudioSource SoundFire;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tính khoảng cách giữa kẻ thù và người chơi
        float distance = Vector3.Distance(transform.position, target.position);
        // Hướng về phía người chơi
        Vector2 direction = (transform.position - target.position).normalized;
        // Nếu khoảng cách nhỏ hơn safeDistance, lùi lại
        
        if(distance<= rangeAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (distance < rangeFindMove)
            {
                transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
                if (distance <= 5f)
                {
                    transform.position += (Vector3)direction * (moveSpeed*2.5f) * Time.deltaTime;
                }

            }
            // Quay mặt kẻ thù về phía người chơi
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            if (canFire)
            {
                FireIce();
                StartCoroutine(countSkill());
            }
        }
        IsDead();
        Spawn();
    }
    public void FireIce()
    {
        // Tính toán hướng tới người chơi
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Tạo một projectile từ prefab từ điểm bắn
        GameObject projectile = Instantiate(iceSpawn, point.position, Quaternion.identity);
        SoundFire.Play();

        // Thêm tốc độ cho projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction * speedFire;
            rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        }
        Destroy(projectile, 2f);
    }
    IEnumerator countSkill()
    {
        canFire = false;
        yield return new WaitForSeconds(timeSkill);
        canFire = true;

    }
    public void IsDead()
    {
        if (hpEnemy <= 0)
        {
            animator.SetBool("IsDead", true);
            StartCoroutine(wait());
           
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attacking : MonoBehaviour
{
    public Transform firePoint; //điểm bắn
    public Transform shellSpawn; //điểm rơi
    public Image stabCooldownImage;
    private bool canStab;

    private Rigidbody2D rb;
    public UICountControl countControl;//đếm đạn
    private Animator animator; 
    private float attackDuration = 0.5f; //Thời gian Attack
    public AudioSource shootSound;
    public AudioSource slash;
    // private float shellEjectForce = 5f; //tốc độ rơi vỏ 
    // private float bulletForce = 20f; //tốc độ bắn
    // public GameObject shellPrefab; //vỏ đạn
    // public GameObject cloneGO; //phân thân
    // public Transform clone;  //điểm phân thân
    // public GameObject bulletPrefab; //đạn
    // public Transform bladePoint;
    void Start()
    {
        // Lấy component Animator từ GameObject
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(Countdown());  // Hồi chiêu lần đầu
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(animator.GetBool("IsChange") == true)
            {
                Shoot();
            }
            else
            {
                if (countControl.countBullet > 0)
                {
                    Shoot();
                }
                
            }
           

        }
        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     GameObject Clone = Instantiate(cloneGO, transform.position, Quaternion.identity); // tạo clone
        //     clone.position = Vector3.Lerp(transform.position, clone.position, 4f);  // dịch chuyển clone
            
        //     Destroy(Clone, 5f); // xóa clone
        // }
        if (Input.GetButtonDown("Fire2") && animator.GetBool("IsChange"))
        {

            if (canStab)
            {
                Stab(); // Đâm kiếm
                StartCoroutine(Countdown()); // Đếm cooldown đâm
            }
            
                     
        }
        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Shoot()
    {
        // không chuyển vũ khí (súng)
        if (animator.GetBool("IsChange")==false)
        {
            ObjPooling.instance.SpawnBullet(firePoint.position, firePoint.rotation,firePoint.up);
            countControl.countBullet--;
            shootSound.Play();
            ObjPooling.instance.SpawShell(shellSpawn.position, shellSpawn.rotation);
            // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            // rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            
            // GameObject shell = Instantiate(shellPrefab, shellSpawn.position, shellSpawn.rotation);
            // // Lấy Rigidbody2D của vỏ đạn và thiết lập lực rơi
            // Rigidbody2D shellRb = shell.GetComponent<Rigidbody2D>();
            // shellRb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)) * shellEjectForce, ForceMode2D.Impulse);
            //Destroy(shell, 2f);
            // Destroy(bullet, 0.5f);
        }
        else  // chuyển vũ khí ( kiếm )
        {
            
            animator.SetBool("AttackBlade", true);
            slash.Play();

            Invoke("ResetAttack", attackDuration);
        }
        
    }
    void Stab()  // đâm kiếm
    {
        float stabDuration = 0.5f;
        if (animator.GetBool("IsChange") == true)
        {
            animator.SetBool("IsStab", true);
            Invoke("ResetAttack", stabDuration);
        }
    }
    void ResetAttack()  // reset animation
    {
        animator.SetBool("IsStab", false);
        animator.SetBool("AttackBlade", false);
    }

    IEnumerator Countdown()  // Hàm đếm
    {
        canStab = false;
        float countdownTime = 10f; // 10 giây

        while (countdownTime > 0)
        {

            countdownTime -= 0.1f; // Giảm 1 giây
            stabCooldownImage.fillAmount = countdownTime / 10f;
            yield return new WaitForSeconds(0.1f); // Chờ 1 giây
        }
        canStab = true;

    }
    
}

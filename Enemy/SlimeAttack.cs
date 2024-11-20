using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : Enemy
{
    private Animator animator;

    private bool canAttack;
    private void Start()
    {
        animator = GetComponent<Animator>();
        canAttack = true;
        
    }

    private void Update()
    {
        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance <= rangeAttack && canAttack)
            {
                Attack();
                StartCoroutine(Countdown());// Hồi chiêu dánh thường
            }
            else
            {
                MoveTowardsTarget();
            }
        }
        IsDead();
        Spawn();
      
    }



    private void Attack()
    {
        animator.SetTrigger("IsAttackSlime");
       
        Invoke("resetAnimation", 2f); // Thiết lập thời gian cho animation
    }
   
   
    private void OnCollisionEnter2D(Collision2D collision) // xử lý va chạm tấn công player
    {
        if(collision.gameObject.CompareTag("Player")&& animator.GetBool("IsAttackSlime").Equals(true))
        {
            player = collision.gameObject.GetComponent<ControllerHealthPlayer>();
            if (player != null)
            {
                player.AttackDame(damage);
            }
        }
        
    }

  
    private void resetAnimation()
    {
        animator.SetBool("IsAttackSlime", false);
    }
    IEnumerator Countdown()  // Hàm đếm
    {
        canAttack = false;
        float countdownTime = 5f;

        while (countdownTime > 0)
        {
           
            countdownTime -= 1f; // Giảm 1 giây

            yield return new WaitForSeconds(1f); // Chờ 1 giây
        }
        canAttack = true;
    }
    public void IsDead()
    {
        if (hpEnemy <= 0)
        {
            Destroy(gameObject);         
        }
    }

}
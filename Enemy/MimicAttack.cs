using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicAttack : Enemy
{
    private Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if(distance<=rangeAttack){
            animator.SetTrigger("IsAttack");
        }
        if(hpEnemy<=0){
            animator.SetTrigger("IsDead");
            StartCoroutine(wait());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<ControllerHealthPlayer>();
        if(collision.gameObject.CompareTag("Player") && player!=null)
        {       
            player.AttackDame(damage);                  
        }
        
    }
    public IEnumerator wait(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

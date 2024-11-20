using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrabAttack : Enemy
{
    [SerializeField]
    private float rangeSkill = 15f;
    private bool canAttack = true;
    private bool canJump = true;
    private bool attacking = false;
    private bool jumping = false;
    private Animator animator;
    private float dameJump = 25f;
    private bool isChecked = true;
    public ControllerHealthPlayer play;
    private Coroutine coroutine;
    public GameObject End;
    public AudioSource SAttack;
    public AudioSource SDD;
    public AudioSource SSword;
    void Start()
    {
        animator = GetComponent<Animator>();
        End.SetActive(false);
        
    }

    void Update()
    {

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= rangeSkill && !attacking && !jumping)
        {
            JumpToTarget();
        }
        if (!attacking && !jumping)
        {
            if(distance>3f){
                MoveTowardsTarget();
            }
        }
        if (distance <= rangeAttack && !jumping)
        {
            Attack();
        }
        if(isChecked){
            checkDame();
        }
        IsDied();

    }
    private void checkDame(){
        if(play==null){
            return;
        }
        if(play.IsPiercing()){
            dameBullet = 20f;
            dameBlade = 30f;
            isChecked = false;
        }
        else{
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // xử lý va chạm tấn công player
    {
        player = collision.gameObject.GetComponent<ControllerHealthPlayer>();
        if(collision.gameObject.CompareTag("Player") && player!=null)
        {
            if (animator.GetBool("canJump2").Equals(true))
            {
                player.AttackDame(dameJump);
                SDD.Play();
            }
            else if(animator.GetBool("canAttack").Equals(true)){
                player.AttackDame(damage);
                SSword.Play();
            }
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
                SAttack.Play();
            }
        }
    }
    public void Attack()
    {
        if(!canAttack) return;
        else{
           StartCoroutine(TimeAttack());
        }
        
    }

    private void JumpToTarget()
    {
        if (!canJump || jumping) return;
        StartCoroutine(Countdown());
        
    }
    IEnumerator TimeAttack(){
        float countdownTime = 6f; 
        while (countdownTime > 0)
        {  
            countdownTime -= 1f;  
            yield return new WaitForSeconds(1f);
            if(countdownTime==5f){             
                canAttack = false;
                attacking = true;
                Vector2 direction = (transform.position - target.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
                animator.SetBool("canAttack", true);
            }
            if(countdownTime==4f){
                animator.SetBool("canAttack", false);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0,0));
                attacking=false;
            }
            if(countdownTime==1f){
                canAttack = true;
            }
        }
    }
    IEnumerator Countdown()  // Hàm đếm
    {
        Vector2 targetPosS = new Vector2(0,0);
        float countdownTime = 41f;     
        canJump = false;
        jumping = true;  
        

        while (countdownTime > 0)
        {  
            countdownTime -= 1f;               
            yield return new WaitForSeconds(1f);
            if(countdownTime==40f){
                animator.SetBool("canJump",true);
            }
            if(countdownTime == 39f){          
                Vector2 endStart = new Vector2(transform.position.x, transform.position.y + 10f);         
                transform.position = Vector2.Lerp(transform.position, endStart, 1f); 
                yield return new WaitForSeconds(.5f);
                targetPosS = new Vector2(target.position.x, target.position.y+10f);
                transform.position = targetPosS; 
                yield return new WaitForSeconds(.5f);
                transform.position = Vector2.Lerp(transform.position, new Vector2(targetPosS.x, targetPosS.y-10f), 2f);              
                animator.SetBool("canJump2",true);
            }    
            if(countdownTime==35f){
                animator.SetBool("canJump",false);
                animator.SetBool("canJump2",false);
                jumping = false;
                
            }
            if(countdownTime == 1f){
                canJump = true;               
            }
        }

    }
    public void IsDied(){
        if(hpEnemy<=0){
            Destroy(gameObject);
            if(coroutine==null){
                coroutine = StartCoroutine(backMenu());
            }
        }
    }
    IEnumerator backMenu(){
        End.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(0);
    }
   
}

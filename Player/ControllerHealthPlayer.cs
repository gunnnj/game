using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerHealthPlayer : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float health = 1f;
    public float dameStone = 20f;
    public float dameIce = 20f;
    private Stone stone;
    private Ice ice;
    private ObjGame item;
    private float hpHealing = 20f;
    private bool Piercing = false;
    public UIControlHeal coutControl;
    [SerializeField]
    private Image piercingImg;
    public UICountControl bulletCount;
    private Coroutine coroutine;
    public PlayerMovement player;

    public AudioSource collect;
    public AudioSource heal;

    public AudioSource hit;

    public Image imgDied;
    public Image bg;
    void Awake()
    {
        health = maxHealth;
        
    }
    void Start()
    {
        
        piercingImg.enabled = false;
        imgDied.enabled = false;
        bg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health/maxHealth;
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (Input.GetKeyDown(KeyCode.E) && coutControl.countHeal>0 && health<maxHealth)
        {
            health += hpHealing;
            coutControl.countHeal--;
            heal.Play();
            
        }
        IsDied();
    }
    public bool IsPiercing(){
        return Piercing;
    }
    public void AttackDame(float dame)
    {
        health -=dame;
        hit.Play();
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            stone = collision.gameObject.GetComponent<Stone>();
            if (stone != null)
            {
                health -= dameStone;
            }

        }
        if (collision.gameObject.CompareTag("HealBox")) 
        {
            item = collision.gameObject.GetComponent<ObjGame>();
            if (item != null)
            {
                coutControl.countHeal++;
                collect.Play();
            }
        }
        if (collision.gameObject.CompareTag("Ice"))
        {
            ice = collision.gameObject.GetComponent<Ice>();
            if (ice != null)
            {
                health -= dameIce;
                hit.Play();
            }

        }
        if (collision.gameObject.CompareTag("Piercing"))
        {
            item = collision.gameObject.GetComponent<ObjGame>();
            if (item != null)
            {
                Piercing = true;
                collect.Play();
                Display();
            }

        }
        if (collision.gameObject.CompareTag("BulletBox"))
        {
            item = collision.gameObject.GetComponent<ObjGame>();
            if (item != null)
            {
                bulletCount.countBullet += 30;
                collect.Play();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ThornCrab")){
            health-=20f;
            hit.Play();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Thorn")){
            if(coroutine==null){
                coroutine = StartCoroutine(MinusHp());
                hit.Play();
            }
            
        }
        if(other.CompareTag("Waterfall")){
            health = 0;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Thorn"))
        {
            // Dừng coroutine khi ra khỏi vùng trigger
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null; // Đặt lại biến
            }
        }
    }
    public IEnumerator MinusHp(){
        while(health>0){
            health-=2f;
            yield return new WaitForSeconds(1f);
        }
    }
    private void Display(){
        if(piercingImg!=null){
            piercingImg.enabled = true;
        }
    }
    private void DisplayDied(){
        if(imgDied!=null){
            imgDied.enabled = true;
            bg.enabled = true;
        }
    }
    public void IsDied(){
        if(health<=0){
            player.isDead = true;
            DisplayDied();
            if(coroutine==null){
                coroutine = StartCoroutine(backMenu());
            }
            
        }
    }
    IEnumerator backMenu(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(0);
    }

}

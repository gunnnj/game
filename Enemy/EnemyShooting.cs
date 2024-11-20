using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject prefab; 
    public float radius = 5f; 

    [SerializeField]
    private float timeCD = 7f;
    public Enemy enemy;
    private Coroutine coroutine;
    public GameObject message;
    public TextMeshProUGUI txt;

    private bool warning = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(enemy.hpEnemy<=(2*enemy.maxHpEnemy/3)){
            if(coroutine==null){
                coroutine = StartCoroutine(HZ());
            }
        }     
    }
    void SpawnPrefabs(Vector2 trans)
    {
        for (int i = 0; i < 10; i++)
        {       
            float angle = i * 36f;
             float angleInRadians = angle * Mathf.Deg2Rad; 
            Vector2 spawnPosition =trans + new Vector2(Mathf.Cos(angleInRadians) * radius,Mathf.Sin(angleInRadians) * radius);
            GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.Euler(0, 0, angle - 90)); 
            Rigidbody2D rb = instance.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0; 
            rb.AddForce((spawnPosition - (Vector2)transform.position).normalized * 1500f);
            Destroy(instance, 1f);
           
        }
    }
    IEnumerator HZ(){
        if(!warning){
            StartCoroutine(Warning());
        }
        yield return new WaitForSeconds(timeCD);
        Vector2 trans = (Vector2)transform.position;
        SpawnPrefabs(trans);  
        coroutine = null;
    }
    IEnumerator Warning(){
        message.SetActive(true);
        txt.text = "Cẩn thận những chiêu thức mới!";
        yield return new WaitForSeconds(2f);
        message.SetActive(false);
        warning = true;
    }
    
}

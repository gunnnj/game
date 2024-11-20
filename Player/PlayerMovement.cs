using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public Camera cam;

    private bool isDashing;
    private float dashTime;
    private float lastDashTime;

    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    public AudioSource dash;
    public AudioSource complete;
    public AudioSource swamp;

    public Image dashCooldownImage;

    public GameObject effectDash;
    public Transform pointEffect;

    private float driftSpeed = 0.2f;
    Vector2 movement;
    Vector2 mousePos;

    public bool isDead = false;

    private void Start()
    {
        StartCoroutine(Countdown()); 
    }
    void Update()
    {
        if(isDead){

        }else{
            //Cài đặt di chuyển
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);  // vị trí chuột
            

            if (Input.GetKey(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown)  // skill lướt
            {
                StartDash();
            }
            if (isDashing)
            {
                Dash();
                StartCoroutine(Countdown());
                dashTime += Time.deltaTime;
                if (dashTime >= dashDuration)
                {
                    isDashing = false;
                    rb.velocity = Vector2.zero; // Dừng lướt
                }
                
            }

            if (!isDashing)
            {
                if (!Input.GetButtonUp("Horizontal") && !Input.GetButtonUp("Vertical"))
                {
                    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                }
            }
        }
            
         
    }

    private void FixedUpdate()
    {

        Vector2 lookDir = mousePos - rb.position;  
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
    void StartDash()  // lướt
    {
        isDashing = true;
        dashTime = 0;
        lastDashTime = Time.time;

        // Tính toán hướng lướt theo vị trí chuột
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashDirection = (mousePosition - transform.position).normalized;

        // Thực hiện lướt
        rb.velocity = dashDirection * dashSpeed;
        dash.Play();
    }
    void Dash() 
    {
        // Có thể thêm hiệu ứng lướt ở đây nếu cần
        GameObject effect = Instantiate(effectDash, pointEffect.position, Quaternion.identity);
        Destroy(effect, 0.2f);

    }

    IEnumerator Countdown()  // Hàm đếm
    {
        float countdownTime = 10f; // 10 giây

        while (countdownTime > 0)
        {

            countdownTime -= 0.1f; // Giảm 1 giây
            dashCooldownImage.fillAmount = countdownTime / 10f;
            yield return new WaitForSeconds(0.1f); // Chờ 1 giây
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("River")){
            Vector3 driftDirection = new Vector3(1, 0, 0);
            transform.position = transform.position + driftDirection * driftSpeed;
        }
        if(other.CompareTag("Teleport")){
            
            StartCoroutine(NextScene());
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Swamp")){   
            swamp.loop = true;  
            swamp.Play();   
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Swamp")){          
            if(swamp.isPlaying && swamp!=null){
                swamp.Stop();
            } 
        }
    }

    public IEnumerator NextScene(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(2);
    }    
   

}

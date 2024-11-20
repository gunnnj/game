using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    public TextMeshProUGUI UItext;
    public GameObject message;
    [SerializeField]
    public int indexMsg = 0;
    private bool isDisPlay = false;
    private string textM;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        message.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.CompareTag("Player")){        
    //         DisPlay();
    //         StartCoroutine(DisPlay1());
    //     }
            
    // }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if(!isDisPlay){
                StartCoroutine(DisPlay());
            }
           
        }
    }
    void setText(int index){
        if(index == 0){
            textM = "Tiêu diệt quái vật để có cơ hội thu thập vật phẩm!";
        }
        if(index == 1){
            textM = "Cẩn thận những địa hình bất lợi cho bản thân";
        }
        if(index == 2){
            textM = "Những kẻ địch có thể tấn công từ xa!!";
        }
        if(index == 3){
            textM = "Bạn đã thu thập vật phẩm thiết yếu để tiêu diệt quái vật chưa?";
        }
        if(index == 4){
            textM = "Tìm cách để nhận phần thưởng!";
        }
        if(index == 5){
            textM = "Bạn bị rơi xuống thác nước";
        }
    }
    public IEnumerator DisPlay(){
        setText(indexMsg);
        UItext.text =textM+"";
        message.SetActive(true);
        yield return new WaitForSeconds(4f);  
        message.SetActive(false); 
        isDisPlay = true;        
    }
}

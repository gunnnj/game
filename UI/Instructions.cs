using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI ready;
    public GameObject Ins;

    public GameObject teleport;

    public GameObject piercing;

    public AudioSource click;


    private int index  = 0 ;
    public void OnClick(){
        index ++;
        click.Play();
    }
    public void Pass(){
        index = 7;
        click.Play();
    }
    public void Instruct(int index){
        if(index==1){
            text.text = "Dùng Q để chuyển đổi súng <-> kiếm\n\nSúng: Click chuột trái để bắn\n\n Kiếm: Click chuột trái để chém";
        }
        if(index== 2){
            text.text = "Kỹ năng:\n\nSử dụng SPACE để lướt\n\n Kiếm: Dùng chuột phải để đâm\nCác kỹ năng sẽ có hồi chiêu";
        }
        if(index==3){
            text.text = "Dùng E để sử dụng túi cứu thương\n\nQuan sát số lượng đạn và số lượng túi cứu thương để chiến đấu hợp lý";
        }
        if(index == 4){
            text.text = "Di chuột vào các biểu tượng để biết thêm chi tiết";
        }
        if(index==5){
            text.text = "Thu thập vật phẩm sẽ giúp bạn mạnh lên\n\nCác vật phẩm buff sẽ được hiển thị ở bên cạnh chiêu thức";
            if(piercing!=null){
                piercing.SetActive(true);
            }
        }
        if(index==6){
            text.text = "Di chuyển đến điểm dịch chuyển\n\nBạn đã sẵn sàng để đối mặt với cuộc chiến chưa?";
            ready.text = "Sẵn sàng";
        }
        if(index==7){
            Ins.SetActive(false); 
            teleport.SetActive(true);
        }
    }
    void Start()
    {   
        Ins.SetActive(true);
        teleport.SetActive(false);
        piercing.SetActive(false);
    }
    void Update()
    {
        Instruct(index);
    }
}

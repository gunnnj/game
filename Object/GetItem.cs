using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Transform pos;
    public Transform pos1;
    public Transform pos2;
    public Hiden stone;
    public Hiden stone1;
    public Hiden stone2;
    public GameObject item;
    private bool check = false;
    private bool check1 = false;
    private bool check2 = false;
    private bool isIntant = false;
    private string seq = "";
    // Start is called before the first frame update
    void Start()
    {
        item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        stone.gameObject.SetActive(!stone.isHiden);
        stone1.gameObject.SetActive(!stone1.isHiden);
        stone2.gameObject.SetActive(!stone2.isHiden);
        
        if(!check){
            chk();
        }
        if(!check1){
            chk1();
        }
        if(!check2){
            chk2();
        }
        if(check && check1 && check2){
            if(Check(seq)){
                if(!isIntant){
                    item.SetActive(true);
                    isIntant = true;
                }
                
            }
            else{
                ReSetTurn();
            }
        }
    }
    public void chk(){
        if(stone.HP<=0){ 
            seq = seq+"1";
            stone.isHiden = true;
            check = true;
        }
    }
    public void chk1(){
        if(stone1.HP<=0){
            seq = seq+"2";
            stone1.isHiden = true;
            check1 = true;
        }
    }
    public void chk2(){
        if(stone2.HP<=0){
            seq = seq+"3";
            stone2.isHiden = true;
            check2 = true;
        }
    }
    public bool Check(string str){
        if(str.Equals("123")){
            return true;
        }
        else{
            return false;
        }
    }
    public void ReSetTurn(){
        seq = "";
        stone.isHiden = false;
        stone1.isHiden = false;
        stone2.isHiden = false;
        stone.HP = 20f;
        stone1.HP = 20f;
        stone2.HP = 20f;
        check = false;
        check1 = false;
        check2 = false;
    }
}

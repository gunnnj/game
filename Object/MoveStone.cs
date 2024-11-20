using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStone : MonoBehaviour
{
    [SerializeField]
    private bool dir;
    private bool checkPlayer = false;
    private float time = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
       
      
        if(checkPlayer&& time>0){
            if(dir){
                transform.position = new Vector3(transform.position.x - 0.1f,transform.position.y,0);
            }
            else{
                transform.position = new Vector3(transform.position.x + 0.1f,transform.position.y,0);
            }
            time-=Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            checkPlayer = true;
        }
    }
}

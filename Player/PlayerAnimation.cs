using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Lấy component Animator từ GameObject
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // Kiểm tra xem phím Q có được nhấn không
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            //Chuyển đổi vũ khí
            if (animator.GetBool("IsChange")) {
                animator.SetBool("IsChange", false);
            }
            else
            {
                animator.SetBool("IsChange", true);
            }
            
            

        }
        
    }
}

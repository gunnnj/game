using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPEnermy : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    public Image healthBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = enemy.hpEnemy/enemy.maxHpEnemy;
    } 

}

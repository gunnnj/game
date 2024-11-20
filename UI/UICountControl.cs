using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICountControl : MonoBehaviour
{
    public int countBullet = 30;
    
    private TextMeshProUGUI count;
    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        count.text = "X " + countBullet.ToString();
        
    }
}

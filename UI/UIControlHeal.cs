using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControlHeal : MonoBehaviour
{ 
    public int countHeal = 0;
    private TextMeshProUGUI count;
    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {     
        count.text = "X " + countHeal.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMenu : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public GameObject button;
    public TextMeshProUGUI text;
    public AudioSource btnClick;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button != null)
        {
            text.fontSize +=10f;
            btnClick.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (button != null)
        {
            text.fontSize-=10f;
        }
    }
}

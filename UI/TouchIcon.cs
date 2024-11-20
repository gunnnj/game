using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject showObj;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        showObj.SetActive(false);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null)
        {
            showObj.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null)
        {
            showObj.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

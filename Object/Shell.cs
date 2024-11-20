using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private float timeDestroy = 2f;
    void OnEnable()
    {
        StartCoroutine(setActive(timeDestroy));
    }
    IEnumerator setActive(float time){
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}

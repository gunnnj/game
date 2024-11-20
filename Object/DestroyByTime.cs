using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        CountTime();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerable CountTime()
    {
        yield return new WaitForSeconds(timeDestroy);
    }
}

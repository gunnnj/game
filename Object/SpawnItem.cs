using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSpawn;
    public GameObject gameObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObj == null){
            Debug.Log("spawn");
            Instantiate(itemSpawn, transform.position, Quaternion.identity);
        }
    }
}

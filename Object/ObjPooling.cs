using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    [SerializeField]
    private ItemSpawn bullet;
    [SerializeField]
    private ItemSpawn shell;
    public static ObjPooling instance;
    void Start()
    {
        instance = this;
        Name();
    }
    void Name(){
        bullet.Instantiate();
        shell.Instantiate();
    }
    public void SpawnBullet(Vector3 position, Quaternion rotate, Vector3 direc){
        bullet.SpawnBullet(position,rotate,direc);
    }
    public void SpawShell(Vector3 position, Quaternion rotate){
        shell.SpawnShell(position,rotate);
    }
}

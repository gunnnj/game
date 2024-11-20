using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public AudioSource btnclick;
    public void Menu(){
        btnclick.Play();
        SceneManager.LoadSceneAsync(0);
    }
}

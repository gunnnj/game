using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageScene : MonoBehaviour
{
    public GameObject goHiden;
    public GameObject goDis;
    public Image image;

    public AudioSource btnClick;
    void Start()
    {
        goHiden.SetActive(true);
        goDis.SetActive(false);
    }
    public void NewGame(){
        btnClick.Play();
        goHiden.SetActive(false);
        goDis.SetActive(true);
        StartCoroutine(LoadScene(1));
    }
    public void Continue(){
        btnClick.Play();
       goHiden.SetActive(false);
        goDis.SetActive(true);
        StartCoroutine(LoadScene(2));
    }
    public void Quite(){
        btnClick.Play();
        Application.Quit();
    }
    IEnumerator LoadScene(int ind){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(ind);

        while (!asyncLoad.isDone)
        {
            float progressAsyn = Mathf.Clamp01(asyncLoad.progress/0.9f);
            image.fillAmount = progressAsyn;
            yield return null; // Chờ cho đến frame tiếp theo
        }
        yield return null;
    }
}

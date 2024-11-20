using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    private float timeDestroy = 0.5f;
    public float dame = 10f;
    // Xử lý va chạm khi đạn trúng mục tiêu -> tạo ra hiệu ứng
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
    void OnEnable()
    {
        StartCoroutine(setActive(timeDestroy));
    }
    IEnumerator setActive(float time){
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

}

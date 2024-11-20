using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject iceBroken;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(iceBroken, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Destroy(gameObject); // xóa hiệu ứng
    }
}

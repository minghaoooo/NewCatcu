// CatFall.cs
using UnityEngine;

public class CatFall : MonoBehaviour
{
    public float fallSpeed;     // bisa diubah per kucing
    public float destroyY = -10f;    // hapus kalau sudah jauh di bawah

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        if (transform.position.y < destroyY) Destroy(gameObject);
    }
}

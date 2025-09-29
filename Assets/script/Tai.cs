using UnityEngine;
using System;

public class Tai : MonoBehaviour
{
    public event Action Dead;  // Event untuk memberitahukan bahwa Tai mengenai player

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Jika objek yang terkena adalah player
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);  // Hapus objek tai
            Dead?.Invoke();  // Panggil event Dead
        }
    }
}

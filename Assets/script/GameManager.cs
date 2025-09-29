using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Tai tai;  // Referensi ke objek Tai (kucing)

    void Start()
    {
        tai.Dead += OnTaiDead;  // Menambahkan listener ke event Dead
    }

    void OnTaiDead()
    {
        Debug.Log("Tai telah dihancurkan!");
        // Logika game over atau apapun yang diinginkan
    }

    void OnDestroy()
    {
        tai.Dead -= OnTaiDead;  // Jangan lupa untuk unsubscribe event
    }
}

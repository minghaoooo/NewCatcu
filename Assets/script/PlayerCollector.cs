using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var cat = other.GetComponent<CatCollectible>();
        if (cat) cat.Collect();
    }
}

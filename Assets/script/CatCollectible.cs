// CatCollectible.cs
using UnityEngine;

public class CatCollectible : MonoBehaviour
{
    public int value = 1;
    bool collected;

    public void Collect()
    {
        if (collected) return;
        collected = true;

        if (CatCounter.I != null) CatCounter.I.Add(value);
        Destroy(gameObject);
    }
}

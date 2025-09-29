using UnityEngine;
using UnityEngine.UI;

public class CatCounter : MonoBehaviour
{
    public static CatCounter I;
    public int count;
    public Text countText;

    void Awake() { I = this; UpdateUI(); }
    public void Add(int v = 1) { count += v; UpdateUI(); }
    void UpdateUI() { if (countText) countText.text = $"Cats: {count}"; }
}

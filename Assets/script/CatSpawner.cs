using UnityEngine;
using System.Collections;

public class CatSpawner : MonoBehaviour
{
    [Header("Area spawn (otomatis dari kamera jika kosong)")]
    public float minX, maxX, ySpawn;
    public bool autoFromCamera = true;
    public float margin = 0.5f;

    [Header("Prefab kucing")]
    public GameObject[] catPrefabs;

    [Header("Kontrol jeda spawn")]
    public Vector2 gapRange = new Vector2(0.5f, 1f); // jeda antar-spawn (detik)
    public float minXSeparation = 1.0f;               // jarak X minimal dari spawn sebelumnya

    [Header("Kecepatan jatuh")]
    public float fallSpeed = 2.5f;

    private float lastSpawnX = 999f;

    void Start()
    {
        if (autoFromCamera && Camera.main)
        {
            var cam = Camera.main;
            float halfW = cam.orthographicSize * cam.aspect;
            float topY  = cam.transform.position.y + cam.orthographicSize;
            minX = -halfW + margin;
            maxX =  halfW - margin;
            ySpawn = topY + margin;
        }
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            // langsung jeda antar spawn (tanpa cek jumlah kucing aktif)
            float delay = Random.Range(gapRange.x, gapRange.y);
            yield return new WaitForSeconds(delay);

            SpawnOne();
        }
    }

    void SpawnOne()
    {
        if (catPrefabs == null || catPrefabs.Length == 0) return;

        // cari X yang cukup jauh dari spawn sebelumnya
        float x;
        int tries = 8;
        do { x = Random.Range(minX, maxX); }
        while (Mathf.Abs(x - lastSpawnX) < minXSeparation && --tries > 0);
        lastSpawnX = x;

        var prefab = catPrefabs[Random.Range(0, catPrefabs.Length)];
        var go = Instantiate(prefab, new Vector3(x, ySpawn, 0f), Quaternion.identity);

        // set kecepatan jatuh jika ada CatFall
        var fall = go.GetComponent<CatFall>();
        if (fall) fall.fallSpeed = fallSpeed;
    }
}

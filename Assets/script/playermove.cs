using UnityEngine;

public class PlayerMoveAD : MonoBehaviour
{
    public float speed = 7f;
    private bool facingRight = true;

    void Update()
    {
        float x = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  x -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x += 1f;

        // Gerak horizontal
        transform.position += new Vector3(x * speed * Time.deltaTime, 0f, 0f);

        // === Balik arah sesuai input ===
        if (x > 0 && !facingRight)        // bergerak ke kanan
            Flip();
        else if (x < 0 && facingRight)    // bergerak ke kiri
            Flip();

        // Clamp otomatis sesuai kamera
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float margin = 0.5f;
        float clampX = halfWidth - margin;
        var p = transform.position;
        p.x = Mathf.Clamp(p.x, -clampX, clampX);
        transform.position = p;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;          // balik sumbu X
        transform.localScale = scale;
    }
}

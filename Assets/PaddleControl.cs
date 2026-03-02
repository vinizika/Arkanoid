using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public float speed = 8f;
    public float minX = -2.5f;
    public float maxX = 2.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D ou setas

        Vector2 v = new Vector2(h * speed, 0f);
        rb.linearVelocity = v;

        // trava posição no X (estilo Pong: ifs)
        Vector3 p = transform.position;
        if (p.x < minX) p.x = minX;
        else if (p.x > maxX) p.x = maxX;

        transform.position = p;
    }
}
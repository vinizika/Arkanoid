using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float initialSpeed = 6f;
    public Transform paddle;
    public float offsetY = 0.6f;

    private Rigidbody2D rb;
    private bool launched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
    }

    void Update()
    {
        if (GameManager.instance.gameOver) return; // trava tudo

        if (!launched)
        {
            if (paddle != null)
            {
                transform.position = new Vector3(
                    paddle.position.x,
                    paddle.position.y + offsetY,
                    transform.position.z
                );
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                launched = true;
                rb.linearVelocity = new Vector2(0.7f, 1f).normalized * initialSpeed;
            }
        }
    }

    public void ResetBall()
    {
        launched = false;
        rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.AddPoint();
        }
    }
}
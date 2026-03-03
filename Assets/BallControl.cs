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

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ReiniciarRodada();
        }
    }

    void ReiniciarRodada()
    {
        // 1. Tira uma vida do jogador
        GameManager.instance.LoseLife(); 
 
        // 2. Reseta a bolinha (usa a função que você já tem)
        ResetBall(); 

        // 3. Reseta o TAMANHO da Bolinha para o padrão (1, 1, 1)
        transform.localScale = new Vector3(1f, 1f, 1f);

        // 4. Reseta o TAMANHO da Raquete
        if (paddle != null)
        {
            paddle.localScale = new Vector3(1f, 1f, 1f); 
        }    
        
        // Opcional: Se você quiser que a bolinha pare de se mover imediatamente
        rb.linearVelocity = Vector2.zero;
        
        Debug.Log("Vida perdida! Reiniciando...");
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
        else if (collision.gameObject.CompareTag("LifeBrick"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.AddPoint(); 
            GameManager.instance.AddLife();  
        }
    }
}
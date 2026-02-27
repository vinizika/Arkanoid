using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public BallControl ball;
    public GameManager gm;

    void Start() { }
    void Update() { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gm != null)
            {
                gm.LoseLife();
                if (gm.gameOver) return;
            }
            ball.ResetBall();
        }
    }
}
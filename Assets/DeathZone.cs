using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void Start() { }
    void Update() { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.instance.LoseLife();

            BallControl bc = other.GetComponent<BallControl>();
            if (bc != null && (GameManager.instance == null || !GameManager.instance.gameOver))
                bc.ResetBall();
        }
    }
}
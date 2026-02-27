using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int lives = 2;

    public bool gameOver = false;
    public bool playerWon = false;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // destrói duplicado
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start() { }
    void Update() { }

    public void AddPoint()
    {
        if (gameOver) return;
        score += 1;
    }

    public void LoseLife()
    {
        if (gameOver) return;

        lives -= 1;
        if (lives <= 0)
        {
            lives = 0;
            LoseGame();
        }
    }

    public void WinGame()
    {
        gameOver = true;
        playerWon = true;
        SceneManager.LoadScene("Final");     // vitória vai pra Final
    }

    public void LoseGame()
    {
        gameOver = true;
        playerWon = false;
        SceneManager.LoadScene("GameOver");  // derrota vai pra GameOver
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 200, 30), "Pontos: " + score);
        GUI.Label(new Rect(20, 45, 200, 30), "Vidas: " + lives);
    }
}
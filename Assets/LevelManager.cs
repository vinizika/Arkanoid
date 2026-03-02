using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextSceneName = "Fase2";
    public bool winWhenFinished = false; // Fase2 = true

    void Start() { }

    void Update()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0)
        {
            if (winWhenFinished)
                GameManager.instance.WinGame();
            else
                SceneManager.LoadScene(nextSceneName);
        }
    }
}
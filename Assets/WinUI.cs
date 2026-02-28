using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    void Start() { }
    void Update() { }

    void OnGUI()
    {
        if (GameManager.instance == null)
        {
            GUI.Label(new Rect(20, 20, 400, 30), "GameManager não encontrado.");
            return;
        }

        GUI.Label(new Rect(20, 90, 400, 40), "VOCÊ GANHOU!");
        GUI.Label(new Rect(20, 120, 400, 30), 
            "Pontuação final: " + GameManager.instance.score);

        if (GUI.Button(new Rect(20, 150, 200, 40), "Reiniciar"))
        {
            Destroy(GameManager.instance.gameObject);
            SceneManager.LoadScene("InitialScene");
        }
    }
}
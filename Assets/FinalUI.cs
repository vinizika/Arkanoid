using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalUI : MonoBehaviour
{
    void Start() { }
    void Update() { }

    void OnGUI()
    {
        if (GameManager.instance == null)
        {
            GUI.Label(new Rect(20, 20, 400, 30), "Sem GameManager!");
            return;
        }

        string msg = GameManager.instance.playerWon ? "VOCÊ GANHOU!" : "VOCÊ PERDEU!";
        GUI.Label(new Rect(20, 90, 400, 30), msg);
        GUI.Label(new Rect(20, 120, 400, 30), "Pontuação final: " + GameManager.instance.score);

        if (GUI.Button(new Rect(20, 150, 200, 40), "Reiniciar"))
        {
            Destroy(GameManager.instance.gameObject);
            SceneManager.LoadScene("Fase1");
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialUI : MonoBehaviour
{
    void Start() { }
    void Update() { }

    void OnGUI()
    {
        GUIStyle wrap = new GUIStyle(GUI.skin.label);
        wrap.wordWrap = true;

        float x = 20f;
        float width = 250f;

        GUI.Label(new Rect(x, 20, width, 30), "ARKANOID");

        GUI.Label(
            new Rect(x, 60, width, 60),
            "Criado por Vinicius Duarte (22.224.020-2) e Julian Takeda (22.224.030-1)",
            wrap
        );

        GUI.Label(
            new Rect(x, 110, width, 40),
            "> O jogador inicia com 2 vidas; caso elas acabem, o jogo reseta.",
            wrap
        );

        GUI.Label(
            new Rect(x, 150, width, 40),
            "> Cada bloco verde/branco quebrado adiciona 1 ponto ao score.",
            wrap
        );

        GUI.Label(
            new Rect(x, 190, width, 40),
            "> Cada bloco vermelho quebrado adiciona 1 ponto ao score e 1 vida extra.",
            wrap
        );

        GUI.Label(
            new Rect(x, 230, width, 40),
            "> Os blocos roxos não podem ser destruídos.",
            wrap
        );

        GUI.Label(
            new Rect(x, 270, width, 40),
            "> PowerUp de crescer a bolinha ou o paddle",
            wrap
        );

        GUI.Label(
            new Rect(x, 310, width, 40),
            "> Use A/D ou setas para mover o paddle.",
            wrap
        );

        GUI.Label(
            new Rect(x, 350, width, 40),
            "> Aperte ESPAÇO para lançar a bola.",
            wrap
        );

        if (GUI.Button(new Rect(x, 390, 220, 45), "Iniciar Jogo"))
        {
            if (GameManager.instance != null)
                Destroy(GameManager.instance.gameObject);
            SceneManager.LoadScene("Fase1");
        }
    }
}
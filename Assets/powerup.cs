using UnityEngine;
using System.Collections;

public class powerup : MonoBehaviour
{
    public float larguraExtraRaquete = 1.0f;
    public float escalaExtraBola = 0.5f; // Quanto a bola vai crescer
    public float duracao = 5.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // SORTEIO: 0 para Raquete, 1 para Bolinha
            int sorteio = Random.Range(0, 2);

            if (sorteio == 0)
            {
                StartCoroutine(EfeitoTamanhoRaquete(other.gameObject));
            }
            else
            {
                StartCoroutine(EfeitoTamanhoBola());
            }

            // "Esconde" o item enquanto a corrotina roda
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

    // --- EFEITO DA RAQUETE ---
    IEnumerator EfeitoTamanhoRaquete(GameObject player)
    {
        Vector3 escalaOriginal = player.transform.localScale;
        player.transform.localScale += new Vector3(larguraExtraRaquete, 0, 0);

        yield return new WaitForSeconds(duracao);

        if (player != null) player.transform.localScale = escalaOriginal;
        Destroy(gameObject);
    }

    // --- EFEITO DA BOLINHA ---
    IEnumerator EfeitoTamanhoBola()
    {
        // Tenta encontrar o objeto que tem o script BallControl
        BallControl ball = FindFirstObjectByType<BallControl>();

        if (ball != null)
        {
            Vector3 escalaOriginal = ball.transform.localScale;
            ball.transform.localScale += new Vector3(escalaExtraBola, escalaExtraBola, 0);

            yield return new WaitForSeconds(duracao);

            if (ball != null) ball.transform.localScale = escalaOriginal;
        }
        
        Destroy(gameObject);
    }
}
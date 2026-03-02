using UnityEngine;

public class block : MonoBehaviour
{
    public GameObject powerUpPrefab; // Arraste seu item aqui no Inspector
    [Range(0, 100)] public float chanceDeDrop = 20f;

    // Este método especial do Unity roda AUTOMATICAMENTE quando o objeto é destruído
    void OnDestroy()
    {
        // Verifica se o jogo está rodando (evita erro ao fechar o Unity)
        if (!gameObject.scene.isLoaded) return;

        TentarDroparItem();
    }

    void TentarDroparItem()
    {
        if (powerUpPrefab != null)
        {
            //float sorteio = Random.Range(0f, 100f);
            //if (sorteio <= chanceDeDrop)
            //{
                // Cria o item na posição onde o bloco estava
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            //}
        }
    }
}
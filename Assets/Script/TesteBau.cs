
using UnityEngine; // Importa as ferramentas principais da Unity, como MonoBehaviour, Collider2D e GetComponent.
using UnityEngine.SceneManagement; // Importa as ferramentas responsáveis pelo carregamento e gerenciamento das cenas.

public class Portao : MonoBehaviour // Cria a classe Portao, responsável por controlar a passagem do jogador pelo portão.
{

    private void OnTriggerEnter2D(Collider2D other) // Executa automaticamente quando outro Collider2D entra na área de colisão marcada como Trigger.
    {
        if (other.CompareTag("Porta") && other.GetComponent<Player>().temChave == true) // Verifica duas condições: se o objeto que entrou possui a Tag "Porta" e se ele tem o script Player com a variável temChave igual a true.
        {
            SceneManager.LoadScene("fas2"); // Se as duas condições forem verdadeiras, carrega a cena chamada "fas2".
        }
    }

}

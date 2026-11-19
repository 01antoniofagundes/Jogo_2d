
using UnityEngine; // Importa as ferramentas principais da Unity, como MonoBehaviour e Collider2D.
using UnityEngine.SceneManagement; // Importa as ferramentas responsáveis pelo carregamento e gerenciamento das cenas.

public class PassaarFase1 : MonoBehaviour // Cria a classe PassaarFase, responsável por detectar a passagem para a próxima etapa do jogo.
{

    private void OnTriggerEnter2D(Collider2D collision) // Executa automaticamente quando outro Collider2D entra na área de um Collider2D marcado como Trigger.
    {
        if (collision.CompareTag("Porta")) // Verifica se o objeto que entrou na área possui a Tag "Porta".
        {
            SceneManager.LoadScene("Vitoria"); // Carrega a cena chamada "Vitoria", levando o jogador para a tela de vitória.
        }
    }

}


using NUnit.Framework.Internal; // Importa ferramentas internas de testes. Neste código, aparentemente não está sendo utilizada.
using UnityEngine; // Importa as ferramentas principais da Unity, como Transform, Vector2 e Collider2D.

public class SeguirPlayer : MonoBehaviour // Cria a classe SeguirPlayer, responsável por fazer um objeto seguir o jogador.
{
    private Transform player; // Guarda a posição, rotação e escala do jogador que será seguido.

    public float velocidade = 5.6f; // Define a velocidade com que o objeto vai se movimentar em direção ao jogador.
    public float distanciaMinima = 1.5f; // Define a distância mínima que o objeto deve manter do jogador.
    private bool seguindo; // Variável que informa se o objeto deve começar a seguir o jogador. Começa como false.

    private BoxCollider2D BoxCollider2D; // Cria uma variável para guardar o componente BoxCollider2D do objeto.

    private void Start() // Executa uma única vez quando o objeto começa a funcionar no jogo.
    {
        BoxCollider2D = GetComponent<BoxCollider2D>(); // Procura o BoxCollider2D no próprio objeto e guarda na variável.
    }

    void Update() // Executa repetidamente durante o jogo, geralmente uma vez por quadro.
    {
        if (seguindo && player != null) // Verifica se o objeto está autorizado a seguir e se o jogador foi encontrado.
        {
            float distancia = Vector2.Distance(transform.position, player.position); // Calcula a distância entre o objeto atual e o jogador.

            // Só se aproxima se estiver longe demais.
            if (distancia > distanciaMinima) // Verifica se a distância atual é maior que a distância mínima definida.
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, velocidade * Time.deltaTime); // Move o objeto em direção ao jogador, respeitando a velocidade definida e o tempo entre os quadros.

                // Faz o objeto se aproximar do jogador.
                BoxCollider2D.isTrigger = true; // Transforma o colisor em Trigger, fazendo com que ele deixe de bloquear fisicamente outros objetos.
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Executa quando o objeto colide fisicamente com outro objeto 2D.
    {
        if (collision.gameObject.CompareTag("Porta")) // Verifica se o objeto que encostou possui a Tag "Porta".
        {
            // Só vai ser ativada a perseguição quando o objeto com a Tag "Porta" encostar no objeto.
            // Ao encostar, seguindo = true.
            player = collision.transform; // Guarda a referência e a posição do objeto que encostou, para que ele seja seguido.
            seguindo = true; // Ativa a perseguição, permitindo que o objeto comece a seguir o jogador.

            if (collision.gameObject.CompareTag("Porta")) // Verifica novamente se o objeto que encostou possui a Tag "Porta".
            {
                collision.gameObject.GetComponent<Player>().temChave = true; // Acessa o script Player do objeto que encostou e altera temChave para true.
                // A variável booleana temChave passa a indicar que o jogador possui a chave.
            }
        }
    }

}

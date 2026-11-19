
using UnityEngine; // Importa as ferramentas principais da Unity, incluindo física, componentes e entrada do jogador.
using UnityEngine.SceneManagement; // Importa ferramentas para controlar cenas do jogo. (Não está sendo utilizada diretamente neste script.)
using System.Collections; // Permite utilizar IEnumerator e Coroutines, necessárias para executar o Dash ao longo do tempo.

public class Player : MonoBehaviour // Cria a classe Player, que controla os comportamentos do personagem.
{
    public float speed = 5f; // Define a velocidade horizontal do jogador. O valor pode ser alterado no Inspector.

    // =========================
    // CONFIGURAÇÕES DO DASH
    // =========================

    public float dashForce = 15f; // Define a velocidade horizontal do jogador durante o Dash.
    public float dashDuration = 0.2f; // Define quanto tempo o Dash vai durar, em segundos.
    public float dashCooldown = 1f; // Define o tempo de espera necessário para poder utilizar outro Dash.

    private Rigidbody2D rb; // Cria uma variável para armazenar o componente Rigidbody2D do jogador.
    private bool isGrounded = false; // Indica se o jogador está no chão. Começa como falso.
    public bool temChave; // Indica se o jogador possui uma chave. Pode ser acessada por outros scripts.

    // =========================
    // CONTROLE DO DASH
    // =========================

    private bool canDash = true; // Controla se o jogador pode utilizar o Dash. Começa como verdadeiro.
    private bool isDashing = false; // Indica se o jogador está realizando um Dash. Começa como falso.

    // =========================
    // DIREÇÃO DO JOGADOR
    // =========================

    private float direction = 1f; // Armazena a direção para a qual o jogador está olhando. 1 significa direita e -1 significa esquerda.

    public MenuScene menu; // Cria uma referência ao script MenuScene, utilizado para mostrar a tela de Game Over.


    void Start() // Executa uma única vez quando o objeto Player começa a funcionar.
    {
        rb = GetComponent<Rigidbody2D>(); // Procura o componente Rigidbody2D no próprio objeto e armazena sua referência.
        temChave = false; // Define que o jogador começa o jogo sem possuir a chave.
    }


    void Update() // Executa a cada frame do jogo. É utilizado para verificar os comandos do jogador.
    {
        // =========================
        // MOVIMENTO
        // =========================

        float moveHorizontal = Input.GetAxis("Horizontal"); // Captura o comando horizontal do jogador. Retorna valores entre -1 e 1.

        // Só permite movimento normal quando não está dando Dash
        if (!isDashing) // Verifica se o jogador NÃO está realizando um Dash.
        {
            rb.linearVelocity = new Vector2( // Altera a velocidade do Rigidbody2D utilizando um vetor com X e Y.
                moveHorizontal * speed, // Define a velocidade horizontal multiplicando o comando pela velocidade configurada.
                rb.linearVelocity.y // Mantém a velocidade vertical atual, evitando interferir na gravidade ou no pulo.
            );
        }


        // Guarda a direção que o jogador está olhando
        if (moveHorizontal != 0) // Verifica se o jogador está apertando alguma direção horizontal.
        {
            direction = moveHorizontal; // Atualiza a direção para a última direção em que o jogador se movimentou.
        }


        // =========================
        // PULO
        // =========================

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Verifica se a tecla Espaço foi pressionada e se o jogador está no chão.
        {
            rb.AddForce( // Aplica uma força física ao Rigidbody2D.
                new Vector2(0f, 6.5f), // Define a força aplicada: 0 no eixo horizontal e 6.5 no eixo vertical.
                ForceMode2D.Impulse // Aplica a força como um impulso instantâneo, gerando o pulo.
            );
        }


        // =========================
        // DASH
        // =========================

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) // Verifica se a tecla Shift foi pressionada e se o Dash está disponível.
        {
            StartCoroutine(Dash()); // Inicia a Coroutine Dash(), permitindo executar o movimento especial ao longo de vários frames.
        }
    }


    IEnumerator Dash() // Cria uma Coroutine, que permite pausar e continuar a execução de um código ao longo do tempo.
    {
        // Impede outro Dash enquanto este estiver acontecendo
        canDash = false; // Impede que o jogador inicie outro Dash.
        isDashing = true; // Informa ao restante do código que o jogador está realizando um Dash.

        float timer = 0f; // Cria um cronômetro que começa em zero para controlar a duração do Dash.

        // Faz o jogador se mover durante o tempo do Dash
        while (timer < dashDuration) // Repete o movimento enquanto o cronômetro for menor que a duração configurada.
        {
            rb.linearVelocity = new Vector2( // Altera a velocidade do jogador durante o Dash.
                direction * dashForce, // Aplica a velocidade horizontal na direção em que o jogador está olhando.
                0f // Zera a velocidade vertical durante o Dash.
            );

            timer += Time.deltaTime; // Acrescenta ao cronômetro o tempo passado desde o último frame.

            yield return null; // Pausa a Coroutine até o próximo frame, permitindo que o jogo continue funcionando.
        }

        // Finaliza o Dash
        isDashing = false; // Informa que o jogador terminou o Dash.

        // Para o movimento horizontal
        rb.linearVelocity = new Vector2( // Altera novamente a velocidade do jogador.
            0f, // Zera a velocidade horizontal para interromper o movimento do Dash.
            rb.linearVelocity.y // Mantém a velocidade vertical atual.
        );

        // Espera o cooldown
        yield return new WaitForSeconds(dashCooldown); // Pausa a Coroutine durante o tempo de recarga configurado.

        // Permite usar Dash novamente
        canDash = true; // Libera a utilização de outro Dash.
    }


    // =========================
    // COLISÕES
    // =========================

    void OnCollisionEnter2D(Collision2D collision) // Executa automaticamente quando o jogador começa a colidir com outro objeto 2D.
    {
        if (collision.gameObject.CompareTag("ground")) // Verifica se o objeto que recebeu a colisão possui a Tag "ground".
        {
            isGrounded = true; // Informa que o jogador está no chão, permitindo que ele pule.
        }

        if (collision.gameObject.CompareTag("Dano")) // Verifica se o objeto que recebeu a colisão possui a Tag "Dano".
        {
            menu.MostrarGameOver(); // Chama o método MostrarGameOver() do script MenuScene para exibir a tela de Game Over.
        }
    }


    void OnCollisionExit2D(Collision2D collision) // Executa automaticamente quando o jogador deixa de colidir com outro objeto 2D.
    {
        if (collision.gameObject.CompareTag("ground")) // Verifica se o objeto que deixou de colidir possui a Tag "ground".
        {
            isGrounded = false; // Informa que o jogador não está mais no chão, impedindo que pule no ar.
        }
    }
}

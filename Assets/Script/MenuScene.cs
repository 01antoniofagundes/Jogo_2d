
using UnityEngine; // Importa as ferramentas principais da Unity, como GameObjects, componentes e controle do tempo.
using UnityEngine.UIElements; // Importa ferramentas de interface da Unity. (Não está sendo utilizada diretamente neste script.)
using UnityEngine.SceneManagement; // Importa ferramentas para carregar, reiniciar e trocar as cenas do jogo.

public class MenuScene : MonoBehaviour // Cria a classe MenuScene, responsável por controlar os menus do jogo.
{
    public GameObject pGameover; // Cria uma referência ao painel de Game Over, que será configurado pelo Inspector.
    public GameObject pPause; // Cria uma referência ao painel de pausa, que será configurado pelo Inspector.

    bool pause = false; // Armazena se o jogo está pausado. Começa como falso.
    bool acabou = false; // Armazena se a partida terminou. Começa como falso.

    void Start() // Executa uma única vez quando o objeto começa a funcionar.
    {
        pPause.SetActive(false); // Desativa o painel de pausa quando o jogo começa.
        pGameover.SetActive(false); // Desativa o painel de Game Over quando o jogo começa.
    }

    // Update is called once per frame
    void Update() // Executa a cada frame do jogo, verificando se o jogador pressionou alguma tecla.
    {
        if (Input.GetKeyUp(KeyCode.Escape)) // Verifica se a tecla Esc foi solta após ser pressionada.
        {
            if (pause) // Verifica se a variável pause é verdadeira, ou seja, se o jogo está pausado.
            {
                Continuar(); // Se estiver pausado, chama o método Continuar() para voltar ao jogo.
            }
            else // Executa caso pause seja falso, ou seja, se o jogo não estiver pausado.
            {
                Pausar(); // Chama o método Pausar() para interromper o jogo.
            }

        }
    }

    public void Pausar() // Cria um método público que pode ser chamado por outros scripts ou por botões da interface.
    {
        if (acabou == false) // Verifica se a partida ainda não terminou. Impede pausar após o Game Over.
        {
            pause = true; // Atualiza a variável pause, informando que o jogo está pausado.
            pPause.SetActive(true); // Ativa e mostra o painel de pausa na tela.
            Time.timeScale = 0f; // Paralisa o tempo do jogo, interrompendo a física e a maioria dos movimentos.
        }
    }

    public void Continuar() // Cria um método público responsável por retomar a partida.
    {
        pause = false; // Atualiza a variável pause, informando que o jogo não está mais pausado.
        pPause.SetActive(false); // Desativa e esconde o painel de pausa.
        Time.timeScale = 1f; // Restaura a velocidade normal do tempo do jogo.
    }

    public void MostrarGameOver() // Cria um método público responsável por exibir a tela de Game Over.
    {
        acabou = true; // Informa que a partida terminou.
        pGameover.SetActive(true); // Ativa e mostra o painel de Game Over.
        Time.timeScale = 0f; // Paralisa o tempo do jogo para interromper a partida.
    }

    public void Reiniciar() // Cria um método público que permite reiniciar a fase atual.
    {
        Time.timeScale = 1f; // Restaura o tempo normal antes de recarregar a cena.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual utilizando seu nome.
    }

    public void MenuButton() // Cria um método público responsável por retornar à tela principal do jogo.
    {
        SceneManager.LoadScene("menu"); // Carrega a cena chamada "menu". O nome precisa corresponder ao da cena cadastrada no projeto.
        Time.timeScale = 1f; // Restaura a velocidade normal do tempo do jogo.
    }
}

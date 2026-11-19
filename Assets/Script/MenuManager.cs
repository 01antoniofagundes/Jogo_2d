
using UnityEngine; // Importa as ferramentas principais da Unity, como MonoBehaviour e Application.
using UnityEngine.SceneManagement; // Importa as ferramentas responsáveis por carregar e controlar as cenas do jogo.

public class MenuManager : MonoBehaviour // Cria a classe MenuManager, responsável por controlar as ações do menu principal.
{

    public void StartGame() // Cria um método público que pode ser associado ao botão de iniciar o jogo.
    {
        SceneManager.LoadScene(1); // Carrega a cena que ocupa a posição 1 na lista de cenas do Build Settings/Build Profiles.
    }

    public void QuitGame() // Cria um método público responsável por encerrar o jogo.
    {
        Application.Quit(); // Encerra a aplicação quando o jogo está sendo executado como um programa.

    }

    public void MenuButton() // Cria um método público que pode ser associado a um botão para carregar uma cena.
    {
        SceneManager.LoadScene(1); // Carrega novamente a cena que está na posição 1 da lista de cenas.
    }

}

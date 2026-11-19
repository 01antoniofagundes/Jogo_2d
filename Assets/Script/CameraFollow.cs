
using System.Runtime.CompilerServices; // Importa ferramentas relacionadas ao compilador e execução de código. (Não está sendo utilizada diretamente neste script.)
using UnityEngine; // Importa as ferramentas principais da Unity, como Transform, Vector3 e Time.
using UnityEngine.UIElements; // Importa ferramentas de interface da Unity. (Não está sendo utilizada diretamente neste script.)

public class CameraFollow : MonoBehaviour // Cria a classe CameraFollow, responsável por controlar o movimento da câmera.
{

    public Transform alvo; // Define o objeto que a câmera deverá acompanhar, normalmente o jogador.
    public Vector3 distancia = new Vector3(0f, 0f, -10f); // Define a distância entre a câmera e o jogador nos eixos X, Y e Z.
    public bool MovimentoSuave = true; // Define se a câmera terá movimento suave. Começa ativado.
    public float velocidade = 5f; // Define a velocidade com que a câmera se aproxima da posição desejada.


    void LateUpdate() // Executa a cada frame, depois que os métodos Update dos outros objetos foram executados.
    {
        Vector3 posicaoDesejada = alvo.position + distancia; // Calcula a posição em que a câmera deve ficar, somando a posição do jogador com a distância configurada.

        if (MovimentoSuave) // Verifica se a opção de movimento suave está ativada.
        {
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidade * Time.deltaTime); // Move a câmera suavemente da posição atual até a posição desejada, considerando a velocidade e o tempo entre frames.
        }
        else // Executa caso o movimento suave esteja desativado.
        {
            transform.position = posicaoDesejada; // Coloca a câmera diretamente na posição desejada, sem suavização.
        }
    }
}

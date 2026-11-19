
using UnityEngine; // Importa as ferramentas principais da Unity, como Transform, Vector3 e MonoBehaviour.

public class Parallax : MonoBehaviour // Cria a classe Parallax, responsável por controlar a movimentação das camadas do fundo.
{
    public Transform cameraTransform; // Armazena a referência da câmera, que será utilizada para identificar seu movimento.
    public float parallaxEffect; // Define a intensidade do efeito de paralaxe. Quanto menor o valor, mais devagar a camada se movimenta.

    private Vector3 lastCameraPosition; // Guarda a última posição registrada da câmera para comparar com sua posição atual.

    void Start() // Executa uma única vez quando o objeto começa a funcionar.
    {
        lastCameraPosition = cameraTransform.position; // Armazena a posição inicial da câmera para utilizá-la como referência.
    }

    void LateUpdate() // Executa a cada frame, depois dos métodos Update(), permitindo acompanhar o movimento atualizado da câmera.
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition; // Calcula quanto a câmera se movimentou desde o último frame, subtraindo a posição anterior da atual.

        transform.position += new Vector3( // Atualiza a posição da camada do cenário somando um novo deslocamento à posição atual.
            deltaMovement.x * parallaxEffect, // Calcula o deslocamento horizontal da camada, multiplicando o movimento da câmera pelo efeito de paralaxe.
            deltaMovement.y * parallaxEffect, // Calcula o deslocamento vertical da camada, utilizando a mesma lógica do eixo horizontal.
            0 // Mantém o deslocamento no eixo Z igual a zero, evitando movimentar a camada para frente ou para trás.
        );

        lastCameraPosition = cameraTransform.position; // Atualiza a última posição registrada da câmera para que possa ser comparada no próximo frame.
    }
}

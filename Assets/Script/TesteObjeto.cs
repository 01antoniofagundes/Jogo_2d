using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    private Transform player;

    public float velocidade = 3f;
    public float distanciaMinima = 1.5f;

    private bool seguindo = false;

    void Update()
    {
        if (seguindo && player != null) // seguindo = false
        {
            float distancia = Vector2.Distance(transform.position, player.position); //Calcula a distancia entre o player e a chave

            //Só se aproxima se estiver longe demais
            if (distancia > distanciaMinima)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, velocidade * Time.deltaTime);
                //Faz a chave se movimentar da posição que ela está, até chegar ao player
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Porta"))
        {
            //Só vai ser ativado a perseguição quando o objeto com a tag "porta" encostar na chave
            //Ao encostar, seguindo = true
            player = collision.transform;
            seguindo = true;
        }
    }
}

using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    private Transform player;

    public float velocidade = 3f;
    public float distanciaMinima = 1.5f;

    private bool seguindo = false;

    void Update()
    {
        if (seguindo && player != null)
        {
            float distancia = Vector2.Distance(transform.position, player.position);

            // Só se aproxima se estiver longe demais
            if (distancia > distanciaMinima)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    player.position,
                    velocidade * Time.deltaTime
                );
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform;
            seguindo = true;
        }
    }
}

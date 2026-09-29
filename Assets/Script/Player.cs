using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();    
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //reconhece as teclas A e D como moviemnto horizontal
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //adiciona a velocidade de movimento

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //reconhece a barra de espaço 
        {
            rb.AddForce(new Vector2(0f, 6.5f), ForceMode2D.Impulse); // adiciona uma força no pulo
        }
        
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; //reconhece quando o jogador está no chao
        }

        if (collision.gameObject.CompareTag("Dano"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false; //reconhece quando o jogador não está no chao
        }
    }
}

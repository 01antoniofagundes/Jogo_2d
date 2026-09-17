using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();    
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //reconhece as teclas A e D como moviemnto horizontal
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //adiciona a velocidade de movimento

        if (Input.GetKeyDown(KeyCode.Space)) //reconhece a barra de espaço 
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); // adiciona uma força no pulo

        }
    }
}

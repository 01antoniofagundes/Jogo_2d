using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    // Configurações do Dash
    public float dashForce = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    public bool temChave;

    // Controle do Dash
    private bool canDash = true;
    private bool isDashing = false;

    // Guarda a direção que o jogador está olhando
    private float direction = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        temChave = false;
    }


    void Update()
    {
        // =========================
        // MOVIMENTO
        // =========================

        float moveHorizontal = Input.GetAxis("Horizontal");

        // Só permite movimento normal quando não está dando Dash
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(
                moveHorizontal * speed,
                rb.linearVelocity.y
            );
        }


        // Guarda a direção que o jogador está olhando
        if (moveHorizontal != 0)
        {
            direction = moveHorizontal;
        }


        // =========================
        // PULO
        // =========================

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(
                new Vector2(0f, 6.5f),
                ForceMode2D.Impulse
            );
        }


        // =========================
        // DASH
        // =========================

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }


    IEnumerator Dash()
    {
        // Impede outro Dash enquanto este estiver acontecendo
        canDash = false;
        isDashing = true;

        float timer = 0f;

        // Faz o jogador se mover durante o tempo do Dash
        while (timer < dashDuration)
        {
            rb.linearVelocity = new Vector2(
                direction * dashForce,
                0f
            );

            timer += Time.deltaTime;

            yield return null;
        }

        // Finaliza o Dash
        isDashing = false;

        // Para o movimento horizontal
        rb.linearVelocity = new Vector2(
            0f,
            rb.linearVelocity.y
        );

        // Espera o cooldown
        yield return new WaitForSeconds(dashCooldown);

        // Permite usar Dash novamente
        canDash = true;
    }


    // =========================
    // COLISÕES
    // =========================

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
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
            isGrounded = false;
        }
    }
}

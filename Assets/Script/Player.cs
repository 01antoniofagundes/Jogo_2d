using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    private bool isGrounded;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();    
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}

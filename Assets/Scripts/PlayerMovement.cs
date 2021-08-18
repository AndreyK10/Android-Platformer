using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed, jumpForce;
    private Rigidbody2D rb;
    [SerializeField] private bool canJump;

    public Joystick joystick;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && canJump) Jump();
    }

    private void Move()
    {
        rb.velocity = new Vector2(playerSpeed * joystick.Horizontal, rb.velocity.y);
    }    

    public void Jump()
    {
        if (canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector2 collisionNormal = collision.contacts[0].normal;
            if (collisionNormal.y > 0) canJump = true;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed, jumpForce;
    private Rigidbody2D rb;
    private bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump) Jump();
    }

    public void MoveRight()
    {
        Move(1);
    }

    public void MoveLeft()
    {
        Move(-1);
    }

    private void Move(int direction)
    {
        rb.velocity = new Vector2(playerSpeed * direction, rb.velocity.y);
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

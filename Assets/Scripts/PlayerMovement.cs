using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed, jumpForce;
    private Rigidbody2D rb;
    private bool isJumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
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
        if (Input.GetKeyDown(KeyCode.Space)) isJumping = true;
    }

    private void FixedUpdate()
    {
        if (isJumping) Jump();
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

    private void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isJumping = false;
        }
    }
}

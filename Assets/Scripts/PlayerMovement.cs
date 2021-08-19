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

    private void FixedUpdate()
    {
        if (joystick.Horizontal >= 0.2f) Move();
        else if (joystick.Horizontal <= -0.2f) Move();
        else rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
    }

    private void Move()
    {
        rb.velocity = new Vector2(playerSpeed * joystick.Horizontal * Time.fixedDeltaTime, rb.velocity.y);
    }    

    public void Jump()
    {
        if (canJump)
        {
            AudioManager.instance.PlaySound(AudioManager.JUMP_SOUND);
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

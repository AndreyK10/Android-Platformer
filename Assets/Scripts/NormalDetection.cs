using UnityEngine;

public class NormalDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionNormal = collision.contacts[0].normal;
        if (collisionNormal.y > 0)
            transform.rotation = Quaternion.FromToRotation(transform.up, collisionNormal) * transform.rotation;
    }
}

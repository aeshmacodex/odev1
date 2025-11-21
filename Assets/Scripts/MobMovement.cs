using UnityEngine;

public class MobMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float MobSpeed = 15f;
    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.right * MobSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
    }
}

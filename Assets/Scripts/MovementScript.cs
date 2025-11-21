using Mono.Cecil.Cil;
using UnityEditor.Callbacks;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horizontal;

    [SerializeField] private float speed = 15f;
    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        //unity'nin yeni movement scripti, Input.GetKey() yerine bunu kullandim cunku kod daha temiz kaliyor
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //karakterin rigidbody'sine yeni bir linear hiz atiyoruz. bu hiza da "horizontal" dedigimizde yukaridaki yeni unity movement scriptindeki bilgileri almis olup SerializeField altinda belirledigimiz 15f'lik speed degeri ile carpiyoruz.
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
}

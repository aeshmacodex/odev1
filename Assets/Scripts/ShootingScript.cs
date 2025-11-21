using Unity.XR.OpenVR;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShootingScript : MonoBehaviour
{
    //bullet objesini yaratir
    [SerializeField] private GameObject bullet;
    //bullet objesinin olusturulacagi noktayi belirler
    [SerializeField] private Transform firePoint;
    //bullet objesinin hizini belirler
    [SerializeField] private float projectileSpeed = 10f;

    private void Update()
    {
        // space tusuna bastigimizda Shoot() kodunu calistirmasini soyluyoruz.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // fabrikadan mermiyi hazirliyor (firepoint pos ve rotationlarini alarak)
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        // 1. satırda Instantiate ile oluşturduğumuz 'projectile' isimli klondan Rigidbody componentini alıyoruz ve 'rb' değişkenine atıyoruz
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        //mermiye hiz veriyor
        rb.linearVelocity = Vector2.up * projectileSpeed;
    }
}


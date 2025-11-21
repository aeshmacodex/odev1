using UnityEngine;

public class Mob : MonoBehaviour
{
    // Bu, parent (ebeveyn) objedeki ana script'e haber verecek
    private SwarmController swarmController;

    void Start()
    {
        swarmController = GetComponentInParent<SwarmController>();
    }

    // Çarpışma/Tetiklenme mantığı
    void OnTriggerEnter2D(Collider2D other)
    {
        // Sınıra çarptıysak 
        if (other.CompareTag("Border"))
        {
            swarmController.HitBorder();
            return; // Fonksiyondan çık, aşağıdaki kodları çalıştırma
        }

        // Bir Mermi mi çarptı?
        if (other.CompareTag("Bullet"))
        {
            // GameManager'a puan eklemesini söyle
            GameManager.instance.AddScore(10); // 10 puan ver

            // GameManager'a bir mob'un öldüğünü söyle
            GameManager.instance.MobKilled();

            // Çarpan mermiyi yok et
            Destroy(other.gameObject);

            // Kendini (bu mob'u) yok et
            Destroy(gameObject);
        }

        // Player (Oyuncu) mu çarptı?
        if (other.CompareTag("Player"))
        {
            // GameManager'a oyunun bittiğini söyle
            GameManager.instance.GameOver();

            // Oyuncuyu yok et
            Destroy(other.gameObject);

            // (İsteğe bağlı) Kendini de yok et
            Destroy(gameObject);
        }
    }
}
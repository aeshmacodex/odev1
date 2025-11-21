using System.Collections; // Coroutine için bu satırı eklemelisin
using UnityEngine;

public class SwarmController : MonoBehaviour
{
    void Start()
    {
        // Gemini yardimiyla yazildi
        // Oyuna başlarken toplam mob sayısını bul
        int initialMobCount = transform.childCount;

        // GameManager'a bu bilgiyi gönder
        GameManager.instance.StartGame(initialMobCount);
    }
    public float speed = 5f;
    public float dropAmount = 0.5f;
    private Vector3 moveDirection = Vector3.right;
    private bool isTurning = false;

    void Update()
    {
        if (!isTurning)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    // mob.cs scriptine mesaj
    public void HitBorder()
    {
        // Eğer zaten bir dönüş işlemi yapıyorsak,
        // diğer mob'lardan gelen TÜM çağrıları yok say.
        if (isTurning)
        {
            return;
        }

        // Dönüş işlemini Coroutine olarak başlat
        StartCoroutine(TurnSequence());
    }

    // Dönüş mantığını yöneten Coroutine
    private IEnumerator TurnSequence()
    {
        // boolu true yap. Artık meşgulüz.
        isTurning = true;

        // Yönü ters çevir
        moveDirection *= -1;

        // Sürüyü aşağı indir
        Vector3 currentPosition = transform.position;
        currentPosition.y -= dropAmount;
        transform.position = currentPosition;
        speed += 0.5f;

        // 4. (ÖNEMLİ) Sınırdan "kurtulmak" için yeni yönde bir adım at
        // Bu, sınıra yapışıp kalmamızı engeller
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 5. Çok kısa bir süre bekle (0.1 saniye)
        // Bu, tüm mob'ların sınırdan fiziksel olarak uzaklaşması
        // ve diğer sınıra çarpmaması için zaman tanır.
        yield return new WaitForSeconds(0.1f);

        // 6. Bayrağı indir. Artık yeni çarpışmalara hazırız.
        isTurning = false;
    }
}
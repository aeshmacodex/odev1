using UnityEngine;
using TMPro; // TextMeshPro için bu satır gerekli
using UnityEngine.SceneManagement; // Sahne yönetimi için bu satır gerekli

public class GameManager : MonoBehaviour
{
    // Bu, diğer script'lerin bu script'e kolayca erişmesini sağlar (Singleton Pattern)
    public static GameManager instance;

    // UI Referansları (Bunları Inspector'dan sürükleyeceğiz)
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    // Oyun Değişkenleri
    private int score = 0;
    private int mobCount;

    void Awake()
    {
        // Singleton Pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Oyunu başlatmak için SwarmController tarafından çağrılacak
    public void StartGame(int totalMobs)
    {
        mobCount = totalMobs;
        UpdateScoreText();

        // Panellerin kapalı olduğundan emin ol
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    // Puan ekler
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Puan yazısını günceller
    void UpdateScoreText()
    {
        scoreText.text = "PUAN: " + score;
    }

    // Bir mob öldüğünde çağrılır
    public void MobKilled()
    {
        mobCount--; // Kalan mob sayısını azalt

        // Mob kalmadı mı?
        if (mobCount <= 0)
        {
            GameWon();
        }
    }

    // Oyun kazanıldığında
    void GameWon()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0; // Oyunu durdur (dondur)
    }

    // Oyun kaybedildiğinde
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Oyunu durdur (dondur)
    }

    // Panellere ekleyeceğimiz bir "Yeniden Başlat" butonu için
    public void RestartGame()
    {
        Time.timeScale = 1; // Oyunu tekrar normal hıza döndür
        // Şu anki aktif sahneyi yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
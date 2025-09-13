using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // UI Text öðesi, skoru gösterecek
    public Text highScoreText;  // Yüksek skoru gösterecek UI Text öðesi
    private int score = 0;  // Baþlangýç skoru
    private int highScore = 0;  // Yüksek skor

    void Start()
    {
        // PlayerPrefs'ten yüksek skoru al
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        // Sol týklama ile skor ekleme
        if (Input.GetMouseButtonDown(0))
        {
            score += 10;  // Skoru 10 artýr
            scoreText.text = "Score: " + score;  // Skoru güncelle
            CheckHighScore();  // Yüksek skoru kontrol et
        }
    }

    void CheckHighScore()
    {
        // Eðer mevcut skor yüksek skordan büyükse, yeni yüksek skoru kaydet
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("HighScore", highScore);  // Yeni yüksek skoru kaydet
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // UI Text ��esi, skoru g�sterecek
    public Text highScoreText;  // Y�ksek skoru g�sterecek UI Text ��esi
    private int score = 0;  // Ba�lang�� skoru
    private int highScore = 0;  // Y�ksek skor

    void Start()
    {
        // PlayerPrefs'ten y�ksek skoru al
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        // Sol t�klama ile skor ekleme
        if (Input.GetMouseButtonDown(0))
        {
            score += 10;  // Skoru 10 art�r
            scoreText.text = "Score: " + score;  // Skoru g�ncelle
            CheckHighScore();  // Y�ksek skoru kontrol et
        }
    }

    void CheckHighScore()
    {
        // E�er mevcut skor y�ksek skordan b�y�kse, yeni y�ksek skoru kaydet
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("HighScore", highScore);  // Yeni y�ksek skoru kaydet
        }
    }
}

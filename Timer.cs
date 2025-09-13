using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;  // Zamanlay�c�y� g�sterecek Text UI ��esi
    private float timeLeft = 30f;  // Oyun s�resi (30 saniye)
    private bool gameOver = false;  // Oyun bitti mi kontrol etmek i�in

    void Update()
    {
        // E�er oyun bitmemi�se, zaman saymaya devam et
        if (!gameOver)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;  // Zaman� azalt
                timerText.text = "Time Left: " + Mathf.Round(timeLeft);  // Kalan zaman� ekranda g�ster
            }
            else
            {
                gameOver = true;  // Oyun bitti
                timerText.text = "Game Over!";  // S�re bitince "Game Over" yaz�s�n� g�ster
                Time.timeScale = 0f;  // Oyun durur, zaman durur
            }

            // E�er oyunda hala devam ediliyorsa, t�klama i�lemini aktif et
            if (Input.GetMouseButtonDown(0))
            {
                // Burada skor artt�rma gibi i�lemleri yapabilirsiniz.
                Debug.Log("T�kland�!");  // Skor art�r�m� burada yap�labilir
            }
        }
    }

    // Oyun bitti�inde, yenileme veya ba�ka i�lemler ekleyebilirsiniz
}

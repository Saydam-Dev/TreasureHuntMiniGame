using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;  // Zamanlayýcýyý gösterecek Text UI öðesi
    private float timeLeft = 30f;  // Oyun süresi (30 saniye)
    private bool gameOver = false;  // Oyun bitti mi kontrol etmek için

    void Update()
    {
        // Eðer oyun bitmemiþse, zaman saymaya devam et
        if (!gameOver)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;  // Zamaný azalt
                timerText.text = "Time Left: " + Mathf.Round(timeLeft);  // Kalan zamaný ekranda göster
            }
            else
            {
                gameOver = true;  // Oyun bitti
                timerText.text = "Game Over!";  // Süre bitince "Game Over" yazýsýný göster
                Time.timeScale = 0f;  // Oyun durur, zaman durur
            }

            // Eðer oyunda hala devam ediliyorsa, týklama iþlemini aktif et
            if (Input.GetMouseButtonDown(0))
            {
                // Burada skor arttýrma gibi iþlemleri yapabilirsiniz.
                Debug.Log("Týklandý!");  // Skor artýrýmý burada yapýlabilir
            }
        }
    }

    // Oyun bittiðinde, yenileme veya baþka iþlemler ekleyebilirsiniz
}

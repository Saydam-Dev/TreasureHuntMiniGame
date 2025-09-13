using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeElapsed = 0f;
    public bool gameOver = false;
    public GameObject sandikAcik;

    void Update()
    {
        if (!gameOver)
        {
            timeElapsed += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeElapsed / 60f);
            int seconds = Mathf.FloorToInt(timeElapsed % 60f);
            timerText.text = string.Format("Geçen Zaman: {0:D2}:{1:D2}", minutes, seconds);

        }
    }
}
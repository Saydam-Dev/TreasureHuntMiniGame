using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int olumsayaci = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (scoreText != null) OlumuGuncelle();
    }

    public void OlumuGuncelle()
    {
        if (scoreText != null) scoreText.text = "Ölüm: " + olumsayaci.ToString();
    }
}

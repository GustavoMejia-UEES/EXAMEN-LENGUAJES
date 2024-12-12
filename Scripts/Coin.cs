using UnityEngine;
using TMPro; 

public class Coin : MonoBehaviour
{
    [Header("Score Settings")]
    public int score = 0; 
    public TextMeshProUGUI scoreText; 

    void Start()
    {
        UpdateScoreUI(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            UpdateScoreUI();
            Destroy(other.gameObject);
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
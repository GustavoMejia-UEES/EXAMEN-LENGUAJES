using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    public Text timerText;
    public int playerScore = 0;
    public int missedObjects = 0;
    public float timer = 30f;
    public AudioClip loseSound;

    private AudioSource audioSource;
    private float spawnSpeedMultiplier = 1.2f;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        UpdateScore(0);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timer);
        if (timer <= 0)
        {
            ObjectGenerator spawner = FindObjectOfType<ObjectGenerator>();
            spawner.spawnInterval /= spawnSpeedMultiplier; 
            timer = 30f; 
        }
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
        UpdateScore(playerScore);
    }

    public void MissObject()
    {
        missedObjects++;
        if (missedObjects >= 5)
        {
            GameOver();
        }
    }

    private void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void GameOver()
    {
        RestartScene();
        
        
    }
}

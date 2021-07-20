using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    public AudioClip bgndMusic;
    public Text scoreText, gameOverScoreText;

    private int score;

    private AudioPlayer audioPlayer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    }

    public Animator gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        audioPlayer.PlaySound(bgndMusic);
    }

    public void GameOver()
    {
        gameOverCanvas.SetTrigger("Game Over");
        audioPlayer.StopSound(bgndMusic);
        int record = 0;
        if (GameManager.instance != null)
        {
            if(score > GameManager.instance.maxScore)
            {
                GameManager.instance.maxScore = score;
            }

            record = GameManager.instance.maxScore;
            PlayerPrefs.SetInt("MaxPoints", GameManager.instance.maxScore);
        }

        gameOverScoreText.text = "Score: " + score + "\nHigh Score: " + record;
        scoreText.text = "";
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "" + score;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

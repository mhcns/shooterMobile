using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text highScoreText;

    public int maxScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        maxScore = PlayerPrefs.GetInt("MaxPoints");
        highScoreText.text = "High Score: " + maxScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}

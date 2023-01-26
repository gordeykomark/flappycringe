using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                      

public class Score : MonoBehaviour
{
    public int score;                                     
    public int bestScore = 0;
    public Text scoreText;                             
    public Text bestScoreText;

    public static Score instance;

    [SerializeField] private AudioSource pointSoundEffect;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            bestScore = PlayerPrefs.GetInt("SaveScore");
        }
    }

    void Start()
    {
        score = 0;                                       
    }

    
    void Update()
    {
        scoreText.text = score.ToString();                  // это связь очков и текста
        bestScoreText.text = "Best: " + bestScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)     // метод для прохода через объект
    {
        if (collision.tag == "Score")                      
        {
            instance.AddScore();                           
        }
    }

    public void AddScore()
    {
        score++;

        pointSoundEffect.Play();

        BestScore();
    }

    public void BestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;

            PlayerPrefs.SetInt("SaveScore", bestScore);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // configuration params
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointPerBlockDestroted = 10;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private bool isAutoPlayEnabled;

    // state variables
    [SerializeField] private int currentScore = 0;

    private void Start()
    {
       UpdateScoreTextUI();
    }


    // Update is called once per frame

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore = currentScore + pointPerBlockDestroted;
        UpdateScoreTextUI();
    }

    private void UpdateScoreTextUI()
    {
        if(scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }

    public void destroyGameStatus()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

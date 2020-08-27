using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [Range(0.1f , 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlock = 20;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore += pointPerBlock;
    }

    public void RestartGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

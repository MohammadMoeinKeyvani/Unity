using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NumberWizard : MonoBehaviour
{
    
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] Text guessText;
    int ourGuess;

    // Start is called before the first frame update
    private void Start()
    {
        StartGame();
    }
    
    void StartGame()
    {
        NextGuess();
        max = max + 1;
    }

    public void OnPressHigher()
    {
        min = ourGuess + 1;
        NextGuess();
    }

    public void OnPressLower()
    {
        max = ourGuess - 1;
        NextGuess();
    }
    
    void NextGuess()
    {
        ourGuess = Random.Range(min , max);
        guessText.text = ourGuess.ToString();
    }
}

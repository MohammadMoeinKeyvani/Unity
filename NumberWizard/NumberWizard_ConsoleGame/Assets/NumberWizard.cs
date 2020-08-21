using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    
    int max = 1000;
    int min = 1;
    int ourGuess = 500;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        Debug.Log("Welcome to Number Wizard Console Game");
        Debug.Log("Please pick a number between " + min + " and " + max + " (1 and 1000 are also pickable)\n\rand don't tell me what it is ...");
        Debug.Log("Tell me if your number is higher or lower than " + ourGuess + " .");
        Debug.Log("Push UpKey for Higher, Push DownKey for Lower \n\rand Push EnterKey if it's Correct number that you picked .");
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = ourGuess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = ourGuess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I am genius ;)");
            max = 1000;
            min = 1;
            ourGuess = 500;
            StartGame();
        }
    }

    void NextGuess()
    {
        ourGuess = (max + min) / 2;
        Debug.Log("How about this one, your number is higher or lower --> " + ourGuess);
    }
}

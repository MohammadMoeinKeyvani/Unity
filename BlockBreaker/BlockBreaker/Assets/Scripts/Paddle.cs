using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidth = 16f;
    [SerializeField] float mouseMinXRange = 1f;
    [SerializeField] float mouseMaxXRange = 15f;
    
    // cached references
    GameSession theGameSession;
    Ball theBall;
    
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddldPosition = new Vector2( transform.position.x , transform.position.y);
        paddldPosition.x = Mathf.Clamp(GetXPos(), mouseMinXRange, mouseMaxXRange);
        transform.position = paddldPosition;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}

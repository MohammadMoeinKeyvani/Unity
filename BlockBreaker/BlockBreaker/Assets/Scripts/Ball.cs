using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // Config Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSuonds;
    [SerializeField] float randomFactor = 0.2f;
        
    // State
    Vector2 ballToPaddleDistance;
    bool hasStarted = false;
    
    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleDistance = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            lockBallOnPaddle();
            launchOnMouseClick();
        }
    }

    private void lockBallOnPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x , paddle1.transform.position.y);
        transform.position = paddlePos + ballToPaddleDistance;
    }

    private void launchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(velocityX , velocityY);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = 
            new Vector2(- Random.Range(0f , randomFactor) , - Random.Range(0f , randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSuonds[Random.Range(0, ballSuonds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}

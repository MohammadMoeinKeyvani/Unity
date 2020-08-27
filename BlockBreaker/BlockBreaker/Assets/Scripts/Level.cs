using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void BlocksCounter()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance;

    void Awake()
    {
        // Create the singleton object.
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // The beginning of the game.
    void StartGame()
    {

    }



    public static void StartPressed(){ instance.StartGame(); }
}

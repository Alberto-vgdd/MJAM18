using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Singleton
    private static MenuManager instance;

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


    // Main menu buttons.
    public void OnStartPressed()
    {
        GameManager.StartPressed();
    }
    public void OnExitPressed()
    {
        Application.Quit();
    }
}

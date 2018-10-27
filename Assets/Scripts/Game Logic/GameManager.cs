using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player 
{
    One,
    Two,
    Count
}

public class GameManager : MonoBehaviour
{
    // Singleton
    private GameManager instance;

    // Constants to handle inputs from both players
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
    public const string Action = "Action";
    public const string Back = "Back";
    public const string Menu = "Menu";

    // Players' Materials
    [Header("Players' Materials")]
    public Material[] materials;


    
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


    void Start()
    {
        // Choose players' colors.
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Player 
{
    One = 0,
    Two = 1,
    Count = 2
}

public class GameManager : MonoBehaviour
{
    // Singleton.
    private static GameManager instance;

    // Constants
    private const float initialMinigameDuration = 10f;

    // Prefabs of the different minigames.
    public Minigame[] minigames;


    // Game Logic variables.
    private int[] scores;
    private Minigame currentMinigame;
    private float minigameDuration;
    private List<int> playedMinigames;
    private int currentMinigameIndex;

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
        // Initialize the variables.
        scores = new int[(int)Player.Count];
        playedMinigames = new List<int>();
    }

    // The beginning of the game.
    void StartGame()
    {
        // Reset the value of the variables
        for (int i = 0; i < scores.Length; i++) { scores[i] = 0;}
        if (currentMinigame != null) { Destroy(currentMinigame.gameObject);}
        minigameDuration = initialMinigameDuration;
        playedMinigames.Clear();
        


        // UI Animation here.
        currentMinigameIndex = GetRandomIndex();
    }

    int GetRandomIndex()
    {
        return 0;
    }



    public static void StartPressed(){ instance.StartGame(); }
}
